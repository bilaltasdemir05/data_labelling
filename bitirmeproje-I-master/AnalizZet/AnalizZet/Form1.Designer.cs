namespace AnalizZet
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lineChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dGV = new System.Windows.Forms.DataGridView();
            this.veriAl = new System.Windows.Forms.Button();
            this.basaAl = new System.Windows.Forms.Button();
            this.saniyeLabel = new System.Windows.Forms.Label();
            this.grafikCiz = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lineChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lineChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lineChart3 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rotaCiz = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart3)).BeginInit();
            this.SuspendLayout();
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(13, 13);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(285, 547);
            this.mediaPlayer.TabIndex = 0;
            // 
            // lineChart
            // 
            chartArea5.Name = "ChartArea1";
            this.lineChart.ChartAreas.Add(chartArea5);
            this.lineChart.Cursor = System.Windows.Forms.Cursors.Default;
            legend5.Name = "Legend1";
            this.lineChart.Legends.Add(legend5);
            this.lineChart.Location = new System.Drawing.Point(304, 12);
            this.lineChart.Name = "lineChart";
            this.lineChart.Size = new System.Drawing.Size(475, 250);
            this.lineChart.TabIndex = 1;
            this.lineChart.Text = "chart1";
            this.lineChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lineChart_MouseClick);
            this.lineChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lineChart_MouseMove);
            // 
            // dGV
            // 
            this.dGV.AllowUserToOrderColumns = true;
            this.dGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV.Location = new System.Drawing.Point(13, 566);
            this.dGV.Name = "dGV";
            this.dGV.ReadOnly = true;
            this.dGV.Size = new System.Drawing.Size(1163, 136);
            this.dGV.TabIndex = 2;
            // 
            // veriAl
            // 
            this.veriAl.Location = new System.Drawing.Point(1286, 9);
            this.veriAl.Name = "veriAl";
            this.veriAl.Size = new System.Drawing.Size(52, 23);
            this.veriAl.TabIndex = 3;
            this.veriAl.Text = "Devam";
            this.veriAl.UseVisualStyleBackColor = true;
            this.veriAl.Click += new System.EventHandler(this.veriAl_Click);
            // 
            // basaAl
            // 
            this.basaAl.Location = new System.Drawing.Point(1286, 38);
            this.basaAl.Name = "basaAl";
            this.basaAl.Size = new System.Drawing.Size(52, 23);
            this.basaAl.TabIndex = 6;
            this.basaAl.Text = "Durdur";
            this.basaAl.UseVisualStyleBackColor = true;
            this.basaAl.Click += new System.EventHandler(this.basaAl_Click);
            // 
            // saniyeLabel
            // 
            this.saniyeLabel.AutoSize = true;
            this.saniyeLabel.Location = new System.Drawing.Point(1176, 74);
            this.saniyeLabel.Name = "saniyeLabel";
            this.saniyeLabel.Size = new System.Drawing.Size(0, 13);
            this.saniyeLabel.TabIndex = 7;
            // 
            // grafikCiz
            // 
            this.grafikCiz.Location = new System.Drawing.Point(1286, 69);
            this.grafikCiz.Name = "grafikCiz";
            this.grafikCiz.Size = new System.Drawing.Size(52, 51);
            this.grafikCiz.TabIndex = 8;
            this.grafikCiz.Text = "Ayrı Grafik Çiz";
            this.grafikCiz.UseVisualStyleBackColor = true;
            this.grafikCiz.Click += new System.EventHandler(this.grafikCiz_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lineChart1
            // 
            chartArea6.Name = "ChartArea1";
            this.lineChart1.ChartAreas.Add(chartArea6);
            this.lineChart1.Cursor = System.Windows.Forms.Cursors.Default;
            legend6.Name = "Legend1";
            this.lineChart1.Legends.Add(legend6);
            this.lineChart1.Location = new System.Drawing.Point(304, 294);
            this.lineChart1.Name = "lineChart1";
            this.lineChart1.Size = new System.Drawing.Size(475, 250);
            this.lineChart1.TabIndex = 9;
            this.lineChart1.Text = "chart1";
            this.lineChart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lineChart1_MouseClick);
            // 
            // lineChart2
            // 
            chartArea7.Name = "ChartArea1";
            this.lineChart2.ChartAreas.Add(chartArea7);
            this.lineChart2.Cursor = System.Windows.Forms.Cursors.Default;
            legend7.Name = "Legend1";
            this.lineChart2.Legends.Add(legend7);
            this.lineChart2.Location = new System.Drawing.Point(803, 13);
            this.lineChart2.Name = "lineChart2";
            this.lineChart2.Size = new System.Drawing.Size(475, 250);
            this.lineChart2.TabIndex = 10;
            this.lineChart2.Text = "chart1";
            this.lineChart2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lineChart2_MouseClick);
            // 
            // lineChart3
            // 
            chartArea8.Name = "ChartArea1";
            this.lineChart3.ChartAreas.Add(chartArea8);
            this.lineChart3.Cursor = System.Windows.Forms.Cursors.Default;
            legend8.Name = "Legend1";
            this.lineChart3.Legends.Add(legend8);
            this.lineChart3.Location = new System.Drawing.Point(803, 294);
            this.lineChart3.Name = "lineChart3";
            this.lineChart3.Size = new System.Drawing.Size(475, 250);
            this.lineChart3.TabIndex = 11;
            this.lineChart3.Text = "chart1";
            this.lineChart3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lineChart3_MouseClick);
            // 
            // rotaCiz
            // 
            this.rotaCiz.Location = new System.Drawing.Point(1286, 126);
            this.rotaCiz.Name = "rotaCiz";
            this.rotaCiz.Size = new System.Drawing.Size(52, 23);
            this.rotaCiz.TabIndex = 12;
            this.rotaCiz.Text = "Rota Çiz";
            this.rotaCiz.UseVisualStyleBackColor = true;
            this.rotaCiz.Click += new System.EventHandler(this.rotaCiz_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.rotaCiz);
            this.Controls.Add(this.lineChart3);
            this.Controls.Add(this.lineChart2);
            this.Controls.Add(this.lineChart1);
            this.Controls.Add(this.grafikCiz);
            this.Controls.Add(this.saniyeLabel);
            this.Controls.Add(this.basaAl);
            this.Controls.Add(this.veriAl);
            this.Controls.Add(this.dGV);
            this.Controls.Add(this.lineChart);
            this.Controls.Add(this.mediaPlayer);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Veri Etiketle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineChart3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart;
        private System.Windows.Forms.DataGridView dGV;
        private System.Windows.Forms.Button veriAl;
        private System.Windows.Forms.Button basaAl;
        private System.Windows.Forms.Label saniyeLabel;
        private System.Windows.Forms.Button grafikCiz;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart2;
        private System.Windows.Forms.DataVisualization.Charting.Chart lineChart3;
        private System.Windows.Forms.Button rotaCiz;
    }
}

