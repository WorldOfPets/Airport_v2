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

namespace Aiport_v2.pageFolder
{
    /// <summary>
    /// Логика взаимодействия для EditAndImport.xaml
    /// </summary>
    public partial class EditAndImport : Window
    {
        public EditAndImport()
        {
            InitializeComponent();
            if (pageManager.editOrImport == "Edit")//Страница изменения полета
            {
                frmEdit.Navigate(new EditFly());
            }
            if (pageManager.editOrImport == "Import")//Страница изменения полета
            {
                frmEdit.Navigate(new ImportFly());
            }
        }

        private void gridMove_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();//Перемещение окна
        }

        public void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();//Закрытие окна
            }
            catch (Exception ex)
            {
                this.Close();
            }
        }
    }
}
