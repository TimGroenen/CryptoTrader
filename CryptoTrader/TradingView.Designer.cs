namespace CryptoTrader
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
            this.TrainingStartBalanceNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BuySizePercentage = new System.Windows.Forms.NumericUpDown();
            this.CurrentBalanceLabel = new System.Windows.Forms.Label();
            this.CurrentAltBalanceLabel = new System.Windows.Forms.Label();
            this.BackTestButton = new System.Windows.Forms.Button();
            this.TotalProfitLabel = new System.Windows.Forms.Label();
            this.TotalTradesLabel = new System.Windows.Forms.Label();
            this.AverageProfitLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BackTestDate = new System.Windows.Forms.DateTimePicker();
            this.HodlProfitLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingStartBalanceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuySizePercentage)).BeginInit();
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
            this.startWebsocketButton.BackColor = System.Drawing.Color.Lime;
            this.startWebsocketButton.Location = new System.Drawing.Point(554, 4);
            this.startWebsocketButton.Name = "startWebsocketButton";
            this.startWebsocketButton.Size = new System.Drawing.Size(107, 23);
            this.startWebsocketButton.TabIndex = 1;
            this.startWebsocketButton.Text = "Start";
            this.startWebsocketButton.UseVisualStyleBackColor = false;
            this.startWebsocketButton.Click += new System.EventHandler(this.startWebsocketButton_Click);
            // 
            // stopWebsocketButton
            // 
            this.stopWebsocketButton.BackColor = System.Drawing.Color.Red;
            this.stopWebsocketButton.Location = new System.Drawing.Point(554, 30);
            this.stopWebsocketButton.Name = "stopWebsocketButton";
            this.stopWebsocketButton.Size = new System.Drawing.Size(107, 23);
            this.stopWebsocketButton.TabIndex = 2;
            this.stopWebsocketButton.Text = "Stop";
            this.stopWebsocketButton.UseVisualStyleBackColor = false;
            this.stopWebsocketButton.Click += new System.EventHandler(this.stopWebsocketButton_Click);
            // 
            // apiKeyText
            // 
            this.apiKeyText.Location = new System.Drawing.Point(91, 6);
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
            this.apiSecretText.Location = new System.Drawing.Point(91, 32);
            this.apiSecretText.Name = "apiSecretText";
            this.apiSecretText.PasswordChar = '*';
            this.apiSecretText.Size = new System.Drawing.Size(457, 20);
            this.apiSecretText.TabIndex = 5;
            // 
            // TrainingStartBalanceNum
            // 
            this.TrainingStartBalanceNum.DecimalPlaces = 8;
            this.TrainingStartBalanceNum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.TrainingStartBalanceNum.Location = new System.Drawing.Point(121, 84);
            this.TrainingStartBalanceNum.Name = "TrainingStartBalanceNum";
            this.TrainingStartBalanceNum.Size = new System.Drawing.Size(120, 20);
            this.TrainingStartBalanceNum.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Start balance (BTC):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Buy size (%):";
            // 
            // BuySizePercentage
            // 
            this.BuySizePercentage.Location = new System.Drawing.Point(121, 110);
            this.BuySizePercentage.Name = "BuySizePercentage";
            this.BuySizePercentage.Size = new System.Drawing.Size(120, 20);
            this.BuySizePercentage.TabIndex = 9;
            // 
            // CurrentBalanceLabel
            // 
            this.CurrentBalanceLabel.AutoSize = true;
            this.CurrentBalanceLabel.Location = new System.Drawing.Point(12, 150);
            this.CurrentBalanceLabel.Name = "CurrentBalanceLabel";
            this.CurrentBalanceLabel.Size = new System.Drawing.Size(35, 13);
            this.CurrentBalanceLabel.TabIndex = 11;
            this.CurrentBalanceLabel.Text = "label5";
            // 
            // CurrentAltBalanceLabel
            // 
            this.CurrentAltBalanceLabel.AutoSize = true;
            this.CurrentAltBalanceLabel.Location = new System.Drawing.Point(12, 175);
            this.CurrentAltBalanceLabel.Name = "CurrentAltBalanceLabel";
            this.CurrentAltBalanceLabel.Size = new System.Drawing.Size(35, 13);
            this.CurrentAltBalanceLabel.TabIndex = 12;
            this.CurrentAltBalanceLabel.Text = "label5";
            // 
            // BackTestButton
            // 
            this.BackTestButton.Location = new System.Drawing.Point(667, 4);
            this.BackTestButton.Name = "BackTestButton";
            this.BackTestButton.Size = new System.Drawing.Size(75, 23);
            this.BackTestButton.TabIndex = 13;
            this.BackTestButton.Text = "Backtest";
            this.BackTestButton.UseVisualStyleBackColor = true;
            this.BackTestButton.Click += new System.EventHandler(this.BackTestButton_Click);
            // 
            // TotalProfitLabel
            // 
            this.TotalProfitLabel.AutoSize = true;
            this.TotalProfitLabel.Location = new System.Drawing.Point(12, 228);
            this.TotalProfitLabel.Name = "TotalProfitLabel";
            this.TotalProfitLabel.Size = new System.Drawing.Size(35, 13);
            this.TotalProfitLabel.TabIndex = 15;
            this.TotalProfitLabel.Text = "label5";
            // 
            // TotalTradesLabel
            // 
            this.TotalTradesLabel.AutoSize = true;
            this.TotalTradesLabel.Location = new System.Drawing.Point(12, 203);
            this.TotalTradesLabel.Name = "TotalTradesLabel";
            this.TotalTradesLabel.Size = new System.Drawing.Size(35, 13);
            this.TotalTradesLabel.TabIndex = 14;
            this.TotalTradesLabel.Text = "label5";
            // 
            // AverageProfitLabel
            // 
            this.AverageProfitLabel.AutoSize = true;
            this.AverageProfitLabel.Location = new System.Drawing.Point(12, 252);
            this.AverageProfitLabel.Name = "AverageProfitLabel";
            this.AverageProfitLabel.Size = new System.Drawing.Size(35, 13);
            this.AverageProfitLabel.TabIndex = 16;
            this.AverageProfitLabel.Text = "label5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(748, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Start date:";
            // 
            // BackTestDate
            // 
            this.BackTestDate.CustomFormat = "HH:mm dd/MM/yyyy";
            this.BackTestDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BackTestDate.Location = new System.Drawing.Point(810, 6);
            this.BackTestDate.Name = "BackTestDate";
            this.BackTestDate.Size = new System.Drawing.Size(200, 20);
            this.BackTestDate.TabIndex = 18;
            // 
            // HodlProfitLabel
            // 
            this.HodlProfitLabel.AutoSize = true;
            this.HodlProfitLabel.Location = new System.Drawing.Point(12, 275);
            this.HodlProfitLabel.Name = "HodlProfitLabel";
            this.HodlProfitLabel.Size = new System.Drawing.Size(35, 13);
            this.HodlProfitLabel.TabIndex = 19;
            this.HodlProfitLabel.Text = "label5";
            // 
            // TradingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1433, 641);
            this.Controls.Add(this.HodlProfitLabel);
            this.Controls.Add(this.BackTestDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AverageProfitLabel);
            this.Controls.Add(this.TotalProfitLabel);
            this.Controls.Add(this.TotalTradesLabel);
            this.Controls.Add(this.BackTestButton);
            this.Controls.Add(this.CurrentAltBalanceLabel);
            this.Controls.Add(this.CurrentBalanceLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.BuySizePercentage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TrainingStartBalanceNum);
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
            ((System.ComponentModel.ISupportInitialize)(this.TrainingStartBalanceNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuySizePercentage)).EndInit();
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
        private System.Windows.Forms.NumericUpDown TrainingStartBalanceNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown BuySizePercentage;
        private System.Windows.Forms.Label CurrentBalanceLabel;
        private System.Windows.Forms.Label CurrentAltBalanceLabel;
        private System.Windows.Forms.Button BackTestButton;
        private System.Windows.Forms.Label TotalProfitLabel;
        private System.Windows.Forms.Label TotalTradesLabel;
        private System.Windows.Forms.Label AverageProfitLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker BackTestDate;
        private System.Windows.Forms.Label HodlProfitLabel;
    }
}

