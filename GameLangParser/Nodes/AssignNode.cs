using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Exceptions;
using System.Text.RegularExpressions;

namespace GameLangParser.Nodes
{
    public class AssignNode
    {
        string idName;
        string value;
        string typeName = "";

        public string path;
        public string texture = "-1";

        public AssignNode(string idName, string value)
        {
            this.idName = idName;
            this.value = value;
        }

        public AssignNode(string idName, string typeName, string path, string value)
        {
            this.idName = idName;
            this.value = value;
            this.typeName = typeName;
            this.path = path;
        }

        public Tuple<string, string> GetPathTexture()
        {
            if (typeName != "")
            {
                texture = typeName.ToLower() + "Texture";
                var result = new Tuple<string, string>(texture, path);
                return result;
            }
            else if (idName.EndsWith("Texture"))
            {
                return new Tuple<string, string>(idName, value);
            }
            else
            {
                return null;
            }
            
        }

        public override string ToString()
        {
            var result = "[idName] = [assign];";

            if (typeName == "")
            {
                if (idName.EndsWith("Texture"))
                {
                    return "";
                }
                result = result.Replace("[idName]", idName);
                result = result.Replace("[assign]", value);
            }
            
            else
            {
                if (texture == "-1")
                {
                    throw new WrongTextureException(String.Format("Wrong texture name for {0}", idName));
                }
                var strNew = "new [TypeName]([texture][value])";
                result = result.Replace("[assign]", strNew);
                result = result.Replace("[idName]", idName);
                result = result.Replace("[TypeName]", typeName);
                result = result.Replace("[value]", value);
                result = result.Replace("[texture]", texture);

                var strAdd = "sprites.Add([idName]);";
                strAdd = strAdd.Replace("[idName]", idName);

                result = result + "  " + strAdd;
            }

            return result;
        }
    }
}
