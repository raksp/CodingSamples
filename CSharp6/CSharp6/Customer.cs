using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6
{
    public static class Customer
    {
        public static Guid customerID { get; set; } = Guid.NewGuid();
        public static int Age { get; set; } = 24;

        public static int ShowAge()
        {
            return Age;
        }
    }
}
