using System.Collections.Generic;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class InitializeNode : Node
    {
        public List<AssignNode> assings;
        Dictionary<string, string> Textures;

        public InitializeNode() : base("[INITIALIZE SECTION]") 
        {
            this.assings = new List<AssignNode>();
        }

        public void AddAssingNode(AssignNode assing)
        {
            assings.Add(assing);
        }

        public Dictionary<string, string> GetPathTextures(Dictionary<string, string> Textures)
        {
            var result = Textures;
            foreach (var assign in assings)
            {
                var turpleValues = assign.GetPathTexture();
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
            return result;
        }

        public void SetTextures(Dictionary<string, string> Textures)
        {
            this.Textures = Textures;
        }

        protected override void Parse()
        {
            string result = "";
            string prefix = "			";
            foreach (var assign in assings)
            {
                result += prefix + assign.ToString() + ";\n";
            }

            BlockCode = result;
        }
    }
}