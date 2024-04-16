using System;
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
    public partial class Form4 : Form
    {
        private string value1;
        private string value2;
        public Form4(string Date, string Base)
        {
            InitializeComponent();
            this.value1 = Date;
            this.value2 = Base;

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            Title chartTitle = new Title();
            chartTitle.Text = $"Суточная активность за {value1} на базе {value2}";
            chartTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            chart1.Titles.Add(chartTitle);

            string connectionString = "Data Source=DESKTOP-MHCS1MP\\SQLEXPRESS;Initial Catalog=Telecom;Integrated Security=True";
            List<int> allHours = Enumerable.Range(0, 24).ToList();

            // Создание SQL-запроса для подсчета количества записей в каждом интервале времени
            Series series = new Series("Суточная активность");

            // Добавление всех часов на график с нулевыми значениями
            for (int hour = 1; hour <= 24; hour++)
            {
                series.Points.AddXY(hour, 0);
            }

            // Создание SQL-запроса для подсчета количества записей в каждом интервале времени
            string query = @"
    SELECT 
        DATEPART(HOUR, Время_начала) AS Hour,
        COUNT(*) AS RecordCount
    FROM 
        (SELECT Время_начала FROM Голосовой_трафик WHERE Дата = @Дата AND Номер_базы = @НомерБазы
        UNION ALL
        SELECT Время_начала FROM Передача_данных WHERE Дата = @Дата AND Номер_базы = @НомерБазы) AS CombinedData
    GROUP BY 
        DATEPART(HOUR, Время_начала)";

            // Создание подключения к базе данных и выполнение запроса
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Дата", value1);
                command.Parameters.AddWithValue("@НомерБазы", value2);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Заполнение данных из базы данных
                while (reader.Read())
                {
                    int hour = (int)reader["Hour"];
                    int recordCount = (int)reader["RecordCount"];

                    // Обновление значения точки на графике
                    series.Points[hour].YValues[0] = recordCount;
                }

                // Добавление серии на график
                chart1.Series.Add(series);
            }
        }
    }
}
