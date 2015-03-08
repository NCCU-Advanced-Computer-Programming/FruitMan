using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApplication1
{
    class Aibmb
    {
        public Image Aibomb; 
        public void initbmb()
        {
            Aibomb = new Image();

            string packUrl1 = "pack://application:,,,/BAI020233.png";
           // string packUrl = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\E011.png";

           // bomb.Source = new ImageSourceConverter().ConvertFromString(packUrl) as ImageSource;
            Aibomb.Source = new ImageSourceConverter().ConvertFromString(packUrl1) as ImageSource;
            Aibomb.Width = 35;
           // Aibomb.BringIntoView();
            Aibomb.Height = 35;
         
        }
    }
}
