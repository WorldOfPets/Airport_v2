using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using System.Windows.Threading;

namespace Aiport_v2.pageFolder
{
    /// <summary>
    /// Логика взаимодействия для pageLogin.xaml
    /// </summary>
    public partial class pageLogin : Page
    {
        public DispatcherTimer timer = new DispatcherTimer();
        public int error { get; set; }
        public int timeError { get; set; }
        
        public pageLogin()
        {
            InitializeComponent();
            error = 0;
            timeError = 10;
            tbEmail.Text = "3333@";
            pbPass.Password = "3333";
        }

        #region Кнопка регистрации
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pass = classFolder.classHash.GetHashString(pbPass.Password);
                var User = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Email == tbEmail.Text && x.Password == pass);
                if (User != null)
                {
                    //for (int i = 1; i <= 8; i++)
                    //{
                    //    classFolder.classHash.GetHashString(i);
                    //}
                    if (User.Active == true)
                    {
                        switch (User.IdRole)
                        {
                            case 1:
                                MainWindow.UserIdInSys = User.Id;
                                classFolder.frmClass.frame.Navigate(new pageAdmin());
                                break;
                            case 2:
                                MainWindow.UserIdInSys = User.Id;
                                classFolder.frmClass.frame.Navigate(new pageUser());
                                break;
                            case 3:
                                MainWindow.UserIdInSys = User.Id;
                                classFolder.frmClass.frame.Navigate(new pageManager());
                                break;
                        }
                    }
                    else MessageBox.Show($"{User.FirstName} {User.LastName} disabled!", "Disabled", MessageBoxButton.OK);
                }
                else
                {
                    error++;
                    if (error == 3)
                    {
                        stcError.Visibility = Visibility.Visible;
                        btnLogin.Visibility = Visibility.Hidden;
                        DispatcherTimerSample();
                    }
                    MessageBox.Show("User not find!", "Error Enter", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "..::Error::..");
            }
        }
        #endregion

        #region Dispetcher Time
        public void DispatcherTimerSample()
        {
            try
            { 
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "..::Error::..");
            }
        }
        #endregion

        #region Timer tick обновление 
        public void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                tbTime.Text = (timeError--).ToString();
                if (timeError == -1)
                {
                    timer.Stop(); error = 0;
                    timeError = 10;
                    timer = new DispatcherTimer();
                    stcError.Visibility = Visibility.Hidden;
                    btnLogin.Visibility = Visibility.Visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "..::Error::..");
            }
        }
        #endregion
    }
}
