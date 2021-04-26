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
    /// Логика взаимодействия для pageAdd.xaml
    /// </summary>
    public partial class pageAdd : Page
    {
        public pageAdd()
        {
            InitializeComponent();

            cmbOfficeAdd.SelectedValuePath = "Id";
            cmbOfficeAdd.DisplayMemberPath = "Title";
            cmbOfficeAdd.ItemsSource = classFolder.dbClass.entities.Office.Where(x => x.Title != "All").ToList();
        }
        #region Кнопка добавления нового пользователя
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbEmailAdd.Background == Brushes.Green && tbFirstAdd.Background == Brushes.Green && tbLastAdd.Background == Brushes.Green && borderCmb.BorderBrush == Brushes.Green && tbBirhdateAdd.Background == Brushes.Green && tbPassAdd.Background == Brushes.Green)
                {
                    dbFolder.User user = new dbFolder.User
                    {
                        Email = tbEmailAdd.Text,
                        FirstName = tbFirstAdd.Text,
                        LastName = tbFirstAdd.Text,
                        IdOffice = (int)cmbOfficeAdd.SelectedValue,
                        IdRole = 2,
                        Password = classFolder.classHash.GetHashString(tbPassAdd.Text),
                        Active = true,
                        Birthdate = Convert.ToDateTime(tbBirhdateAdd.Text)
                    };
                    int proverka = classFolder.dbClass.entities.User.Where(x => x.Id != user.Id && x.Email == user.Email).Count();
                    if (proverka == 0)
                    {
                        classFolder.dbClass.entities.User.Add(user);
                        classFolder.dbClass.entities.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("User with this Email exist.", "..::Error::..");
                    }

                    MessageBox.Show($"The user {user.FirstName} {user.LastName} has been successfully added.", "..::Successfully add::..");
                }
                else MessageBox.Show("The data is empty.", "..::Data error::..");
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        #region Текст чейнгеды
        private void tbEmailAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = (TextBox)sender;
            char space = ' ';
            char dog = '@';
            if (String.IsNullOrEmpty(box.Text) || String.IsNullOrWhiteSpace(box.Text) || Convert.ToInt32(box.Text.IndexOf(space)) >= 0 || box.Text.Length <= 3 || box.Text.IndexOf(dog) <= 2)
            {
                box.Background = Brushes.Red;
            }
            else box.Background = Brushes.Green;
        }

        private void tbFirstAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = (TextBox)sender;
            char space = ' ';
            if (String.IsNullOrEmpty(box.Text) || String.IsNullOrWhiteSpace(box.Text) || Convert.ToInt32(box.Text.IndexOf(space)) >= 0 || box.Text.Length <= 3)
            {
                box.Background = Brushes.Red;
            }
            else box.Background = Brushes.Green;
        }

        private void tbBirhdateAdd_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = (TextBox)sender;
            if (Convert.ToInt32(box.Text.IndexOf(' ')) >= 0)
            {
                box.Text = "";
                MessageBox.Show("Not Space!!!");
            }
            else if (box.Text.Length < 8)
            {
                box.Background = Brushes.Red;
            } 
            else if (box.Text.Length == 8)
            {
                box.Text = Convert.ToInt32(box.Text).ToString("##/##/####");
                box.Background = Brushes.Green;
            }
        }

        private void cmbOfficeAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            borderCmb.BorderBrush = Brushes.Green;
        }
        #endregion
    }
}
