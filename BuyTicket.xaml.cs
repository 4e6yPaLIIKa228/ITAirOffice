using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ITAirOffice.Connect;

namespace ITAirOffice
{
    /// <summary>
    /// Логика взаимодействия для BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : Window
    {
        int IDcmdFrom, IDcmdIn, IDRoutes, IDFlights, proverka=1, abc=1;
        string STimeFr = null, CmbTimeIn = null, IdPlane = null, DateInPicker=null;
        DataTable dt = new DataTable();
        public BuyTicket()
        {
            InitializeComponent();
            LoadcmbAirFrom();
            Check();
            MyViewModel();
            TimeLoad();
        }

        private void Btnexit_Copy_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void LoadcmbAirFrom()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM AirportsFrom";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("AirportsFrom");
                    SDA.Fill(dt);
                    cmbFromAir.ItemsSource = dt.DefaultView;
                    cmbFromAir.DisplayMemberPath = "Adress";
                    cmbFromAir.SelectedValuePath = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        private void LoadcmbAirIn()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();
                    string query = $@"SELECT * FROM AirportsIn";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("AirportsIn");
                    SDA.Fill(dt);
                    cmbInAir.ItemsSource = dt.DefaultView;
                    cmbInAir.DisplayMemberPath = "Adress";
                    cmbInAir.SelectedValuePath = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        public void Check()
        {

            if (cmbFromAir.SelectedIndex == -1)
            {
                cmbInAir.IsEnabled = false;
                cmbrow.IsEnabled = false;
                cmbnumber.IsEnabled = false;
                dtDate.IsEnabled = false;
                cmbtimeFrom.IsEnabled = false;
                cmbtimeIn.IsEnabled = false;
            }
            else
            {
                cmbInAir.IsEnabled = true;
                bool resultClass = int.TryParse(cmbFromAir.SelectedValue.ToString(), out IDcmdFrom);
               cmbtimeIn.SelectedIndex = -1;

            }
            if (cmbInAir.SelectedIndex != -1 && cmbFromAir.SelectedIndex != -1)            
            {
                cmbtimeFrom.IsEnabled = true;
                bool resultClass = int.TryParse(cmbInAir.SelectedValue.ToString(), out IDcmdIn);               
                cmbtimeIn.SelectedIndex = -1;             
            }
            if (cmbtimeFrom.SelectedIndex != -1 && cmbInAir.SelectedIndex != -1 && cmbFromAir.SelectedIndex != -1)
            {
                cmbtimeIn.IsEnabled = true;
           
            }
            if (cmbtimeIn.SelectedIndex != -1)
            {
                dtDate.IsEnabled = true;
            }
        }

        public void SearchFlightsFrom()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();
                    SearchRoutes();
                    string query = $@"SELECT TimeFrom FROM Flights WHERE IDRoute = {IDRoutes}";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    SDA.Fill(dt);
                    cmbtimeFrom.ItemsSource = dt.DefaultView;
                    cmbtimeFrom.DisplayMemberPath = "TimeFrom";
                    cmbtimeFrom.SelectedValuePath = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }
        public void SearchFlightsIn()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();                   
                    string query = $@"SELECT TimeIn FROM Flights WHERE IDRoute = {IDRoutes} and TimeFrom = '{STimeFr}' ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    SDA.Fill(dt);
                    cmbtimeIn.ItemsSource = dt.DefaultView;
                    cmbtimeIn.DisplayMemberPath = "TimeIn";
                    cmbtimeIn.SelectedValuePath = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        public void SearchRoutes()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();
                    string query = $@"SELECT ID From Routes WHERE IDAirFrom = {IDcmdFrom} and IDAirIn = {IDcmdIn}";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataReader dr = null;
                    int proverka = 0;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        IDRoutes = Convert.ToInt32(dr["ID"].ToString());
                        proverka = 1;
                    }
                    if (proverka == 0)
                    {
                        IDRoutes = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        public void LoadDG()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {

                    connection.Open();
                    string query = $@"SELECT IDPlane FROM Flights WHERE IDRoute = {IDRoutes} and TimeFrom = '{STimeFr}' and TimeIn = '{CmbTimeIn}'";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        IdPlane = dr["IDPlane"].ToString();
                    }
                    query = $@"SELECT NumberSeats,NumberRows FROM Planes WHERE ID = {IdPlane}";
                    cmd  = new SQLiteCommand(query, connection);
                    SDA  = new SQLiteDataAdapter(cmd);
                    dr = null;
                    dr = cmd.ExecuteReader();
                    string NumberSeats = null, NumberRows = null; //1)колл в ряду 2) колл рядов
                    while (dr.Read())
                    {
                        NumberSeats = dr["NumberSeats"].ToString();
                        NumberRows = dr["NumberRows"].ToString();
                    }

                    dt.Columns.Clear();
                    dt.Clear();
                    tst.ItemsSource = null;
                    proverka = 1;
                    string FRows;
                    if (cmbrow.SelectedItem == null)
                    {
                        FRows = "A";
                    }
                    else
                    {
                        FRows = cmbrow.Items.GetItemAt(cmbrow.SelectedIndex).ToString();
                    }
                    dt.Columns.Add($@"{FRows}", typeof(int));
                    // dt.Columns.Add("B");
                   
                    for (int i = 1; i <= Convert.ToInt32(NumberSeats); i++)
                    {
                        var row = dt.NewRow();
                          row[$@"{FRows}"] = i;
                        string temp = Convert.ToString(row[$@"{FRows}"]);
                        // row["B"] = i;
                        dt.Rows.Add(row);
                    }
                    tst.DataContext = dt;
                    tst.ItemsSource = dt.DefaultView;
                    DataRowView drv = tst.Items[0] as DataRowView;
                    string aaa = drv[$@"{FRows}"].ToString();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        private void cmbtimeFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                             
            Check();
            if (cmbtimeFrom.SelectedItem != null)
            {
                try
                {
                    STimeFr = ((DataRowView)cmbtimeFrom.SelectedItem).Row.ItemArray[0].ToString();
                }
                catch
                {
                    STimeFr = null;
                }
            }
            SearchFlightsIn();
        }

        public void LoadMoney()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {

                    connection.Open();
                    string query = $@"SELECT Price FROM Routes WHERE ID = {IDRoutes}";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SQLiteDataReader dr = null;
                    string Money = null;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Money = dr["Price"].ToString();
                    }
                    lblmoney.Content = Money + "  ₽";
                    lblmoney.Visibility = Visibility.Visible;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }
        private void cmbtimeIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SearchFlightsIn();
            //Check();
            if (cmbtimeIn.SelectedItem != null)
            {
                try
                {
                    CmbTimeIn = ((DataRowView)cmbtimeIn.SelectedItem).Row.ItemArray[0].ToString();
                }
                catch
                {
                    CmbTimeIn = null;
                }
            }
            dtDate.IsEnabled = true;
        }

        private void tst_LoadingRow(object sender, DataGridRowEventArgs f)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    f.Row.Background = new SolidColorBrush(Colors.White);
                    DataRowView item = f.Row.Item as DataRowView;
                    if (item != null)
                    {
                        connection.Open();
                        DataRow row = item.Row;
                        string FRows;
                        if (cmbrow.SelectedItem == null)
                        {
                            FRows = "A";
                        }
                        else
                        {
                            FRows = cmbrow.Items.GetItemAt(cmbrow.SelectedIndex).ToString();
                        }
                        string query = $@"SELECT NumberRow FROM Passengers 
                                                WHERE Passengers.Row = '{FRows}' and NumberRow = {proverka} and DateFly = '{DateInPicker}' and IDFlights ={IDFlights};"; //
                        SQLiteDataReader dr = null;
                        SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        dr = cmd.ExecuteReader();
                        string NumerRow = null;
                        while (dr.Read())
                        {
                            NumerRow = dr["NumberRow"].ToString();
                        }
                        tst.ItemsSource = dt.DefaultView;
                        var colValue = row[$@"{FRows}"];
                        if (Convert.ToString(colValue) == Convert.ToString(NumerRow))
                        {
                            f.Row.Background = new SolidColorBrush(Colors.Red);
                        }
                        else
                        {
                            f.Row.Background = new SolidColorBrush(Colors.Green);
                        }
                        proverka++;
                    }
                    else
                    {
                        
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }
        
        public void LoadSeatsInComb()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    cmbnumber.Items.Clear();
                    connection.Open();
                    string query = $@"SELECT IDPlane FROM Flights WHERE IDRoute = {IDRoutes} and TimeFrom = '{STimeFr}' and TimeIn = '{CmbTimeIn}' ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    SQLiteDataReader dr = null;
                    dr = cmd.ExecuteReader();                    
                    while (dr.Read())
                    {
                        IdPlane = dr["IDPlane"].ToString();
                    }
                    query = $@"SELECT ID FROM Flights WHERE IDRoute = {IDRoutes} and TimeFrom = '{STimeFr}' and TimeIn = '{CmbTimeIn}'";
                    cmd = new SQLiteCommand(query, connection);
                    SDA = new SQLiteDataAdapter(cmd);
                    dr = null;
                    IDFlights = Convert.ToInt32(cmd.ExecuteScalar());
                    query = $@"SELECT NumberSeats,NumberRows FROM Planes WHERE ID = {IdPlane}";
                    cmd = new SQLiteCommand(query, connection);
                    SDA = new SQLiteDataAdapter(cmd);
                    dr = null;
                    dr = cmd.ExecuteReader();
                    string NumberSeats = null, NumberRows = null; //1)колл в ряду 2) колл рядов
                    while (dr.Read())
                    {
                        NumberSeats = dr["NumberSeats"].ToString();
                        NumberRows = dr["NumberRows"].ToString();
                    }
                    string FRows;
                    if (cmbrow.SelectedItem == null)
                    {
                        FRows = "A";
                    }
                    else
                    {
                        FRows = cmbrow.Items.GetItemAt(cmbrow.SelectedIndex).ToString();
                    }
                    cmbnumber.SelectedItem = null;
                    for (int i = 1; i<= Convert.ToInt32(NumberSeats); i++)
                    {
                        query = $@"SELECT NumberRow FROM Passengers WHERE Passengers.Row = '{FRows}' and NumberRow = {i} and DateFly = '{DateInPicker}' and IDFlights ='{IDFlights}';"; //
                        cmd = new SQLiteCommand(query, connection);
                        SDA = new SQLiteDataAdapter(cmd);
                        dr = null;
                        dr = cmd.ExecuteReader();
                        string NumerRow = "0";
                        while (dr.Read())
                        {
                            NumerRow = dr["NumberRow"].ToString();
                        }
                        if (i != Convert.ToInt32(NumerRow))
                        {
                            cmbnumber.Items.Add(i);
                        }
                        // cmbnumber.Items.Remove(2);
                    }
                    cmbnumber.SelectedIndex = -1;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }


        private void cmbnumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ComboBoxItem ComboItem = (ComboBoxItem)cmbnumber.SelectedItem;
            //string name = ComboItem.Name;
            //MessageBox.Show(name);
           // MessageBox.Show(cmbnumber.SelectedItem.ToString());
           //dell
        }
       
        // public event RoutedEventHandler btnexit_Cop;
        public void btnexit_Copy_Click(object sender, RoutedEventArgs e)
        {
            LoadDG();
            //  this.btnSelectMusicFile_Click(this.btnPlayStop, new RoutedEventArgs());
            // Test();
            // btnexit_Copy.MouseUp += new RoutedEventArgs(tst_LoadingRow);
            // DataRowView item = f.Row.Item as DataRowView;
            // if (btnexit_Copy != null) tst_LoadingRow(sender, f);
            //btnexit_Copy.Click += new EventHandler(btnexit_Copy);
            // btnexit_Copy.Click += new RoutedEventArgs((RoutedEvent), e);
        }

        private void cmbrow_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //dell
            //ComboBoxItem ComboItem = (ComboBoxItem)cmbrow.SelectedItem;
            //string name = ComboItem.Name;
            //MessageBox.Show(name);
            //string name = cmbrow.SelectionBoxItem.ToString();
            //MessageBox.Show(name);
            // string s = cmbrow.Items.GetItemAt(cmbrow.SelectedIndex).ToString();
            // MessageBox.Show(s);
            LoadSeatsInComb();
            LoadDG();
            cmbnumber.SelectedIndex = - 1;
            cmbnumber.IsEnabled = true;
        }

        private void cmbrow_Loaded(object sender, RoutedEventArgs e)
        {
            cmbrow.Items.Add("A");
            cmbrow.Items.Add("B");
        }

        private void cmbrow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           // LoadDG();
        }

        private void cmbnumber_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoadSeatsInComb();            
        }

        private void tst_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var cellInfo = tst.SelectedCells[0];
            var content = (cellInfo.Column.GetCellContent(cellInfo.Item) as TextBlock).Text;
            MessageBox.Show(Convert.ToString( content));
            cmbnumber.SelectedItem = Convert.ToInt32(content);
            int parse = tst.SelectedIndex;
            DataRowView rowView = tst.SelectedValue as DataRowView;
            MessageBox.Show("Номер стрки" + Convert.ToString(parse));
        }

        private static void OnLoadingNumberRow(DataGrid dGrid, DataGridRow row)
        {
          
        }

        private void txtFam_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }
       


        private void txtnumberpass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void txtserpass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        private void txtOtchec_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        private void cmbInAir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
            SearchFlightsFrom();
        }

        private void dtDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            cmbrow.IsEnabled = true;
            DateInPicker = dtDate.Text;
            LoadDG();
            LoadMoney();
          //  LoadDG();
        }

        private void cmbFromAir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
            LoadcmbAirIn();
            cmbrow.SelectedIndex = -1;
        }
      
        public DateTime DateStart { get; private set; }
        DataTable dtTime = new DataTable();

        //Свойство должно уведомлять об изменениях через PropertyChanged
        public DateTime DateEnd { get; private set; }


        public void MyViewModel()
        {        
            dtDate.BlackoutDates.Clear(); 
            var firstDate = DateTime.Today.AddDays(-14);
            var lastDate = DateTime.Today.AddDays(14);
            var dateCounter = DateTime.Now.AddDays(-1);
            dtDate.BlackoutDates.Add(new CalendarDateRange(firstDate, dateCounter));            
            dtDate.DisplayDateStart = firstDate;
            dtDate.DisplayDateEnd = lastDate;
        }

        public void TimeLoad()
        {
            //txtTime.Visibility = Visibility.Hidden;
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
           // timer.Tick += (s, e) => { txtTime.Text = ("Время: " + DateTime.Now.ToString("T")); };
            timer.Start();
           // txtTime.Visibility = Visibility.Visible;
            lblDate.Content = "Дата: " + (DateTime.Now.ToString("d"));
        }
    }
}
