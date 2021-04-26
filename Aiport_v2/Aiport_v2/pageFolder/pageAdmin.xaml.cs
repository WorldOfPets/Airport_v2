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
    /// Логика взаимодействия для pageAdmin.xaml
    /// </summary>
    public partial class pageAdmin : Page
    {
        public static int idData{ get; set; }
        public pageAdmin()
        {
            InitializeComponent();

            var User = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == MainWindow.UserIdInSys);
            dbFolder.TimeStatus timeStatus = new dbFolder.TimeStatus
            {
                IdUser = User.Id,
                TimeEnter = DateTime.Now
            };
            classFolder.dbClass.entities.TimeStatus.Add(timeStatus);
            classFolder.dbClass.entities.SaveChanges();
            MainWindow.TimeIn = timeStatus.Id;

            cmbOffice.SelectedValuePath = "Id";
            cmbOffice.DisplayMemberPath = "Title";
            cmbOffice.ItemsSource = classFolder.dbClass.entities.Office.ToList();

            dataMain.ItemsSource = classFolder.dbClass.entities.User.ToList();
            classFolder.frmAdmin.frmAd = frmAdmin;

            idData = 0;
        }
        #region Комбобок с офисами выбор офиса и заполненине дата грид
        private void cmbOffice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cmbOffice.IsDropDownOpen)
                {
                    frmAdmin.Visibility = Visibility.Hidden;
                    dataMain.Visibility = Visibility.Visible;
                    if ((int)cmbOffice.SelectedValue != 7)
                    {
                        dataMain.ItemsSource = classFolder.dbClass.entities.User.Where(x => x.IdOffice == (int)cmbOffice.SelectedValue).ToList();
                    }
                    else
                    {
                        dataMain.ItemsSource = classFolder.dbClass.entities.User.ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        #region Кнопка блокировки пользователя
        private void btnDisEna_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dataMain.Visibility == Visibility.Visible && idData != 0)
                {
                    var UserDis = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == idData);
                    if (UserDis.Active == true)
                    {
                        var disabled = MessageBox.Show($"Disabled {UserDis.FirstName} {UserDis.LastName}?", "..::Запрос на подтверждение::..", MessageBoxButton.YesNo);
                        if (disabled == MessageBoxResult.Yes)
                        {
                            UserDis.Active = false;
                        }
                    }
                    else
                    {
                        var disabled = MessageBox.Show($"Enabled {UserDis.FirstName} {UserDis.LastName}?", "..::Запрос на подтверждение::..", MessageBoxButton.YesNo);
                        if (disabled == MessageBoxResult.Yes)
                        {
                            UserDis.Active = true;
                        }
                    }
                    classFolder.dbClass.entities.SaveChanges();
                    dataMain.ItemsSource = classFolder.dbClass.entities.User.ToList();
                }
                else MessageBox.Show("User not selected.");
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion
        
        #region Выбор строки дата грид
        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (DataGridRow)sender;
                var context = row.DataContext as dbFolder.User; 
                if (context == null) return;
                idData = context.Id;
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion
        
        #region Кнопки переходов и кнопка выхода
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            dataMain.Visibility = Visibility.Collapsed;
            frmAdmin.Visibility = Visibility.Visible;
            frmAdmin.Navigate(new pageEditUser());
            cmbOffice.Text = "";
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            dataMain.Visibility = Visibility.Collapsed;
            frmAdmin.Visibility = Visibility.Visible;
            frmAdmin.Navigate(new pageAdd());
            cmbOffice.Text = "";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var TimeExit = classFolder.dbClass.entities.TimeStatus.FirstOrDefault(x => x.Id == MainWindow.TimeIn);
                TimeExit.TimeExit = DateTime.Now;
                classFolder.dbClass.entities.SaveChanges();
                if (classFolder.frmClass.frame.CanGoBack)
                {
                    classFolder.frmClass.frame.GoBack();
                }
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

    }
}
