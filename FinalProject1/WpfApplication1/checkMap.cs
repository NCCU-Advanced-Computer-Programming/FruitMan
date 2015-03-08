using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class checkMap
    {
      public  int[,] Carray=new int[11,13];
        enum stats { empty = 1, brick, wall, bomb, character,bomb1,character1 };
        
        public void set(int ix, int iy,int iz)
        {
            Carray[iy, ix] = iz;
        }

        public void check(int ix, int iy)
        {
            

        }
        public int checkbmb(int ix, int iy)
        {
            if (Carray[iy, ix] == (int)stats.empty) {
                return 0;
            }
           else  if (Carray[iy, ix] == (int)stats.wall) {
                return 0;            
            }
           else  if (Carray[iy, ix] == (int)stats.character) {
                return 1;
            }
            else if (Carray[iy, ix] == (int)stats.brick) {
                return 2;
            }
          //  else if (Carray[iy, ix] == (int)stats.bomb)
         //   {
          //      return 0;
          //  }
            else
            {
                return 0;
            }
        }
        
    }
}
