using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.Windows.Threading;
namespace WpfApplication1
{
    class Character1
    {
        public Image AIimg;
        public void init()
        {
            AIimg = new Image();
            string packUri = "pack://application:,,,/橘子超人正面.png";

            AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            AIimg.Width = 80;
            AIimg.BringIntoView();
            AIimg.Height = 80;
            

        }
        public void front()
        {
           
            string packUri = "pack://application:,,,/橘子超人正面.png";

            AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            AIimg.Width = 80;
            AIimg.BringIntoView();
            AIimg.Height = 80;
        }
        public void back()
        {
            
            string packUri = "pack://application:,,,/橘子超人背面.png";
          
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 80;
                AIimg.BringIntoView();
                AIimg.Height = 80;
         
        }
        public void left()
        {
            
            string packUri = "pack://application:,,,/橘子超人左.png";
          
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 80;
                AIimg.BringIntoView();
                AIimg.Height = 80;
            
           
        }
        public void right()
        {
            
            string packUri = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\橘子超人右.png";

            AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            AIimg.Width = 80;
            AIimg.BringIntoView();
            AIimg.Height = 80;
        }
    }
}
