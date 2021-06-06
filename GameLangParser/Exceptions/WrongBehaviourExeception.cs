using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Exceptions
{
    class WrongBehaviourExeception : Exception
    {
        public WrongBehaviourExeception(string msg) : base("Wrong Behaviour: " + msg) { }
    }
}
