using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindLib
{
    public interface IGenerator
    {
        public Colors[] GenerateSecretCode();
    }
}
