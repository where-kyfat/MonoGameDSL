using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonogameLib.Behaviours;
using GameLangParser.Exceptions;
using GameLangParser.Nodes;

namespace GameLangParser
{

    public class SpriteInitNode
    {
        public List<Type> behaviours;
        public List<VarNode> variables;
        public string className;

        public SpriteInitNode(string ClassName)
        {
            this.className = ClassName;
            this.behaviours = new List<Type>();
            this.variables = new List<VarNode>();
        }

        public string GetParams(Type type, bool OnlyNames = false)
        {
            return GetParams(type, "", OnlyNames);
        }

        public string GetVariables()
        {
            string res = "";
            foreach (var variable in variables)
            {
                res += "public " + variable.ToString();
            }
            return res;
        }

        public string GetParams(Type type, string existingParams, bool OnlyNames = false, char separator = ',', string availability = "")
        {
            string result = "";
            //var type = typeof(T);

            //If it isn't an Behaviour
            if (!type.IsSubclassOf(typeof(Behaviour)))
            {
                throw new WrongBehaviourExeception("Class must be one of the Behaviour children");
            }

            var getConstructor = type.GetConstructors();
            var constrParams = getConstructor[0].GetParameters();
            foreach (var item in constrParams)
            {
                if (!OnlyNames)
                {
                    if (!existingParams.Contains(item.Name))
                    {
                        result += availability + " " + item.ParameterType.Name + " " + item.Name + separator + " ";
                    }
                }
                else
                {
                    if (!existingParams.Contains(item.Name))
                    {
                        result += availability + " " + item.Name + separator;
                    }
                }

            }

            if (separator != ';')
            {
                result = result.Remove(result.Length - 1);
            }
            
            return result;
        }

        public string GetAddBehaviour(Type type)
        {
            string result = "";

            //If it isn't an Behaviour
            if (!type.IsSubclassOf(typeof(Behaviour)))
            {
                throw new WrongBehaviourExeception("Class must be one of the Behaviour children");
            }

            result = @"
            Behaviours.Add(new [NameBehaviour]([Params]));
";
            result = result.Replace("[NameBehaviour]", type.Name);
            string _params = GetParams(type, OnlyNames : true);
            result = result.Replace("[Params]", _params);
            return result;
        }

        public string GetUpdateBehaviour(Type type)
        {
            string result = "";

            //If it isn't an Behaviour
            if (!type.IsSubclassOf(typeof(Behaviour)))
            {
                throw new WrongBehaviourExeception("Class must be one of the Behaviour children");
            }

            result = @"
            if (Behaviours[i] is [NameBehaviour])
                Behaviours[i] = new [NameBehaviour]([Params behaviour]);
";
            result = result.Replace("[NameBehaviour]", type.Name);
            string _params = GetParams(type, OnlyNames: true);
            result = result.Replace("[Params behaviour]", _params);
            return result;
        }

        public override string ToString()
        {
            string ClassPrefix = @"
    public class [ClassName] : Sprite 
    {
        [Variables]
        [Params behaviour]
        public [ClassName] (Texture2D texture, int positionX, int positionY ) : base(texture, positionX, positionY)
        {
            [Behaviours]
        }

        public override void Update(GameTime gameTime) 
        {
            for (int i = 0; i < Behaviours.Count; i++) 
            {
                [BehavioursUpdate]
            }
            base.Update(gameTime);
        }
    }
";
            string Params = "";
            foreach (var behaviour in behaviours)
            {
                Params += GetParams(behaviour, Params, separator: ';', availability: "public");
            }

            string Behaviours = "";
            foreach (var behaviour in behaviours)
            {
                Behaviours += GetAddBehaviour(behaviour);
            }

            string UpdateBehaviours = "";
            foreach (var behaviour in behaviours)
            {
                UpdateBehaviours += GetUpdateBehaviour(behaviour);
            }

            ClassPrefix = ClassPrefix.Replace("[ClassName]", className);
            ClassPrefix = ClassPrefix.Replace("[Params behaviour]", Params);
            ClassPrefix = ClassPrefix.Replace("[Variables]", GetVariables());
            ClassPrefix = ClassPrefix.Replace("[Behaviours]", Behaviours);
            ClassPrefix = ClassPrefix.Replace("[BehavioursUpdate]", UpdateBehaviours);

            return ClassPrefix;
        }
    }
}
