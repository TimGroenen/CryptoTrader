﻿namespace CryptoTrader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.candleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startWebsocketButton = new System.Windows.Forms.Button();
            this.stopWebsocketButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).BeginInit();
            this.SuspendLayout();
            // 
            // candleChart
            // 
            chartArea1.Name = "ChartArea1";
            this.candleChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.candleChart.Legends.Add(legend1);
            this.candleChart.Location = new System.Drawing.Point(12, 12);
            this.candleChart.Name = "candleChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.candleChart.Series.Add(series1);
            this.candleChart.Size = new System.Drawing.Size(1324, 303);
            this.candleChart.TabIndex = 0;
            this.candleChart.Text = "chart1";
            // 
            // startWebsocketButton
            // 
            this.startWebsocketButton.Location = new System.Drawing.Point(12, 321);
            this.startWebsocketButton.Name = "startWebsocketButton";
            this.startWebsocketButton.Size = new System.Drawing.Size(107, 23);
            this.startWebsocketButton.TabIndex = 1;
            this.startWebsocketButton.Text = "Start Websocket";
            this.startWebsocketButton.UseVisualStyleBackColor = true;
            this.startWebsocketButton.Click += new System.EventHandler(this.startWebsocketButton_Click);
            // 
            // stopWebsocketButton
            // 
            this.stopWebsocketButton.Location = new System.Drawing.Point(125, 321);
            this.stopWebsocketButton.Name = "stopWebsocketButton";
            this.stopWebsocketButton.Size = new System.Drawing.Size(75, 23);
            this.stopWebsocketButton.TabIndex = 2;
            this.stopWebsocketButton.Text = "Stop";
            this.stopWebsocketButton.UseVisualStyleBackColor = true;
            this.stopWebsocketButton.Click += new System.EventHandler(this.stopWebsocketButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 580);
            this.Controls.Add(this.stopWebsocketButton);
            this.Controls.Add(this.startWebsocketButton);
            this.Controls.Add(this.candleChart);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart candleChart;
        private System.Windows.Forms.Button startWebsocketButton;
        private System.Windows.Forms.Button stopWebsocketButton;
    }
}

