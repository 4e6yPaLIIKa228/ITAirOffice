using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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
using ITAirOffice.Connect;

namespace ITAirOffice
{
    /// <summary>
    /// Логика взаимодействия для BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : Window
    {
        int IDcmdFrom, IDcmdIn,IDRoutes;
        public BuyTicket()
        {
            InitializeComponent();
            LoadcmbAirFrom();
            LoadcmbAirIn();
            Check();

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
            }
            else
            {
                cmbInAir.IsEnabled = true;                              
                bool resultClass = int.TryParse(cmbFromAir.SelectedValue.ToString(), out IDcmdFrom);
                cmbtimeIn.SelectedIndex = -1;

            }
            if (cmbInAir.SelectedIndex == -1)
            {
                cmbtimeFrom.IsEnabled = false;
                cmbtimeIn.IsEnabled = false;
            }
            else
            {
                cmbtimeFrom.IsEnabled = true;
                bool resultClass = int.TryParse(cmbFromAir.SelectedValue.ToString(), out IDcmdIn);
                SearchRoutes();
                SearchFlightsFrom();
                cmbtimeIn.SelectedIndex = -1;
            }           
                
        }

        public void SearchFlightsFrom()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                {
                    connection.Open();
                    string query = $@"SELECT TimeFrom FROM Flights WHERE IDRoute = {IDRoutes}";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    SDA.Fill(dt);
                    cmbtimeFrom.ItemsSource = dt.DefaultView;
                    cmbtimeFrom.DisplayMemberPath = "TimeFrom";
                    cmbInAir.SelectedValuePath = "ID";
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
                    String s = cmbtimeFrom.Text;
                    string query = $@"SELECT TimeIn FROM Flights WHERE IDRoute = {IDRoutes} and TimeFrom = '{s}' ";
                    SQLiteCommand cmd = new SQLiteCommand(query, connection);
                    SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable("Flights");
                    SDA.Fill(dt);
                    cmbtimeIn.ItemsSource = dt.DefaultView;
                    cmbtimeIn.DisplayMemberPath = "TimeIn";
                    //cmbInAir.SelectedValuePath = "ID";
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
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        IDRoutes = Convert.ToInt32(dr["ID"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex);
            }
        }

        private void cmbtimeFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SearchFlightsIn();
            cmbtimeIn.IsEnabled = true;
            cmbtimeIn.SelectedIndex = -1;
            //string theSelectedStringInBanksComboBox = (string)cmbtimeFrom.SelectedItem;
            //MessageBox.Show(theSelectedStringInBanksComboBox);

        }

        private void cmbtimeIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // Check();
           // SearchFlightsIn();
        }

        private void cmbtimeFrom_MouseMove(object sender, MouseEventArgs e)
        {
           // MessageBox.Show("");
            //SearchFlightsIn();
        }

        private void cmbtimeIn_MouseMove(object sender, MouseEventArgs e)
        {
           // SearchFlightsIn();
        }

        private void cmbtimeIn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("");
        }

        private void cmbtimeIn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SearchFlightsIn();
        }

        private void cmbInAir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }

        private void cmbFromAir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Check();
        }
    }
}
