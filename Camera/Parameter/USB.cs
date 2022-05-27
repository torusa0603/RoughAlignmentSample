using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera.Parameter
{
    public class CUSB : IParameter
    {
        public int PortNumber { get; set; }

        public int CheckVariableValidity()
        {
            return 0;
        }
        public void Dispose()
        {

        }

        public CUSB ShallowCopy() => (CUSB)MemberwiseClone();
    }
}
