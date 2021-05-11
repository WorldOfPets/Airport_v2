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
    /// Логика взаимодействия для pageManager.xaml
    /// </summary>
    public partial class pageManager : Page
    {
        public static int idDat { get; set; } = 0;
        public static string editOrImport { get; set; }
        public pageManager()
        {
            InitializeComponent();

            dataManager.ItemsSource = classFolder.dbClass.entities.Schedule.OrderBy(x => x.Time).OrderBy(x => x.Date).ToList();

            CmbFrom.SelectedValuePath = "Id";
            CmbFrom.DisplayMemberPath = "Name";
            CmbFrom.ItemsSource = classFolder.dbClass.entities.Airport.ToList();

            CmbTo.SelectedValuePath = "Id";
            CmbTo.DisplayMemberPath = "Name";
            CmbTo.ItemsSource = classFolder.dbClass.entities.Airport.ToList();

            CmbSort.Items.Add("Date-time");
            CmbSort.Items.Add("Economy price");
            CmbSort.Items.Add("Confirmed");
            CmbSort.Text = "Date-time";
        }

        #region Выбор строки дата грид
        private void DataGridRow_Selected(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (DataGridRow)sender;
                var context = row.DataContext as dbFolder.Schedule;
                if (context == null) return;
                idDat = context.Id;
            }
            catch (Exception ex)
            {
                classFolder.errorClass.except(ex);
            }
        }
        #endregion

        private void CancelFl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (idDat != 0)
                {
                    var sch = classFolder.dbClass.entities.Schedule.FirstOrDefault(x => x.Id == idDat);
                    if (sch.Confirmed == true)
                    {
                        sch.Confirmed = false;
                    }
                    else
                    {
                        sch.Confirmed = true;

                    }
                    classFolder.dbClass.entities.SaveChanges();
                    dataManager.ItemsSource = classFolder.dbClass.entities.Schedule.ToList();
                }
                else
                {
                    MessageBox.Show("");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void CmbFrom_DropDownClosed(object sender, EventArgs e)
        {
            CmbTo.SelectedValuePath = "Id";
            CmbTo.DisplayMemberPath = "Name";
            CmbTo.ItemsSource = classFolder.dbClass.entities.Airport.Where(x => x.Name != CmbFrom.Text).ToList();
            
        }

        private void CmbTo_DropDownClosed(object sender, EventArgs e)
        {
            CmbFrom.SelectedValuePath = "Id";
            CmbFrom.DisplayMemberPath = "Name";
            CmbFrom.ItemsSource = classFolder.dbClass.entities.Airport.Where(x => x.Name != CmbTo.Text).ToList();
        }

        public List<dbFolder.Schedule> sch = new List<dbFolder.Schedule>();
        private void BtnApply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sch = classFolder.dbClass.entities.Schedule.ToList();
                if (cmbBorderFrom.BorderBrush == Brushes.Green) { sch = sch.Where(x => x.Route.IdDepartureAirport == (int)CmbFrom.SelectedValue).ToList(); }
                if (cmbBorderTo.BorderBrush == Brushes.Green) { sch = sch.Where(x => x.Route.IdArrivalAirport == (int)CmbTo.SelectedValue).ToList(); }
                if (tbDate.BorderBrush == Brushes.Green) { sch = sch.Where(x => x.Date == Convert.ToDateTime(tbDate.Text)).ToList(); }
                if (tbFlNumber.BorderBrush == Brushes.Green) { sch = sch.Where(x => x.FlightNumber == tbFlNumber.Text).ToList(); }
                if (CmbSort.Text == "Date-time") { dataManager.ItemsSource = sch.OrderBy(x => x.Time).OrderBy(x => x.Date); }
                else if (CmbSort.Text == "Economy price") { dataManager.ItemsSource = sch.OrderBy(x => x.EconomyPrice); }
                else if (CmbSort.Text == "Confirmed") { dataManager.ItemsSource = sch.OrderByDescending(x => x.Confirmed); }
                //var Sort = classFolder.dbClass.entities.Schedule.Where(x => x.Route.IdDepartureAirport == (int)CmbFrom.SelectedValue && x.Route.IdArrivalAirport == (int)CmbTo.SelectedValue).OrderBy(x => x.Date).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        

        private void CmbFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cmb = (ComboBox)sender;
            if (cmb.Name == "CmbFrom") { cmbBorderFrom.BorderBrush = Brushes.Green; };
            if (cmb.Name == "CmbTo") { cmbBorderTo.BorderBrush = Brushes.Green; };
            if (cmb.Name == "CmbSort") { cmbBorderSort.BorderBrush = Brushes.Green; };
        }

        private void tbDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            var box = (TextBox)sender;
            if (Convert.ToInt32(box.Text.IndexOf(' ')) >= 0)
            {
                box.Text = "";
                MessageBox.Show("Not Space!!!");
            }
            else if (box.Text.Length < 8)
            {
                box.BorderBrush = Brushes.Red;
            }
            else if (box.Text.Length == 8)
            {
                box.Text = Convert.ToInt32(box.Text).ToString("##/##/####");
                box.BorderBrush = Brushes.Green;
            }
        }

        private void tbFlNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFlNumber.BorderBrush = Brushes.Green;
        }

        private void btnCancelSort_Click(object sender, RoutedEventArgs e)
        {
            CmbFrom.Text = null; cmbBorderFrom.BorderBrush = Brushes.Red;
            CmbTo.Text = null; cmbBorderTo.BorderBrush = Brushes.Red;
            CmbSort.Text = "Date-time";
            tbDate.Text = null; tbDate.BorderBrush = Brushes.Red;
            tbFlNumber.Text = null; tbFlNumber.BorderBrush = Brushes.Red;

            dataManager.ItemsSource = classFolder.dbClass.entities.Schedule.OrderBy(x => x.Time).OrderBy(x => x.Date).ToList();
        }

        private void btnEditFl_Click(object sender, RoutedEventArgs e)
        {
            editOrImport = "Edit";
            pageFolder.EditAndImport editAndImport = new EditAndImport();
            editAndImport.Show();
        }
    }
}
