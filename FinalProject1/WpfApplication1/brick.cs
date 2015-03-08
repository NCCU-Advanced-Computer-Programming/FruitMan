using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfApplication1
{
    class brick
    {
       // public brick[,] brkarray = new brick[11, 13];
        public Image brickimg;
        public int brickx;
        public int bricky;
        public bool isRemoved = false;
        public void init()
        {
            brickimg = new Image();
            string packUri = "pack://application:,,,/block.jpg";

            brickimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            brickimg.Width = 40;
            brickimg.Height = 200;
            brickimg.BringIntoView();
         


        }
    }
}
