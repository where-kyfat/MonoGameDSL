using System.Collections.Generic;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class UpdateNode : Node
    {
        public List<UpdateLogicNode> functionality;

        public UpdateNode(string BlockCode, string KeyWord) : base(BlockCode, KeyWord) 
        {
            functionality = new List<UpdateLogicNode>();
        }

        public Dictionary<string, string> GetPathTextures(Dictionary<string, string> Textures)
        {
            var result = Textures;
            foreach (var func in functionality)
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

        public override string ToString(string gameCode)
        {
            string result = "";
            string prefix = "\t\t\t";
            foreach (var func in functionality)
            {
                result += prefix + func + "\n";
            }

            return gameCode.Replace(KeyWord, result);
        }
    }
}