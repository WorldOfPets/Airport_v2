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
using Aiport_v2.dbFolder;
using Aiport_v2.classFolder;
using Aiport_v2.pageFolder;

namespace Aiport_v2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int TimeIn { get; set; }
        public static int UserIdInSys { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            frmClass.frame = frmMain;
            frmMain.Navigate(new pageLogin());

            dbClass.entities = new Session2_16Entities();
        }

        private void frmMain_ContentRendered(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TimeExit = classFolder.dbClass.entities.TimeStatus.FirstOrDefault(x => x.Id == MainWindow.TimeIn);
                TimeExit.TimeExit = DateTime.Now;
                classFolder.dbClass.entities.SaveChanges();
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
                Application.Current.Shutdown();
            }
        }

        private void gridMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
