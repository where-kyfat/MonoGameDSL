using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Nodes
{
    public class ConditionNode
    {
        public List<string> conditionParams;

        string name;

        public ConditionNode(string id)
        {
            this.name = id;
            this.conditionParams = new List<string>();
        }

        string GetParams()
        {
            string res = "";


            if (conditionParams.Count > 0)
            {
                foreach (var param in conditionParams)
                {
                    res += param + ',';
                }
                res = res.Remove(res.Length - 1);
            }

            return res;
        }

        public override string ToString()
        {
            string res = "Conditions.[name]([params])";

            res = res.Replace("[name]", name);
            res = res.Replace("[params]", GetParams());

            return res;
        }
    }
}
