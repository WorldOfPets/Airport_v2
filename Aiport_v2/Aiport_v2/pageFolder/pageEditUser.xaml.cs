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
    /// Логика взаимодействия для pageEditUser.xaml
    /// </summary>
    public partial class pageEditUser : Page
    {
        int chek { get; set; }
        public pageEditUser()
        {
            InitializeComponent();
            #region Иниициализация
            try
            {
                if (pageAdmin.idData == 0)
                {
                    tbChoose.Text = "Choose a user.";
                    stEditRole.Visibility = Visibility.Hidden;
                }
                else
                {
                    var editUser = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == pageAdmin.idData);
                    tbChoose.Text = $"{editUser.FirstName} {editUser.LastName}";
                    tbEmail.Text = editUser.Email;
                    tbFirstName.Text = editUser.FirstName;
                    tbLastName.Text = editUser.LastName;
                    cmbOffice.SelectedValuePath = "Id";
                    cmbOffice.DisplayMemberPath = "Title";
                    cmbOffice.ItemsSource = classFolder.dbClass.entities.Office.Where(x => x.Title != "All").ToList();/*.Where(x => x.Name != "All")*/
                    stEditRole.Visibility = Visibility.Visible;
                    if (editUser.IdRole == 1)
                    {
                        chek = 1;
                        cbAdmin.IsChecked = true;
                        cbUser.IsChecked = false;
                    }
                    else
                    {
                        chek = 2;
                        cbAdmin.IsChecked = false;
                        cbUser.IsChecked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
            #endregion
        }
        private void cbUser_Click(object sender, RoutedEventArgs e)
        {
            chek = 2;
            cbAdmin.IsChecked = false;
            cbUser.IsChecked = true;
        }

        private void cbAdmin_Click(object sender, RoutedEventArgs e)
        {
            chek = 1;
            cbAdmin.IsChecked = true;
            cbUser.IsChecked = false;
        }

        #region Кнопка изменения пользователя
        private void btnSaneChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var save = MessageBox.Show("Save changes?", "..::SAVE::..", MessageBoxButton.YesNo);
                if (save == MessageBoxResult.Yes)
                {
                    if (cmbOffice.Text != "")
                    {
                        var editSave = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == pageAdmin.idData);
                        editSave.Email = tbEmail.Text;
                        editSave.FirstName = tbFirstName.Text;
                        editSave.LastName = tbLastName.Text;
                        editSave.IdOffice = (int)cmbOffice.SelectedValue;
                        editSave.IdRole = chek;
                        int proverka = classFolder.dbClass.entities.User.Where(x => x.Id != editSave.Id && x.Email == editSave.Email).Count();
                        if (proverka == 0)
                        {
                            classFolder.dbClass.entities.SaveChanges();
                        }
                        else
                        {
                            MessageBox.Show("User with this Email exist.", "..::Error::..");
                        }
                    }
                    else MessageBox.Show("Selected office.", "Data");
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
