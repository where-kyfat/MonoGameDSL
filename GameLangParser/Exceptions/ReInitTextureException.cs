using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLangParser.Exceptions
{
    class ReInitTextureException : Exception
    {
        public ReInitTextureException(string message)
            : base("Reinit texture error: " + message)
        { }
    }
}
