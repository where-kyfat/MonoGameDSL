using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class IfNode
    {
        public LogicalNode condition;

        public List<UpdateLogicNode> statements;

        public IfNode()
        {
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
            }
            return result;
        }

        public override string ToString()
        {
            string res = "if ([condition]) { [statements] }";

            string statementsStr = "";
            foreach (var statement in statements)
            {
                statementsStr += statement.ToString() + ';';
            }

            res = res.Replace("[condition]", condition.ToString());
            res = res.Replace("[statements]", statementsStr);

            return res;
        }
    }
}
