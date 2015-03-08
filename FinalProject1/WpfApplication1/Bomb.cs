using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    class Bomb
    {
       
        public Image bomb;
        public void init()
        {
            
            bomb = new Image();
            //string packUrl1 = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\BAI020233.png";
            string packUrl = "pack://application:,,,/E011.png";

            bomb.Source = new ImageSourceConverter().ConvertFromString(packUrl) as ImageSource;
          
            bomb.Width = 35;
            bomb.BringIntoView();
            bomb.Height = 50;


        }
    }
}
