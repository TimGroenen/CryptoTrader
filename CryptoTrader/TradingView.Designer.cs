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
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.label6 = new System.Windows.Forms.Label();
            this.LongMANum = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.ShortMANum = new System.Windows.Forms.NumericUpDown();
            this.TransactionsDataGrid = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentValueLabel = new System.Windows.Forms.Label();
            this.BackTestEndDate = new System.Windows.Forms.DateTimePicker();
            this.EndDate = new System.Windows.Forms.Label();
            this.TradeWinPercentage = new System.Windows.Forms.Label();
            this.WinTradesLabel = new System.Windows.Forms.Label();
            this.TradeLossLabel = new System.Windows.Forms.Label();
            this.MaxWinLabel = new System.Windows.Forms.Label();
            this.MaxLossLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.candleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingStartBalanceNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuySizePercentage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LongMANum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShortMANum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsDataGrid)).BeginInit();
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
            this.candleChart.Location = new System.Drawing.Point(0, 293);
            this.candleChart.Name = "candleChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Color = System.Drawing.Color.White;
            series1.CustomProperties = "PriceDownColor=Red, PointWidth=0.85, PriceUpColor=Lime";
            series1.Legend = "Legend1";
            series1.MarkerBorderColor = System.Drawing.Color.Black;
            series1.Name = "Price";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series2.Legend = "Legend1";
            series2.MarkerBorderColor = System.Drawing.Color.Black;
            series2.MarkerSize = 15;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Triangle;
            series2.Name = "Transaction";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Legend = "Legend1";
            series3.Name = "ShortMA";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Aqua;
            series4.Legend = "Legend1";
            series4.Name = "LongMA";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            this.candleChart.Series.Add(series1);
            this.candleChart.Series.Add(series2);
            this.candleChart.Series.Add(series3);
            this.candleChart.Series.Add(series4);
            this.candleChart.Size = new System.Drawing.Size(1432, 346);
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
            this.startWebsocketButton.Click += new System.EventHandler(this.StartWebsocketButton_Click);
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
            this.stopWebsocketButton.Click += new System.EventHandler(this.StopWebsocketButton_Click);
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
            this.TrainingStartBalanceNum.Location = new System.Drawing.Point(121, 56);
            this.TrainingStartBalanceNum.Name = "TrainingStartBalanceNum";
            this.TrainingStartBalanceNum.Size = new System.Drawing.Size(120, 20);
            this.TrainingStartBalanceNum.TabIndex = 7;
            this.TrainingStartBalanceNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Start balance (BTC):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Buy size (%):";
            // 
            // BuySizePercentage
            // 
            this.BuySizePercentage.Location = new System.Drawing.Point(121, 82);
            this.BuySizePercentage.Name = "BuySizePercentage";
            this.BuySizePercentage.Size = new System.Drawing.Size(120, 20);
            this.BuySizePercentage.TabIndex = 9;
            this.BuySizePercentage.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // CurrentBalanceLabel
            // 
            this.CurrentBalanceLabel.AutoSize = true;
            this.CurrentBalanceLabel.Location = new System.Drawing.Point(12, 136);
            this.CurrentBalanceLabel.Name = "CurrentBalanceLabel";
            this.CurrentBalanceLabel.Size = new System.Drawing.Size(35, 13);
            this.CurrentBalanceLabel.TabIndex = 11;
            this.CurrentBalanceLabel.Text = "label5";
            // 
            // CurrentAltBalanceLabel
            // 
            this.CurrentAltBalanceLabel.AutoSize = true;
            this.CurrentAltBalanceLabel.Location = new System.Drawing.Point(12, 161);
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
            this.TotalProfitLabel.Location = new System.Drawing.Point(12, 214);
            this.TotalProfitLabel.Name = "TotalProfitLabel";
            this.TotalProfitLabel.Size = new System.Drawing.Size(35, 13);
            this.TotalProfitLabel.TabIndex = 15;
            this.TotalProfitLabel.Text = "label5";
            // 
            // TotalTradesLabel
            // 
            this.TotalTradesLabel.AutoSize = true;
            this.TotalTradesLabel.Location = new System.Drawing.Point(12, 189);
            this.TotalTradesLabel.Name = "TotalTradesLabel";
            this.TotalTradesLabel.Size = new System.Drawing.Size(35, 13);
            this.TotalTradesLabel.TabIndex = 14;
            this.TotalTradesLabel.Text = "label5";
            // 
            // AverageProfitLabel
            // 
            this.AverageProfitLabel.AutoSize = true;
            this.AverageProfitLabel.Location = new System.Drawing.Point(12, 238);
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
            this.HodlProfitLabel.Location = new System.Drawing.Point(12, 260);
            this.HodlProfitLabel.Name = "HodlProfitLabel";
            this.HodlProfitLabel.Size = new System.Drawing.Size(35, 13);
            this.HodlProfitLabel.TabIndex = 19;
            this.HodlProfitLabel.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Long MA:";
            // 
            // LongMANum
            // 
            this.LongMANum.Location = new System.Drawing.Point(330, 82);
            this.LongMANum.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LongMANum.Name = "LongMANum";
            this.LongMANum.Size = new System.Drawing.Size(120, 20);
            this.LongMANum.TabIndex = 22;
            this.LongMANum.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(270, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Short MA:";
            // 
            // ShortMANum
            // 
            this.ShortMANum.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.ShortMANum.Location = new System.Drawing.Point(330, 56);
            this.ShortMANum.Name = "ShortMANum";
            this.ShortMANum.Size = new System.Drawing.Size(120, 20);
            this.ShortMANum.TabIndex = 20;
            this.ShortMANum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // TransactionsDataGrid
            // 
            this.TransactionsDataGrid.AllowUserToAddRows = false;
            this.TransactionsDataGrid.AllowUserToDeleteRows = false;
            this.TransactionsDataGrid.AllowUserToOrderColumns = true;
            this.TransactionsDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.TransactionsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransactionsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BuyPrice,
            this.SellPrice,
            this.Profit});
            this.TransactionsDataGrid.Location = new System.Drawing.Point(456, 58);
            this.TransactionsDataGrid.Name = "TransactionsDataGrid";
            this.TransactionsDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TransactionsDataGrid.Size = new System.Drawing.Size(965, 229);
            this.TransactionsDataGrid.TabIndex = 25;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // BuyPrice
            // 
            this.BuyPrice.HeaderText = "BuyPrice";
            this.BuyPrice.Name = "BuyPrice";
            // 
            // SellPrice
            // 
            this.SellPrice.HeaderText = "SellPrice";
            this.SellPrice.Name = "SellPrice";
            // 
            // Profit
            // 
            this.Profit.HeaderText = "Profit";
            this.Profit.Name = "Profit";
            // 
            // CurrentValueLabel
            // 
            this.CurrentValueLabel.AutoSize = true;
            this.CurrentValueLabel.Location = new System.Drawing.Point(12, 114);
            this.CurrentValueLabel.Name = "CurrentValueLabel";
            this.CurrentValueLabel.Size = new System.Drawing.Size(35, 13);
            this.CurrentValueLabel.TabIndex = 26;
            this.CurrentValueLabel.Text = "label5";
            // 
            // BackTestEndDate
            // 
            this.BackTestEndDate.CustomFormat = "HH:mm dd/MM/yyyy";
            this.BackTestEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BackTestEndDate.Location = new System.Drawing.Point(1080, 6);
            this.BackTestEndDate.Name = "BackTestEndDate";
            this.BackTestEndDate.Size = new System.Drawing.Size(200, 20);
            this.BackTestEndDate.TabIndex = 28;
            // 
            // EndDate
            // 
            this.EndDate.AutoSize = true;
            this.EndDate.Location = new System.Drawing.Point(1018, 9);
            this.EndDate.Name = "EndDate";
            this.EndDate.Size = new System.Drawing.Size(53, 13);
            this.EndDate.TabIndex = 27;
            this.EndDate.Text = "End date:";
            // 
            // TradeWinPercentage
            // 
            this.TradeWinPercentage.AutoSize = true;
            this.TradeWinPercentage.Location = new System.Drawing.Point(270, 114);
            this.TradeWinPercentage.Name = "TradeWinPercentage";
            this.TradeWinPercentage.Size = new System.Drawing.Size(35, 13);
            this.TradeWinPercentage.TabIndex = 29;
            this.TradeWinPercentage.Text = "label5";
            // 
            // WinTradesLabel
            // 
            this.WinTradesLabel.AutoSize = true;
            this.WinTradesLabel.Location = new System.Drawing.Point(270, 136);
            this.WinTradesLabel.Name = "WinTradesLabel";
            this.WinTradesLabel.Size = new System.Drawing.Size(35, 13);
            this.WinTradesLabel.TabIndex = 30;
            this.WinTradesLabel.Text = "label5";
            // 
            // TradeLossLabel
            // 
            this.TradeLossLabel.AutoSize = true;
            this.TradeLossLabel.Location = new System.Drawing.Point(270, 161);
            this.TradeLossLabel.Name = "TradeLossLabel";
            this.TradeLossLabel.Size = new System.Drawing.Size(35, 13);
            this.TradeLossLabel.TabIndex = 31;
            this.TradeLossLabel.Text = "label5";
            // 
            // MaxWinLabel
            // 
            this.MaxWinLabel.AutoSize = true;
            this.MaxWinLabel.Location = new System.Drawing.Point(270, 189);
            this.MaxWinLabel.Name = "MaxWinLabel";
            this.MaxWinLabel.Size = new System.Drawing.Size(35, 13);
            this.MaxWinLabel.TabIndex = 32;
            this.MaxWinLabel.Text = "label5";
            // 
            // MaxLossLabel
            // 
            this.MaxLossLabel.AutoSize = true;
            this.MaxLossLabel.Location = new System.Drawing.Point(270, 214);
            this.MaxLossLabel.Name = "MaxLossLabel";
            this.MaxLossLabel.Size = new System.Drawing.Size(35, 13);
            this.MaxLossLabel.TabIndex = 33;
            this.MaxLossLabel.Text = "label5";
            // 
            // TradingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(1433, 641);
            this.Controls.Add(this.MaxLossLabel);
            this.Controls.Add(this.MaxWinLabel);
            this.Controls.Add(this.TradeLossLabel);
            this.Controls.Add(this.WinTradesLabel);
            this.Controls.Add(this.TradeWinPercentage);
            this.Controls.Add(this.BackTestEndDate);
            this.Controls.Add(this.EndDate);
            this.Controls.Add(this.CurrentValueLabel);
            this.Controls.Add(this.TransactionsDataGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LongMANum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ShortMANum);
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
            ((System.ComponentModel.ISupportInitialize)(this.LongMANum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShortMANum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransactionsDataGrid)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown LongMANum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown ShortMANum;
        private System.Windows.Forms.DataGridView TransactionsDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profit;
        private System.Windows.Forms.Label CurrentValueLabel;
        private System.Windows.Forms.DateTimePicker BackTestEndDate;
        private System.Windows.Forms.Label EndDate;
        private System.Windows.Forms.Label TradeWinPercentage;
        private System.Windows.Forms.Label WinTradesLabel;
        private System.Windows.Forms.Label TradeLossLabel;
        private System.Windows.Forms.Label MaxWinLabel;
        private System.Windows.Forms.Label MaxLossLabel;
    }
}

