using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLib
{
    public class MasterMindPc : IGenerator
    {
        public Colors[] Code { get; private set }
        public MasterMindPc()
        {
            Code = new Colors[4];
        }
        public Colors[] GenerateSecretCode()
        {
            Random rnd = new Random();
            for (int i = 0; i < Code.Length; i++)
            {
                Code[i] = (Colors)rnd.Next(0, Enum.GetValues(typeof(Colors)).Length);
            }
            return Code;
        }

    }
}
