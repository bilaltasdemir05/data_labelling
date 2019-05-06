using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Threading;
namespace AnalizZet
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        System.IO.StreamReader StreamReader;
        string[] columnN, degerler;
        string satir;
        int sayac = 1;
        DataTable dt = new DataTable();
        DataRow dr;
        public static string yol="";
        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            StreamReader = new System.IO.StreamReader(yol);
            columnN = StreamReader.ReadLine().Split(';');
            if (sayac == 1)
            {
                dt.Columns.Add("Sayac");
                foreach (string c in columnN)
                {
                    dt.Columns.Add(c);
                }
            }
            //if (sayacB > 100)
            //{
            //    for (int i = 1; i <= sayac - 1; i++)
            //        StreamReader.ReadLine();
            //}
            while ((satir = StreamReader.ReadLine()) != null)//&& sayac <= sayacB
            {
                dr = dt.NewRow();
                degerler = satir.Split(';');
                dr[0] = (sayac).ToString();
                for (int i = 1; i < degerler.Length + 1; i++)
                {
                    dr[i] = degerler[i - 1];
                }
                dt.Rows.Add(dr);
                sayac++;
            }
            StreamReader.Close();
            dataGridView1.DataSource = dt;

            var seriesAccX = new Series("AccX");
            var seriesAccY = new Series("AccY");
            var seriesAccZ = new Series("AccZ");
            var seriesGraX = new Series("GraX");
            var seriesGraY = new Series("GraY");
            var seriesGraZ = new Series("GraZ");
            var seriesLAX = new Series("LAX");
            var seriesLAY = new Series("LAY");
            var seriesLAZ = new Series("LAZ");
            var seriesGyroX = new Series("GyroX");
            var seriesGyroY = new Series("GyroY");
            var seriesGyroZ = new Series("GyroZ");

            seriesAccX.ChartType = SeriesChartType.Line;
            seriesAccY.ChartType = SeriesChartType.Line;
            seriesAccZ.ChartType = SeriesChartType.Line;
            seriesGraX.ChartType = SeriesChartType.Line;
            seriesGraY.ChartType = SeriesChartType.Line;
            seriesGraZ.ChartType = SeriesChartType.Line;
            seriesLAX.ChartType = SeriesChartType.Line;
            seriesLAY.ChartType = SeriesChartType.Line;
            seriesLAZ.ChartType = SeriesChartType.Line;
            seriesGyroX.ChartType = SeriesChartType.Line;
            seriesGyroY.ChartType = SeriesChartType.Line;
            seriesGyroZ.ChartType = SeriesChartType.Line;
            int yazılan = 0;


            while (yazılan < sayac - 1)
            {
                seriesAccX.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["AccX"].Value);
                seriesAccY.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["AccY"].Value);
                seriesAccZ.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["AccZ"].Value);
                seriesGraX.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GraX"].Value);
                seriesGraY.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GraY"].Value);
                seriesGraZ.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GraZ"].Value);
                seriesLAX.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["LAX"].Value);
                seriesLAY.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["LAY"].Value);
                seriesLAZ.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["LAZ"].Value);
                seriesGyroX.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GyroX"].Value);
                seriesGyroY.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GyroY"].Value);
                seriesGyroZ.Points.AddXY(dataGridView1.Rows[yazılan].Cells["Sayac"].Value, dataGridView1.Rows[yazılan].Cells["GyroZ"].Value);

                chart1.Series.Add(seriesAccX);
                chart2.Series.Add(seriesAccY);
                chart3.Series.Add(seriesAccZ);
                chart4.Series.Add(seriesGraX);
                chart5.Series.Add(seriesGraY);
                chart6.Series.Add(seriesGraZ);
                chart7.Series.Add(seriesLAX);
                chart8.Series.Add(seriesLAY);
                chart9.Series.Add(seriesLAZ);
                chart10.Series.Add(seriesGyroX);
                chart11.Series.Add(seriesGyroY);
                chart12.Series.Add(seriesGyroZ);

                if (dataGridView1.RowCount != yazılan + 2)
                {
                    chart1.Series.Clear();
                    chart2.Series.Clear();
                    chart3.Series.Clear();
                    chart4.Series.Clear();
                    chart5.Series.Clear();
                    chart6.Series.Clear();
                    chart7.Series.Clear();
                    chart8.Series.Clear();
                    chart9.Series.Clear();
                    chart10.Series.Clear();
                    chart11.Series.Clear();
                    chart12.Series.Clear();
                }
                yazılan++;
            }
        }
    }
}
