using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
namespace WpfApplication1
{
    class bug1
    {
        public Image bugimg = new Image();

        public Image init()
        {

            string packUri = "pack://application:,,,/bug_L.png";


            bugimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            bugimg.Width = 80;
            bugimg.BringIntoView();
            bugimg.Height = 80;
            return bugimg;
        }

        public Image left()
        {
            string packUri = "pack://application:,,,/bug_L.png";

            bugimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            bugimg.Width = 80;
            bugimg.BringIntoView();
            bugimg.Height = 80;
            return bugimg;
        }

        public Image right()
        {
            string packUri = "pack://application:,,,/bug_R.png";

            bugimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            bugimg.Width = 80;
            bugimg.BringIntoView();
            bugimg.Height = 80;
            return bugimg;
        }

    }
}
