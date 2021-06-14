using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Exceptions;

namespace GameLangParser.Nodes
{
    public class UpdateLogicNode
    {
        public string func;

        public AssignNode assign;

        public IfNode ifNode;

        public UpdateLogicNode(string func)
        {
            this.func = func;
        }

        public UpdateLogicNode(AssignNode assign)
        {
            this.assign = assign;
        }

        public UpdateLogicNode(IfNode ifNode)
        {
            this.ifNode = ifNode;
        }

        public Tuple<string, string> GetPathTexture()
        {
            if (assign != null)
            {
                return assign.GetPathTexture();
            }
            else 
            {
                return null;
            } 
        }

        public override string ToString()
        {
            string result = "";

            if (assign != null)
            {
                result = assign.ToString();
            }
            else if (ifNode != null)
            {
                result = ifNode.ToString();
            }
            else
            {
                result = func;
            }

            return result;
        }
    }
}
