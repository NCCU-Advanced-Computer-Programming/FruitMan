using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class control
    {
        enum dirrection { up = 1, down, left, right };
        public int a = 0,b=1,c=5;
        Random random = new Random();

        public int RandomNum()
        {
            a = random.Next(b, c);
            return a;
        }

    }
}
