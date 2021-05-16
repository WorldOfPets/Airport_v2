using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Aiport_v2.pageFolder
{
    /// <summary>
    /// Логика взаимодействия для ImportFly.xaml
    /// </summary>
    public partial class ImportFly : Page
    {
        public ImportFly()
        {
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv| All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                tbPathFile.Text = openFileDialog.FileName;
            }
        }
    }
}
