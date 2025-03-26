using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLib
{
    public class FixedGenerator:IGenerator
    {
        private Colors[] _fixedColors;

        public FixedGenerator(Colors[] fixedColors)
        {
            _fixedColors = fixedColors;
        }
        public Colors[] GenerateSecretCode()
        {
            return _fixedColors;
        }
    }
}
