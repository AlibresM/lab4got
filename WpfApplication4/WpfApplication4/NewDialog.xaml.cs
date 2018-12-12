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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for NewDialog.xaml
    /// </summary>
    public partial class NewDialog : Window
    {
        public NewDialog()
        {
            InitializeComponent();
        }

        public int res = 1;
        private void buttonc_Click(object sender, RoutedEventArgs e)
        {
            res = 2;
            Close();
        }

        private void buttony_Click(object sender, RoutedEventArgs e)
        {
            res = 1;
            Close();
        }

        private void buttonn_Click(object sender, RoutedEventArgs e)
        {
            res = 0;
            Close();
        }
    }
}
