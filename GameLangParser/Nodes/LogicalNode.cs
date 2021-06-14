using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLangParser.Nodes;
        
namespace GameLangParser.Nodes
{
    public class LogicalNode
    {
        string first;
        string second;
        string op;

        string code = "-1";

        public LogicalNode(string first, string op, string second)
        {
            this.first = first;
            this.second = second;
            this.op = op;
        }

        public LogicalNode(string code)
        {
            this.code = code;
        }

        public override string ToString()
        {
            if (code != "-1")
            {
                return code;
            }
            else
            {
                return first + op + second;
            }
        }
    }
}
