using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class ForEachNode
    {
        string TypeSprite;
        string IdSprite;

        public List<UpdateLogicNode> statements;

        public ForEachNode(string TypeSprite, string IdSprite)
        {
            this.TypeSprite = TypeSprite;
            this.IdSprite = IdSprite;
            statements = new List<UpdateLogicNode>();
        }

        public void AddStatement(UpdateLogicNode statement)
        {
            statements.Add(statement);
        }

        public Dictionary<string, string> GetPathTextures(Dictionary<string, string> Textures)
        {
            var result = Textures;
            foreach (var func in statements)
            {
                if (func.assign != null)
                {
                    var turpleValues = func.GetPathTexture();
                    if (turpleValues != null)
                    {
                        if (result[turpleValues.Item1] == "-1")
                        {
                            result[turpleValues.Item1] = turpleValues.Item2;
                        }
                        else if (result[turpleValues.Item1] != turpleValues.Item2)
                        {
                            throw new ReInitTextureException(string.Format("OldPath = {0}, NewPath {1}",
                                result[turpleValues.Item1], turpleValues.Item2));
                        }
                    }
                }
                else if (func.ifNode != null)
                {
                    result = func.ifNode.GetPathTextures(Textures);
                }
                else if (func.forEach != null)
                {
                    result = func.forEach.GetPathTextures(Textures);
                }
            }
            return result;
        }

        public override string ToString()
        {
            string res = "ForEach<[TypeSprite]>([IdSprite] => { \n[statements] \t\t\t});";

            string statementsStr = "";
            string prefix = "\t\t\t\t\t";

            foreach (var statement in statements)
            {
                string postfix = ";\n";
                if (statement.ifNode != null || statement.forEach != null)
                {
                    postfix = "\n";
                }

                statementsStr += prefix + statement.ToString() + postfix;
            }

            res = res.Replace("[TypeSprite]", TypeSprite);
            res = res.Replace("[IdSprite]", IdSprite);
            res = res.Replace("[statements]", statementsStr);

            return res;
        }

        //public override string ToString()
        //{
        //    string res = "ForEach<[TypeSprite]>([IdSpriteTMP] => { \n[statements] \t\t\t});";

        //    string statementsStr = "";
        //    string prefix = "\t\t\t\t\t";

        //    string castingType = prefix + "[TypeSprite] [IdSprite] = ([TypeSprite])[IdSpriteTMP];\n";
        //    castingType = castingType.Replace("[TypeSprite]", TypeSprite);
        //    castingType = castingType.Replace("[IdSprite]", IdSprite);
        //    castingType = castingType.Replace("[IdSpriteTMP]", IdSprite + "TMP");
        //    statementsStr += castingType;

        //    foreach (var statement in statements)
        //    {
        //        string postfix = ";\n";
        //        if (statement.ifNode != null || statement.forEach != null)
        //        {
        //            postfix = "\n";
        //        }

        //        statementsStr += prefix + statement.ToString() + postfix;
        //    }

        //    res = res.Replace("[TypeSprite]", TypeSprite);
        //    res = res.Replace("[IdSpriteTMP]", IdSprite + "TMP");
        //    res = res.Replace("[statements]", statementsStr);

        //    return res;
        //}
    }
}