using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class VarNode
    {
        string type;
        string id;
        string value;

        public VarNode(string type, string id, string value = null)
        {
            this.type = type;
            this.id = id;
            this.value = value;
        }

        public override string ToString()
        {
            var result = "";

            if (value == null)
            {
                result = string.Format("{0} {1}", type, id);
            }
            else
            {
                result = string.Format("{0} {1} = {2}", type, id, value);
            }

            return result;
        }
    }
}
