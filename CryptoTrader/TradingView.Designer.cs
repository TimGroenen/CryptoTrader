﻿namespace CryptoTrader
{
    partial class TradingView
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.candleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startWebsocketButton = new System.Windows.Forms.Button();
            this.stopWebsocketButton = new System.Windows.Forms.Button();
            this.apiKeyText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apiSecretText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).BeginInit();
            this.SuspendLayout();
            // 
            // candleChart
            // 
            this.candleChart.BackColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels)));
            chartArea1.AxisX.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisX.ScrollBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea1.BackColor = System.Drawing.Color.Gray;
            chartArea1.BackSecondaryColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.candleChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.candleChart.Legends.Add(legend1);
            this.candleChart.Location = new System.Drawing.Point(0, 300);
            this.candleChart.Name = "candleChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.White;
            series1.CustomProperties = "PriceDownColor=Red, PointWidth=0.85, PriceUpColor=Lime";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.Name = "Price";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.Black;
            series2.MarkerSize = 15;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series2.Name = "Transaction";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.candleChart.Series.Add(series1);
            this.candleChart.Series.Add(series2);
            this.candleChart.Size = new System.Drawing.Size(1432, 339);
            this.candleChart.TabIndex = 0;
            this.candleChart.Text = "chart1";
            // 
            // startWebsocketButton
            // 
            this.startWebsocketButton.Location = new System.Drawing.Point(542, 4);
            this.startWebsocketButton.Name = "startWebsocketButton";
            this.startWebsocketButton.Size = new System.Drawing.Size(107, 23);
            this.startWebsocketButton.TabIndex = 1;
            this.startWebsocketButton.Text = "Start Websocket";
            this.startWebsocketButton.UseVisualStyleBackColor = true;
            this.startWebsocketButton.Click += new System.EventHandler(this.startWebsocketButton_Click);
            // 
            // stopWebsocketButton
            // 
            this.stopWebsocketButton.Location = new System.Drawing.Point(542, 33);
            this.stopWebsocketButton.Name = "stopWebsocketButton";
            this.stopWebsocketButton.Size = new System.Drawing.Size(107, 23);
            this.stopWebsocketButton.TabIndex = 2;
            this.stopWebsocketButton.Text = "Stop";
            this.stopWebsocketButton.UseVisualStyleBackColor = true;
            this.stopWebsocketButton.Click += new System.EventHandler(this.stopWebsocketButton_Click);
            // 
            // apiKeyText
            // 
            this.apiKeyText.Location = new System.Drawing.Point(79, 6);
            this.apiKeyText.Name = "apiKeyText";
            this.apiKeyText.PasswordChar = '*';
            this.apiKeyText.Size = new System.Drawing.Size(457, 20);
            this.apiKeyText.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "API Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "API Secret:";
            // 
            // apiSecretText
            // 
            this.apiSecretText.Location = new System.Drawing.Point(79, 35);
            this.apiSecretText.Name = "apiSecretText";
            this.apiSecretText.PasswordChar = '*';
            this.apiSecretText.Size = new System.Drawing.Size(457, 20);
            this.apiSecretText.TabIndex = 5;
            // 
            // TradingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1433, 641);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apiSecretText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.apiKeyText);
            this.Controls.Add(this.stopWebsocketButton);
            this.Controls.Add(this.startWebsocketButton);
            this.Controls.Add(this.candleChart);
            this.Name = "TradingView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart candleChart;
        private System.Windows.Forms.Button startWebsocketButton;
        private System.Windows.Forms.Button stopWebsocketButton;
        private System.Windows.Forms.TextBox apiKeyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox apiSecretText;
    }
}
