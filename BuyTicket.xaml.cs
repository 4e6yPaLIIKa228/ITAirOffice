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
        int IDcmdFrom, IDcmdIn, IDRoutes;
        public BuyTicket()
        {
            InitializeComponent();
            LoadcmbAirFrom();
            LoadcmbAirIn();
            Check();
            LoadDG();
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

        public void LoadDG()
        {
            //try
            //{
            //    using (SQLiteConnection connection = new SQLiteConnection(Connection.conn))
            //    {
            //        //connection.Open();
            //        //string query = $@"";
            //        //SQLiteCommand cmd = new SQLiteCommand(query, connection);
            //        DataTable DT = new DataTable();
            //        // DataRow row;
            //        //SQLiteDataAdapter SDA = new SQLiteDataAdapter(cmd);
            //        //SDA.Fill(DT);
            //        //tst.ItemsSource = DT.DefaultView;
            //        //cmd.ExecuteNonQuery();
            //        foreach (DataRow row in DT.Rows)
            //       {
            //            //int countB = 0, countP = 0, countH = 0;

            //            for (int i = 1; i <= 20; i++)
            //            {
            //               // row = DT.NewRow();
            //               // row["A"] = i;
            //              //  row["item"] = "item " + i.ToString();
            //              //  DT.Rows.Add(row);
            //                //    string temp = Convert.ToString(row[$@"Day{i}"]);
            //                //    if (temp == "б")
            //                //    {
            //                //        countB++;
            //                //    }
            //                //    if (temp == "п")
            //                //    {
            //                //        countP++;
            //                //    }
            //                //    if (temp == "н")
            //                //    {
            //                //        countH++;
            //                //    }
            //                //}
            //                row["A"] = i;
            //                row["B"] = i;
            //                row["C"] = i;
            //                //row["SumP"] = countP;
            //                //row["SumH"] = countH;
            //            }
            //       }
            //    }
            //}
            //catch (Exception exp)
            //{
            //    MessageBox.Show(exp.Message);

            //}

            //DataTable DT = new DataTable();
            //DataTable dt = new DataTable();

            //DataRow row = dt.NewRow();
            // DataColumn col = new DataColumn();
            // DataGrid.Items.Add(new DataItem());          


            //tst.Items.Add(1);//Строчка
            // DataTable dt = new DataTable();

            // DataGridTextColumn textColumn = new DataGridTextColumn();
            //  textColumn.Header = "A";
            //textColumn.Binding = new Binding("FirstName");
            // tst.Columns.Add(textColumn);
            //for (int i = 0; i < N; i++)
            //{
            //    textColumn.Binding = new Binding("A[" + i + "]");
            //}
            //var rowData = Enumerable.Range(0, N).ToList();
            //tst.Items.Add(rowData);
            int N = 2;
            DataTable dt = new DataTable();
            dt.Columns.Add("A", typeof(int));
            dt.Columns.Add("B");
            for (int i = 0; i < N; i++)
            {
                var row = dt.NewRow();
                SolidColorBrush color = new SolidColorBrush(Colors.Red);
               
                row["A"] = i;
                string temp = Convert.ToString(row[$@"A"]);          

                row["B"] = i;

                dt.Rows.Add(row);
                //var cellInfo = tst.SelectedCells[0];
                //var content = color;
                //tst.RowBackground = Brushes.Red;
                tst.Resources["A"] = Brushes.Red;
               // tst.Columns[0].HeaderStyle = (Colors.Red);

                // tst.Items.Add(i);//Строчка
                // textColumn.Binding = new Binding(Convert.ToString(i));

                //var col = new DataGridTextColumn
                //{

                //   // Header = "A",
                //    Binding = new Binding("[" + i + "]"),
                //    IsReadOnly = true,
                //    Width = new DataGridLength(1, DataGridLengthUnitType.Star)
                //};

                // tst.Columns.Add(col);

            }
            tst.DataContext = dt;

            // tst.Columns.Add(textColumn);
            //var rowData = Enumerable.Range(0, N).ToList();
            //tst.Items.Add(rowData);
            // DataGrid tst = new DataGrid();
            // Set AutoGenerateColumns true to generate columns as per datasource.
            // tst.AutoGenerateColumns = true;
            // Finally bind the datasource to datagridview.
            //tst.DataContext = employeeData.DefaultView;



            //DataGridView dgv = new DataGridView();
            //// Set AutoGenerateColumns true to generate columns as per datasource.
            //dgv.AutoGenerateColumns = true;
            //// Finally bind the datasource to datagridview.
            //dgv.DataSource = dt;
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

        private void tst_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            DataGridRow gridRow = e.Row;
            DataTable dt = new DataTable();
            var row = dt.Rows;

            // DataRow row = (gridRow.DataContext as DataRowView).Row;
            DataTable DT = new DataTable();
            //switch (row.RowState)
            //{
            //    case row["A"] == "1";
            //        gridRow.Background = new SolidColorBrush(Colors.Green);
            //        break;
            //}           
            //int countB = 0, countP = 0, countH = 0;

            //try
            //{
            //    if (Convert.ToDouble(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[1].ToString()) > 0)
            //    {
            //        e.Row.Background = new SolidColorBrush(Colors.Red);
            //    }
            //    else if (Convert.ToDouble(((System.Data.DataRowView)(e.Row.DataContext)).Row.ItemArray[4].ToString()) < 0)
            //    {
            //        e.Row.Background = new SolidColorBrush(Colors.Yellow);
            //    }
            //    else
            //    {
            //        e.Row.Background = new SolidColorBrush(Colors.WhiteSmoke);
            //    }
            //}
            //catch
            //{
            //}

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
