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
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data;
using ITAirOffice.Connect;

namespace ITAirOffice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadInfoDB();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnexit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void LoadInfoDB()
        {
            {
                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
                    {
                        connection.Open();
                        string query = $@"SELECT  Flights.ID, Flights.IDRoute, Routes.Price,Planes.Model,Flights.TimeFrom,Flights.TimeIn,AirportsFrom.Adress As AdressFrom, AirportsIn.Adress  As AdressIn , StatusesFly.Status FROM Flights
                                            INNER JOIN Routes ON Flights.IDRoute  = Routes.ID

                                            INNER JOIN  Planes on Flights.IDPlane = Planes.ID
                                            INNER JOIN  StatusesFly on Flights.IDStatus = StatusesFly.ID
                                            INNER JOIN  AirportsIn on Routes.IDAirIn = AirportsIn.ID
                                            INNER JOIN  AirportsFrom on Routes.IDAirFrom = AirportsFrom.ID";
                        SQLiteCommand cmd = new SQLiteCommand(query, connection);
                        DataTable DT = new DataTable("Flights");
                        SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
                        SDA.Fill(DT);
                        dgInfo.ItemsSource = DT.DefaultView;
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex);
                }
            }
        }

        private void btnbuybulet_Click(object sender, RoutedEventArgs e)
        {
            BuyTicket Aftoriz = new BuyTicket();
            this.Close();
            Aftoriz.ShowDialog();
        }


    }
}
