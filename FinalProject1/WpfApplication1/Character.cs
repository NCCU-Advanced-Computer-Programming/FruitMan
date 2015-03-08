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

    class Character 
    {
        
        public Image myimg;
        public void init()
        {
            myimg = new Image();
          //  string packUri="C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\哈密瓜超人正面.png";
           
                string packUri = "pack://application:,,,/哈密瓜超人正面.png";
            
             myimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                myimg.Width = 80;
                myimg.BringIntoView();
                myimg.Height = 80;
           
            
            
        }
        public void front()
        {
            
                string packUri = "pack://application:,,,/哈密瓜超人正面.png";
                myimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                myimg.Width = 80;
                myimg.BringIntoView();
                myimg.Height = 80;
            
        }
        public void back() {
               string packUri = "pack://application:,,,/哈密瓜超人背面.png";
                myimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                myimg.Width = 80;
                myimg.BringIntoView();
                myimg.Height = 80;
           
        }
        public void left()
        {
           
                string packUri = "pack://application:,,,/哈密瓜超人左面.png";
                myimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                myimg.Width = 80;
                myimg.BringIntoView();
                myimg.Height = 80;
           
        }
        public void right()
        {
            
                string packUri = "pack://application:,,,/哈密瓜超人右面.png";
                myimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                myimg.Width = 80;
                myimg.BringIntoView();
                myimg.Height = 80;
           
        }
       
        
    }
}
