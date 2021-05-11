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
    /// Логика взаимодействия для EditFly.xaml
    /// </summary>
    public partial class EditFly : Page
    {
        public EditFly()
        {
            InitializeComponent();
            if (pageManager.idDat != 0)//Загрузка данных о выбранном полете
            {
                var select = classFolder.dbClass.entities.Schedule.FirstOrDefault(x => x.Id == pageManager.idDat);
                tbAirportFrom.Text = select.getFrom;
                tbAirportTo.Text = select.getTo;
                tbAircraft.Text = select.Aircraft.Name;
                tbDate.Text = select.Date.Value.ToShortDateString();
                tbTime.Text = select.Time.Value.ToString();
                tbDate.Text = select.getDate;
                tbEconomPrice.Text = select.getEc;

            }
            else
            {
                tbSelect.Visibility = Visibility.Visible;//Отображение ошибки
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)//Сохранение измененной информации
        {
            try
            {
                if (tbDate.Text == "" && tbTime.Text == "" && tbEconomPrice.Text == "")
                {
                    var select = classFolder.dbClass.entities.Schedule.FirstOrDefault(x => x.Id == pageManager.idDat);
                    var time = tbTime.Text;
                    select.Date = Convert.ToDateTime(tbDate.Text);
                    select.Time = TimeSpan.Parse(tbTime.Text);
                    select.EconomyPrice = Convert.ToInt32(tbEconomPrice.Text);
                    classFolder.dbClass.entities.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
                throw;
            }
            
        }
    }
}
