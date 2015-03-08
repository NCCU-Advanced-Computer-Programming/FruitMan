using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// select.xaml 的互動邏輯
    /// </summary>
    public partial class select : Window
    {
        int i;
        public select()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            i = 2;//橘子超人
            MainWindow mdn = new MainWindow();
            ;
            this.Hide();
            mdn.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mdn = new MainWindow();
            ;
            this.Hide();
            mdn.Show();
        }
    }
}
