using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    class juice
    {
        public Image hamijuice=new Image();
        public Image orgjuice=new Image();

        public void init(int i)
        {
            if (i == 1)
            {
                string packUri = "pack://application:,,,/hamijuice.png";

                hamijuice.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                hamijuice.Width = 80;
                hamijuice.BringIntoView();
                hamijuice.Height = 80;
            }
            if (i == 2)
            {
                string packUri = "pack://application:,,,/orgjuice.png";

                orgjuice.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                orgjuice.Width = 80;
                orgjuice.BringIntoView();
                orgjuice.Height = 80;
            }
        }
    }
}
