using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonogameLib.Behaviours;
using GameLangParser.Exceptions;

namespace GameLangParser
{

    public class SpriteInitNode
    {
        public List<Type> behaviours;
        string className;

        public SpriteInitNode(string ClassName)
        {
            this.className = ClassName;
            behaviours = new List<Type>();
        }

        public void AddBehaviour(Type type)
        {
            behaviours.Add(type);
        }

        public string GetParams(Type type, bool OnlyNames = false)
        {
            return GetParams(type, "", OnlyNames);
        }

        public string GetParams(Type type, string existingParams, bool OnlyNames = false)
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
                        result += item.ParameterType.Name + " " + item.Name + " ,";
                    }
                }
                else
                {
                    if (!existingParams.Contains(item.Name))
                    {
                        result += item.Name + " ,";
                    }
                }

            }

            // removing last ','
            result = result.Remove(result.Length - 1);
            return result;
        }

        public string GetBehaviour(Type type)
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
            string _params = GetParams(type, true);
            result = result.Replace("[Params]", _params);
            return result;
        }

        public override string ToString()
        {
            string ClassPrefix = @"
    public class [ClassName] : Sprite 
    {
        public [ClassName] (Texture2D texture, int positionX, int positionY [Params]) : base(texture, positionX, positionY)
        {
            [Behaviours]
        }
    }
";
            string Params = ",";
            foreach (var behaviour in behaviours)
            {
                Params += GetParams(behaviour, Params) + ",";
            }
            Params = Params.Remove(Params.Length - 1);

            string Behaviours = "";
            foreach (var behaviour in behaviours)
            {
                Behaviours += GetBehaviour(behaviour);
            }

            ClassPrefix = ClassPrefix.Replace("[ClassName]", className);
            ClassPrefix = ClassPrefix.Replace("[Params]", Params);
            ClassPrefix = ClassPrefix.Replace("[Behaviours]", Behaviours);

            return ClassPrefix;
        }
    }
}
