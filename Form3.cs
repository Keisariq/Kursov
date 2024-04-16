using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kursov
{
    public partial class Form3 : Form
    {
        private List<DateTime> selectedDates;
        public Form3(List<string> Dates)
        {
            InitializeComponent();
            List<DateTime> dateTimes = Dates.Select(date => DateTime.Parse(date)).ToList();
            selectedDates = dateTimes;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Title chartTitle = new Title();
            chartTitle.Text = "Голосовой трафик";
            chartTitle.Font = new Font("Arial", 12, FontStyle.Bold);

            // Добавление заголовка к элементу управления Chart
            chart1.Titles.Add(chartTitle);
            string connectionString = "Data Source=DESKTOP-MHCS1MP\\SQLEXPRESS;Initial Catalog=Telecom;Integrated Security=True";
            foreach (DateTime date in selectedDates)
            {
                string query = $"SELECT Номер_Базы, SUM(Длительность) / 60 AS Минуты " +
                               $"FROM Голосовой_трафик " +
                               $"WHERE Дата = @Date " +
                               $"GROUP BY Номер_Базы";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Date", date);

                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    // Создание серии гистограммы
                    Series series = new Series(date.ToString("dd.MM.yyyy"));
                    series.ChartType = SeriesChartType.Column;

                    // Добавление данных на график
                    foreach (DataRow row in dataTable.Rows)
                    {
                        series.Points.AddXY(row["Номер_Базы"], row["Минуты"]);
                    }

                    // Добавление серии на график
                    chart1.Series.Add(series);
                }
            }
            chart2.Series.Clear();
            Title chartTitle2 = new Title();
            chartTitle2.Text = "Трафик данных";
            chartTitle2.Font = new Font("Arial", 12, FontStyle.Bold);

            // Добавление заголовка к элементу управления Chart
            chart2.Titles.Add(chartTitle2);
            foreach (DateTime date in selectedDates)
            {
                string query2 = $"SELECT Номер_Базы, SUM(Объем_данных) AS Трафик " +
                               $"FROM Передача_данных " +
                               $"WHERE Дата = @Date " +
                               $"GROUP BY Номер_Базы";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@Date", date);

                    DataTable dataTable2 = new DataTable();
                    SqlDataAdapter dataAdapter2 = new SqlDataAdapter(command2);
                    dataAdapter2.Fill(dataTable2);

                    // Создание серии гистограммы
                    Series series = new Series(date.ToString("dd.MM.yyyy"));
                    series.ChartType = SeriesChartType.Column;

                    // Добавление данных на график
                    foreach (DataRow row in dataTable2.Rows)
                    {
                        series.Points.AddXY(row["Номер_Базы"], row["Трафик"]);
                    }

                    // Добавление серии на график
                    chart2.Series.Add(series);
                }
            }
        }
    }
}
