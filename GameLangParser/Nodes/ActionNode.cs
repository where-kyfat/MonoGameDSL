using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class ActionNode
    {
        public List<string> ActionParams;

        string name;

        public ActionNode(string id)
        {
            this.name = id;
            this.ActionParams = new List<string>();
        }

        string GetParams()
        {
            string res = "";

            if (ActionParams.Count > 0)
            {
                foreach (var param in ActionParams)
                {
                    res += param + ',';
                }
                res = res.Remove(res.Length - 1);
            }

            return res;
        }

        public override string ToString()
        {
            string res = "Actions.[name]([params])";

            res = res.Replace("[name]", name);
            res = res.Replace("[params]", GetParams());

            return res;
        }
    }
}
