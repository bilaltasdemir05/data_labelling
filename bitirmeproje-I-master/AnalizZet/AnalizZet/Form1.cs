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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        System.IO.StreamReader StreamReader;
        StreamWriter streamWriter;
        string[] columnN, degerler, saniyeD, xdegerD, satirD;
        DataTable dt = new DataTable();
        DataRow dr;
        string satir, biOnceki, saniyeler, xdeger, satirDegerleri, satirYaz = "0";
        int sayac = 1, sayacB = 100, buton = 0;
        Point? positionn = null;
        ToolTip toolTip = new ToolTip();
        double saniye = 1.0, currentSaniye;
        double[] columnAccX;
        double[] columnAccY;
        double[] columnAccZ;
        public string veriYolu { get; set; }
        public string videoYolu { get; set; }
        public string kayitYeri { get; set; }
        public string etiketDosyaAdi { get; set; }
        int xa, saniyeTut, i = 0, sat = 1, minn = 0, maxx = 0;

        private void rotaCiz_Click(object sender, EventArgs e)
        {
            Harita harita = new Harita();
            harita.Show();
        }

        private void lineChart3_MouseClick(object sender, MouseEventArgs e)
        {
            chartClick(e,lineChart3);
        }

        private void lineChart1_MouseClick(object sender, MouseEventArgs e)
        {
            chartClick(e,lineChart1);
        }

        private void lineChart2_MouseClick(object sender, MouseEventArgs e)
        {
            chartClick(e,lineChart2);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Directory.CreateDirectory(kayitYeri);
            streamWriter = new StreamWriter(etiketDosyaAdi);
            //if (Directory.Exists("C:/Users/mmhus/Desktop/EtiketliVeri.txt"))
            //{
            //    MessageBox.Show("Bu isimde bir dosya daha önceden oluşturulmuş");
            //}
            if (satirDegerleri != null)
            {
                satirD = satirDegerleri.Split('-');
            }
            else
            {
                satirD = new string[1];
                sat = 1;
            }
            streamWriter.WriteLine("AccX;AccY;AccZ;GraX;GraY;GraZ;LAX;LAY;LAZ;GyroX;GyroY;GyroZ;Time2;Etiket");
            for (int k = 0; k < sayac - 2; k++)
            {
                if (sat != satirD.Length && satirD != null)
                {
                    if (k + 1 == Convert.ToInt32(satirD[sat]))
                    {
                        switch (satirD[sat + 2])
                        {
                            case "Çukur":
                                satirYaz = "Çukur;";
                                break;
                            case "Kasis":
                                satirYaz = "Kasis;";
                                break;
                            case "Rampa":
                                satirYaz = "Rampa;";
                                break;
                            case "Viraj":
                                satirYaz = "Viraj;";
                                break;
                            case "Şerit Değiştirme":
                                satirYaz = "Şerit;";
                                break;
                            case "Ani İvmelenme":
                                satirYaz = "İvme;";
                                break;
                            case "Diğer":
                                satirYaz = "Diğer;";
                                break;
                            default:
                                break;
                        }

                    }
                    else if (k + 2 == Convert.ToInt32(satirD[sat + 1]))
                    {
                        sat += 3;
                        satirYaz = "0;";
                    }
                }
                streamWriter.WriteLine(dGV.Rows[k].Cells["AccX"].Value.ToString() + ";" + dGV.Rows[k].Cells["AccY"].Value.ToString() + ";" + dGV.Rows[k].Cells["AccZ"].Value.ToString()
                    + ";" + dGV.Rows[k].Cells["GraX"].Value.ToString() + ";" + dGV.Rows[k].Cells["GraY"].Value.ToString() + ";" + dGV.Rows[k].Cells["GraZ"].Value.ToString()
                    + ";" + dGV.Rows[k].Cells["LAX"].Value.ToString() + ";" + dGV.Rows[k].Cells["LAY"].Value.ToString() + ";" + dGV.Rows[k].Cells["LAZ"].Value.ToString()
                    + ";" + dGV.Rows[k].Cells["GyroX"].Value.ToString() + ";" + dGV.Rows[k].Cells["GyroY"].Value.ToString() + ";" + dGV.Rows[k].Cells["GyroZ"].Value.ToString()
                    + ";" + dGV.Rows[k].Cells["Time2"].Value.ToString() + ";" + satirYaz);
            }
            streamWriter.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i == 0)
            {
                if(xdeger != null)
                {
                    sayac--;
                    xdeger += sayac.ToString();
                    xdegerD = xdeger.Split(';');
                    int das = xdegerD.Length;
                    i++;
                    mediaPlayer.Ctlcontrols.currentPosition = 0.0;
                    mediaPlayer.Ctlcontrols.play();
                }
                //columnAccX = new double[dGV.Rows.Count];
                //columnAccX= (from DataGridViewRow row in dGV.Rows
                //               where row.Cells["AccX"].FormattedValue.ToString() != string.Empty
                //               select Double.Parse(row.Cells["AccX"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)).ToArray();
                //columnAccY = new double[dGV.Rows.Count];
                //columnAccY = (from DataGridViewRow row in dGV.Rows
                //              where row.Cells["AccY"].FormattedValue.ToString() != string.Empty
                //              select Double.Parse(row.Cells["AccY"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)).ToArray();
                //columnAccZ = new double[dGV.Rows.Count];
                //columnAccZ = (from DataGridViewRow row in dGV.Rows
                //              where row.Cells["AccZ"].FormattedValue.ToString() != string.Empty
                //              select double.Parse(row.Cells["AccZ"].Value.ToString(), System.Globalization.CultureInfo.InvariantCulture)).ToArray();

                //minn = Convert.ToInt32(columnAccX.Min());
                //maxx = Convert.ToInt32(columnAccY.Max());
                //if(minn > Convert.ToInt32(columnAccY.Min()))
                //{
                //    minn = Convert.ToInt32(columnAccY.Min());
                //}
                //else if(minn > Convert.ToInt32(columnAccZ.Min()))
                //{
                //    minn = Convert.ToInt32(columnAccZ.Min());
                //}

            }
            else
            {
                if (3 == Convert.ToInt32(mediaPlayer.playState))
                {
                    if (i < xdegerD.Length - 1)
                    {
                        //dGV.CurrentCell = dGV.Rows[Convert.ToInt32(xdegerD[i])].Cells[0];
                        //dGV.FirstDisplayedScrollingRowIndex = Convert.ToInt32(xdegerD[i]);
                        //lineChart.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                        //lineChart.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart1.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                        //lineChart1.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart2.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                        //lineChart2.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart3.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                        //lineChart3.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        if (i > girisEkrani.farkk)
                            mediaPlayer.Ctlcontrols.currentPosition = i - girisEkrani.farkk;
                        lineChart.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        lineChart.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        lineChart1.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        lineChart1.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        lineChart2.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        lineChart2.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        lineChart3.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        lineChart3.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        dGV.CurrentCell = dGV.Rows[Convert.ToInt32(xdegerD[i])].Cells[0];
                        dGV.FirstDisplayedScrollingRowIndex = Convert.ToInt32(xdegerD[i]);
                        lineChart.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        lineChart1.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        lineChart2.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        lineChart3.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));

                        i++;
                    }

                    else
                    {
                        timer1.Stop();
                        lineChart.ChartAreas[0].CursorX.SelectionStart = 0;
                        lineChart.ChartAreas[0].CursorX.SelectionEnd = 0;
                        lineChart1.ChartAreas[0].CursorX.SelectionStart = 0;
                        lineChart1.ChartAreas[0].CursorX.SelectionEnd = 0;
                        lineChart2.ChartAreas[0].CursorX.SelectionStart = 0;
                        lineChart2.ChartAreas[0].CursorX.SelectionEnd = 0;
                        lineChart3.ChartAreas[0].CursorX.SelectionStart = 0;
                        lineChart3.ChartAreas[0].CursorX.SelectionEnd = 0;
                        mediaPlayer.Ctlcontrols.pause();

                        //mediaPlayer.Ctlcontrols.pause();
                        //if(i>=2)
                        //    mediaPlayer.Ctlcontrols.currentPosition = i-2;
                        //mediaPlayer.Ctlcontrols.play();
                        //lineChart.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i])+2, Convert.ToDouble(xdegerD[i]) + 202);
                        //lineChart1.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart1.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        //lineChart2.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart2.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        //lineChart3.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                        //lineChart3.ChartAreas[0].AxisX.ScaleView.Zoom(Convert.ToDouble(xdegerD[i]) + 2, Convert.ToDouble(xdegerD[i]) + 202);
                        //dGV.CurrentCell = dGV.Rows[Convert.ToInt32(xdegerD[i])].Cells[0];
                        //dGV.FirstDisplayedScrollingRowIndex = Convert.ToInt32(xdegerD[i]);
                        //lineChart.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        //lineChart1.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        //lineChart2.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                        //lineChart3.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), Convert.ToInt32(xdegerD[i + 1]));
                    }
                    //dGV.Rows[Convert.ToInt32(xdegerD[i])].Selected = true;
                }
                else
                {
                    dGV.CurrentCell = dGV.Rows[Convert.ToInt32(xdegerD[i])].Cells[0];
                    dGV.FirstDisplayedScrollingRowIndex = Convert.ToInt32(xdegerD[i]);
                    lineChart.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                    lineChart.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                    lineChart1.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                    lineChart1.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                    lineChart2.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                    lineChart2.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                    lineChart3.ChartAreas[0].CursorX.SetSelectionPosition(Convert.ToInt32(xdegerD[i]), sayac);
                    lineChart3.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            grafikCizme();
            //mediaPlayer.Ctlcontrols.pause();
        }

        private void grafikCiz_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Form3 fomr3 = new Form3();
            fomr3.Show();
        }

        private void basaAl_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            lineChart.ChartAreas[0].CursorX.SelectionStart = 0;
            lineChart.ChartAreas[0].CursorX.SelectionEnd = 0;
            lineChart1.ChartAreas[0].CursorX.SelectionStart = 0;
            lineChart1.ChartAreas[0].CursorX.SelectionEnd = 0;
            lineChart2.ChartAreas[0].CursorX.SelectionStart = 0;
            lineChart2.ChartAreas[0].CursorX.SelectionEnd = 0;
            lineChart3.ChartAreas[0].CursorX.SelectionStart = 0;
            lineChart3.ChartAreas[0].CursorX.SelectionEnd = 0;
            mediaPlayer.Ctlcontrols.pause();
            
        }

        private void lineChart_MouseClick(object sender, MouseEventArgs e)
        {
            chartClick(e,lineChart);

        }
        private void lineChart_MouseMove(object sender, MouseEventArgs e)
        {
            //if (positionn.HasValue && e.Location != positionn)
            //{
            //    toolTip.RemoveAll();
            //    positionn = null;
            //}
            //var pos = e.Location;
            //positionn = pos;
            //var results = lineChart.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);
            //foreach (var result in results)
            //{
            //    if (result.ChartElementType == ChartElementType.PlottingArea)
            //    {
            //        var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
            //        var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);

            //        toolTip.Show("X:" + xVal + "-Y:" + yVal, this.lineChart, e.Location.X, e.Location.Y - 15);
            //    }
            //}
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.L && !e.Equals(null))
            //{
            //    sayacB += Int32.Parse(textBox1.Text);
            //}
            //else if (e.KeyData == Keys.K)
            //{
            //}
        }

        private void veriAl_Click(object sender, EventArgs e)
        {
            //i = 0;
            mediaPlayer.Ctlcontrols.play();
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader = new System.IO.StreamReader(veriYolu);
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
                if ("" != satir)
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
            }
            StreamReader.Close();
            dGV.DataSource = dt;

            //lineChart.ChartAreas[0].AxisY.ScaleView.Zoom(-6, 13);
            lineChart.ChartAreas[0].AxisX.ScaleView.Zoom(0, 200);
            lineChart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            lineChart.ChartAreas[0].CursorX.IsUserEnabled = true;
            lineChart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //////////////////////////////////////////////////////////////
            //lineChart1.ChartAreas[0].AxisY.ScaleView.Zoom(-10, 15);
            lineChart1.ChartAreas[0].AxisX.ScaleView.Zoom(0, 200);
            lineChart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            lineChart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            lineChart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            ///////////////////////////////////////////////////////////////

            //lineChart2.ChartAreas[0].AxisY.ScaleView.Zoom(-10, 15);
            lineChart2.ChartAreas[0].AxisX.ScaleView.Zoom(0, 200);
            lineChart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            lineChart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            lineChart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //////////////////////////////////////////////////////////////
            //lineChart3.ChartAreas[0].AxisY.ScaleView.Zoom(-10, 15);
            lineChart3.ChartAreas[0].AxisX.ScaleView.Zoom(0, 200);
            lineChart3.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            lineChart3.ChartAreas[0].CursorX.IsUserEnabled = true;
            lineChart3.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            mediaPlayer.URL = videoYolu;
            mediaPlayer.settings.rate = 1.0;
        }

        private void grafikCizme()
        {
            buton++;
            timer1.Start();
            //mediaPlayer.Ctlcontrols.currentPosition = 0.0;
            //mediaPlayer.settings.rate = Double.Parse(textBox1.Text);
            saniyeLabel.Text = "";
            saniye = 1.0;
            xdeger = "0;";
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
            if (buton > 1)
            {
                lineChart.Series.Clear();
                yazılan = 0;
                currentSaniye = 0;
            }

            while (yazılan < sayac - 1)
            {
                seriesAccX.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["AccX"].Value);
                seriesAccY.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["AccY"].Value);
                seriesAccZ.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["AccZ"].Value);
                seriesGraX.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GraX"].Value);
                seriesGraY.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GraY"].Value);
                seriesGraZ.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GraZ"].Value);
                seriesLAX.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["LAX"].Value);
                seriesLAY.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["LAY"].Value);
                seriesLAZ.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["LAZ"].Value);
                seriesGyroX.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GyroX"].Value);
                seriesGyroY.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GyroY"].Value);
                seriesGyroZ.Points.AddXY(dGV.Rows[yazılan].Cells["Sayac"].Value, dGV.Rows[yazılan].Cells["GyroZ"].Value);

                lineChart.Series.Add(seriesAccX);
                lineChart.Series.Add(seriesAccY);
                lineChart.Series.Add(seriesAccZ);
                lineChart2.Series.Add(seriesGraX);
                lineChart2.Series.Add(seriesGraY);
                lineChart2.Series.Add(seriesGraZ);
                lineChart1.Series.Add(seriesLAX);
                lineChart1.Series.Add(seriesLAY);
                lineChart1.Series.Add(seriesLAZ);
                lineChart3.Series.Add(seriesGyroX);
                lineChart3.Series.Add(seriesGyroY);
                lineChart3.Series.Add(seriesGyroZ);

                if (dGV.RowCount != yazılan + 2)
                {
                    if (dGV.Rows[yazılan].Cells["Time2"].Value.ToString() != dGV.Rows[yazılan + 1].Cells["Time2"].Value.ToString())
                    {
                        //mediaPlayer.Ctlcontrols.pause();
                        //a = Convert.ToInt32(mediaPlayer.Ctlcontrols.currentPosition);
                        //saniyeLabel.Text += a.ToString();
                        //biOnceki = mediaPlayer.Ctlcontrols.currentPositionString;
                        //currentSaniye = mediaPlayer.Ctlcontrols.currentPosition;
                        //mediaPlayer.Ctlcontrols.play();
                        while (currentSaniye <= saniye)
                        {
                            if (saniye > mediaPlayer.Ctlcontrols.currentItem.duration)
                                break;
                            currentSaniye = mediaPlayer.Ctlcontrols.currentPosition;
                        }
                        //saniyeLabel.Text += "-" + a.ToString() + "\n";
                        xdeger += (yazılan + 1).ToString() + ";";
                        //mediaPlayer.Ctlcontrols.pause();
                        //MessageBox.Show(biOnceki + "-" + mediaPlayer.Ctlcontrols.currentPositionString + "saniyeler arasındaki veri çizildi\n Devam Edilsin mi", yazılan.ToString(), MessageBoxButtons.OKCancel);
                        //form2.ShowDialog();
                        //if (form2.Response == "durdur")
                        //    break;
                        //else if (form2.Response == "isaret")
                        //    MessageBox.Show("Grafikteki aralık işaretlendi", "Bilgi");
                        saniye += 1.0;
                        //mediaPlayer.Ctlcontrols.play();
                    }
                    lineChart.Series.Clear();
                    lineChart1.Series.Clear();
                    lineChart2.Series.Clear();
                    lineChart3.Series.Clear();
                }
                yazılan++;

            }
        }
        private void chartClick(MouseEventArgs e, Chart chart)
        {
            Form2 form2 = new Form2();
            var xvalstart = chart.ChartAreas[0].CursorX.SelectionStart;
            var xvalend = chart.ChartAreas[0].CursorX.SelectionEnd;
            if (e.Button == MouseButtons.Right)
            {
                timer1.Start();
                var poos = e.Location;
                positionn = poos;
                var resuss = chart.HitTest(poos.X, poos.Y, false, ChartElementType.PlottingArea);
                foreach (var item in resuss)
                {
                    if (item.ChartElementType == ChartElementType.PlottingArea)
                    {
                        double xx = chart.ChartAreas[0].AxisX.PixelPositionToValue(poos.X);
                        xa = Convert.ToInt32(xx);
                        MessageBox.Show(xa + " satırına tıklandı");
                    }

                }
                dGV.CurrentCell = dGV.Rows[xa - 1].Cells[0];
                dGV.FirstDisplayedScrollingRowIndex = xa - 1;
                for (int i = 0; i < xdegerD.Length; i++)
                {
                    if (Int32.Parse(xdegerD[i]) >= xa)
                    {
                        saniyeTut = i;
                        break;
                    }
                }
                MessageBox.Show("Video " + saniyeTut.ToString() + " .saniyeden itibaren oynatılıyor", "Bilgi");
                mediaPlayer.Ctlcontrols.stop();
                mediaPlayer.Ctlcontrols.currentPosition = saniyeTut-2;
                mediaPlayer.Ctlcontrols.play();
                i = saniyeTut-1;
                dGV.CurrentCell = dGV.Rows[Convert.ToInt32(xdegerD[i])].Cells[0];
                dGV.FirstDisplayedScrollingRowIndex = Convert.ToInt32(xdegerD[i]);
                chart.ChartAreas[0].AxisX.ScaleView.Scroll(Convert.ToDouble(xdegerD[i]) + 2);
                i++;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (xvalstart == 0 && xvalend == 0)
                {

                }
                else
                {
                    chart.ChartAreas[0].AxisX.ScaleView.Zoom(xvalstart, xvalend);
                    DialogResult res = MessageBox.Show("Seçtiğinizi aralığı değiştirmek istermisiniz", "Bilgi", MessageBoxButtons.YesNoCancel);
                    if (res == DialogResult.Yes)
                    {
                        chart.ChartAreas[0].CursorX.SelectionStart = 0;
                        chart.ChartAreas[0].CursorX.SelectionEnd = 0;
                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(xvalstart, xvalend);
                    }
                    else if (res == DialogResult.No)
                    {
                        form2.ShowDialog();
                        satirDegerleri += "-" + xvalstart + "-" + xvalend + "-" + form2.Response;
                        MessageBox.Show("Seçilen noktalar işaretlendi\n" + xvalstart.ToString() + "-" + xvalend, form2.Response);
                    }
                    else
                    {
                        chart.ChartAreas[0].CursorX.SelectionStart = 0;
                        chart.ChartAreas[0].CursorX.SelectionEnd = 0;
                        chart.ChartAreas[0].AxisX.ScaleView.Zoom(0.0, Convert.ToDouble(sayac));
                    }
                }
            }
        }

    }
}
