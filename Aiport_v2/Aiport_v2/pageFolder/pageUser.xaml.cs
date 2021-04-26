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
using System.Windows.Threading;

namespace Aiport_v2.pageFolder
{
    /// <summary>
    /// Логика взаимодействия для pageUser.xaml
    /// </summary>
    public partial class pageUser : Page
    {
        public DispatcherTimer dispatcher = new DispatcherTimer();
        public static DateTime dateTime { get; set; } = DateTime.MinValue;//TimeSpan

        #region Инициализация компонентов, определение пользователя и регистрация времени вхождения, а так же вывод информации
        public pageUser()
        {
            InitializeComponent();

            try
            {
                var User = classFolder.dbClass.entities.User.FirstOrDefault(x => x.Id == MainWindow.UserIdInSys);
                dbFolder.TimeStatus timeStatus = new dbFolder.TimeStatus
                {
                    IdUser = User.Id,
                    TimeEnter = DateTime.Now
                };
                classFolder.dbClass.entities.TimeStatus.Add(timeStatus);
                classFolder.dbClass.entities.SaveChanges();
                MainWindow.TimeIn = timeStatus.Id;

                tbFullName.Text = $"{User.FirstName} {User.LastName}";

                var Login = classFolder.dbClass.entities.TimeStatus.Where(x => x.TimeExit != null || x.idStatus != null);
                dataUser.ItemsSource = Login.ToList();

                dateTime = DateTime.MinValue;
                foreach (var i in Login)
                {
                    if (i.TimeEnter.Value.Date >= DateTime.Now.Date.AddDays(-30))
                    { 
                        //dateTime += (i.ExitTime.Value.TimeOfDay - i.EnterDate.Value.TimeOfDay);
                        dateTime = dateTime + (i.getInSys.TimeOfDay);
                    }
                }
                var error = classFolder.dbClass.entities.TimeStatus.Where(x => x.idStatus != null).Count();
                tbNumber.Text = error.ToString();
                DispatherTime();
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        #region DispatherTime
        public void DispatherTime()
        {
            try
            {
                dispatcher.Interval = TimeSpan.FromSeconds(1);
                dispatcher.Tick += timerTick;
                dispatcher.Start();
            }
            catch (Exception ex) 
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        #region TimerTick обновление каждую секунду
        private void timerTick(object sender, EventArgs e)
        {
            try
            { 
                dateTime = dateTime.AddSeconds(1);
                tbTimeInSys.Text = dateTime.ToLongTimeString();
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        #region Кнопка выхода с регистрацией времени
        private void btnExitUser_Click(object sender, RoutedEventArgs e)
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
