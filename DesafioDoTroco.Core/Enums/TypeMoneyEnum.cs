using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDoTroco.Core.Enums
{
    public enum TypeMoneyEnum
    {
        [Description("Cédula(s)")]
        Cedula = 0,

        [Description("Moedas")]
        Moeda = 1
    }
}
