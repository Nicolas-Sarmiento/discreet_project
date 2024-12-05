namespace discreet_project
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea25 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend25 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series25 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea26 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend26 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series26 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea27 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend27 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series27 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea28 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend28 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series28 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generationTab = new System.Windows.Forms.TabPage();
            this.tabIterations = new System.Windows.Forms.TabControl();
            this.lblIteration = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtIteration = new System.Windows.Forms.TextBox();
            this.txtinterval = new System.Windows.Forms.TextBox();
            this.txtelements = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblElements = new System.Windows.Forms.Label();
            this.generalTab = new System.Windows.Forms.TabPage();
            this.chartRestultsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.randomResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inversedResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rangedResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.repeatedResultChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tablesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.infoLabel = new System.Windows.Forms.Label();
            this.resumeResults = new System.Windows.Forms.DataGridView();
            this.resultsLabel = new System.Windows.Forms.Label();
            this.iterationTab = new System.Windows.Forms.TabPage();
            this.searchTab = new System.Windows.Forms.TabPage();
            this.allResults = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.It = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Insr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mrg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.algo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MxTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.generationTab.SuspendLayout();
            this.generalTab.SuspendLayout();
            this.chartRestultsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.randomResultChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inversedResultChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangedResultChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatedResultChart)).BeginInit();
            this.tablesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resumeResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allResults)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.CausesValidation = false;
            this.tabControl.Controls.Add(this.generationTab);
            this.tabControl.Controls.Add(this.generalTab);
            this.tabControl.Controls.Add(this.iterationTab);
            this.tabControl.Controls.Add(this.searchTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1474, 856);
            this.tabControl.TabIndex = 0;
            // 
            // generationTab
            // 
            this.generationTab.Controls.Add(this.panel1);
            this.generationTab.Controls.Add(this.tabIterations);
            this.generationTab.Controls.Add(this.lblIteration);
            this.generationTab.Location = new System.Drawing.Point(4, 22);
            this.generationTab.Name = "generationTab";
            this.generationTab.Padding = new System.Windows.Forms.Padding(3);
            this.generationTab.Size = new System.Drawing.Size(1466, 830);
            this.generationTab.TabIndex = 0;
            this.generationTab.Text = "Generación";
            this.generationTab.UseVisualStyleBackColor = true;
            // 
            // tabIterations
            // 
            this.tabIterations.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabIterations.Location = new System.Drawing.Point(3, 277);
            this.tabIterations.Name = "tabIterations";
            this.tabIterations.SelectedIndex = 0;
            this.tabIterations.Size = new System.Drawing.Size(1460, 550);
            this.tabIterations.TabIndex = 11;
            // 
            // lblIteration
            // 
            this.lblIteration.AutoSize = true;
            this.lblIteration.Location = new System.Drawing.Point(8, 261);
            this.lblIteration.Name = "lblIteration";
            this.lblIteration.Size = new System.Drawing.Size(107, 13);
            this.lblIteration.TabIndex = 10;
            this.lblIteration.Text = "Datos por iteraciones";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.Location = new System.Drawing.Point(609, 216);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(123, 23);
            this.btnStart.TabIndex = 8;
            this.btnStart.Text = "Generar";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_ClickAsync);
            // 
            // txtIteration
            // 
            this.txtIteration.Location = new System.Drawing.Point(720, 163);
            this.txtIteration.Name = "txtIteration";
            this.txtIteration.Size = new System.Drawing.Size(94, 20);
            this.txtIteration.TabIndex = 5;
            // 
            // txtinterval
            // 
            this.txtinterval.Location = new System.Drawing.Point(720, 105);
            this.txtinterval.Name = "txtinterval";
            this.txtinterval.Size = new System.Drawing.Size(94, 20);
            this.txtinterval.TabIndex = 4;
            // 
            // txtelements
            // 
            this.txtelements.Location = new System.Drawing.Point(720, 47);
            this.txtelements.Name = "txtelements";
            this.txtelements.Size = new System.Drawing.Size(94, 20);
            this.txtelements.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(517, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "número de iteraciones";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "número intervalos";
            // 
            // lblElements
            // 
            this.lblElements.AutoSize = true;
            this.lblElements.Location = new System.Drawing.Point(487, 50);
            this.lblElements.Name = "lblElements";
            this.lblElements.Size = new System.Drawing.Size(141, 13);
            this.lblElements.TabIndex = 0;
            this.lblElements.Text = "número elementos aleatorios\r\n";
            // 
            // generalTab
            // 
            this.generalTab.Controls.Add(this.chartRestultsPanel);
            this.generalTab.Controls.Add(this.tablesPanel);
            this.generalTab.Location = new System.Drawing.Point(4, 22);
            this.generalTab.Name = "generalTab";
            this.generalTab.Padding = new System.Windows.Forms.Padding(3);
            this.generalTab.Size = new System.Drawing.Size(1466, 830);
            this.generalTab.TabIndex = 5;
            this.generalTab.Text = "Resultados Generales";
            this.generalTab.UseVisualStyleBackColor = true;
            // 
            // chartRestultsPanel
            // 
            this.chartRestultsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.chartRestultsPanel.ColumnCount = 1;
            this.chartRestultsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.chartRestultsPanel.Controls.Add(this.randomResultChart, 0, 0);
            this.chartRestultsPanel.Controls.Add(this.inversedResultChart, 0, 1);
            this.chartRestultsPanel.Controls.Add(this.rangedResultChart, 0, 2);
            this.chartRestultsPanel.Controls.Add(this.repeatedResultChart, 0, 3);
            this.chartRestultsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartRestultsPanel.Location = new System.Drawing.Point(3, 3);
            this.chartRestultsPanel.Name = "chartRestultsPanel";
            this.chartRestultsPanel.RowCount = 4;
            this.chartRestultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chartRestultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chartRestultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chartRestultsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.chartRestultsPanel.Size = new System.Drawing.Size(952, 824);
            this.chartRestultsPanel.TabIndex = 6;
            // 
            // randomResultChart
            // 
            chartArea25.Name = "ChartArea1";
            this.randomResultChart.ChartAreas.Add(chartArea25);
            this.randomResultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend25.Name = "Legend1";
            this.randomResultChart.Legends.Add(legend25);
            this.randomResultChart.Location = new System.Drawing.Point(3, 3);
            this.randomResultChart.Name = "randomResultChart";
            series25.ChartArea = "ChartArea1";
            series25.Legend = "Legend1";
            series25.Name = "Series1";
            this.randomResultChart.Series.Add(series25);
            this.randomResultChart.Size = new System.Drawing.Size(946, 200);
            this.randomResultChart.TabIndex = 0;
            this.randomResultChart.Text = "chart1";
            // 
            // inversedResultChart
            // 
            chartArea26.Name = "ChartArea1";
            this.inversedResultChart.ChartAreas.Add(chartArea26);
            this.inversedResultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend26.Name = "Legend1";
            this.inversedResultChart.Legends.Add(legend26);
            this.inversedResultChart.Location = new System.Drawing.Point(3, 209);
            this.inversedResultChart.Name = "inversedResultChart";
            series26.ChartArea = "ChartArea1";
            series26.Legend = "Legend1";
            series26.Name = "Series1";
            this.inversedResultChart.Series.Add(series26);
            this.inversedResultChart.Size = new System.Drawing.Size(946, 200);
            this.inversedResultChart.TabIndex = 1;
            this.inversedResultChart.Text = "chart2";
            // 
            // rangedResultChart
            // 
            chartArea27.Name = "ChartArea1";
            this.rangedResultChart.ChartAreas.Add(chartArea27);
            this.rangedResultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend27.Name = "Legend1";
            this.rangedResultChart.Legends.Add(legend27);
            this.rangedResultChart.Location = new System.Drawing.Point(3, 415);
            this.rangedResultChart.Name = "rangedResultChart";
            series27.ChartArea = "ChartArea1";
            series27.Legend = "Legend1";
            series27.Name = "Series1";
            this.rangedResultChart.Series.Add(series27);
            this.rangedResultChart.Size = new System.Drawing.Size(946, 200);
            this.rangedResultChart.TabIndex = 2;
            this.rangedResultChart.Text = "chart3";
            // 
            // repeatedResultChart
            // 
            chartArea28.Name = "ChartArea1";
            this.repeatedResultChart.ChartAreas.Add(chartArea28);
            this.repeatedResultChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend28.Name = "Legend1";
            this.repeatedResultChart.Legends.Add(legend28);
            this.repeatedResultChart.Location = new System.Drawing.Point(3, 621);
            this.repeatedResultChart.Name = "repeatedResultChart";
            series28.ChartArea = "ChartArea1";
            series28.Legend = "Legend1";
            series28.Name = "Series1";
            this.repeatedResultChart.Series.Add(series28);
            this.repeatedResultChart.Size = new System.Drawing.Size(946, 200);
            this.repeatedResultChart.TabIndex = 3;
            this.repeatedResultChart.Text = "chart4";
            // 
            // tablesPanel
            // 
            this.tablesPanel.Controls.Add(this.infoLabel);
            this.tablesPanel.Controls.Add(this.resumeResults);
            this.tablesPanel.Controls.Add(this.resultsLabel);
            this.tablesPanel.Controls.Add(this.allResults);
            this.tablesPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.tablesPanel.Location = new System.Drawing.Point(955, 3);
            this.tablesPanel.Name = "tablesPanel";
            this.tablesPanel.Size = new System.Drawing.Size(508, 824);
            this.tablesPanel.TabIndex = 5;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(3, 0);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(297, 13);
            this.infoLabel.TabIndex = 3;
            this.infoLabel.Text = "Resumen de los resultados de los algoritmos de ordemaniento\r\n";
            // 
            // resumeResults
            // 
            this.resumeResults.AllowUserToAddRows = false;
            this.resumeResults.AllowUserToDeleteRows = false;
            this.resumeResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resumeResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.algo,
            this.typeList,
            this.minTime,
            this.avg,
            this.MxTime});
            this.resumeResults.Location = new System.Drawing.Point(3, 16);
            this.resumeResults.Name = "resumeResults";
            this.resumeResults.ReadOnly = true;
            this.resumeResults.Size = new System.Drawing.Size(500, 239);
            this.resumeResults.TabIndex = 6;
            // 
            // resultsLabel
            // 
            this.resultsLabel.AutoSize = true;
            this.resultsLabel.Location = new System.Drawing.Point(3, 258);
            this.resultsLabel.Name = "resultsLabel";
            this.resultsLabel.Size = new System.Drawing.Size(230, 13);
            this.resultsLabel.TabIndex = 4;
            this.resultsLabel.Text = "Registro de todos los tiempos de las iteraciones\r\n";
            // 
            // iterationTab
            // 
            this.iterationTab.Location = new System.Drawing.Point(4, 22);
            this.iterationTab.Name = "iterationTab";
            this.iterationTab.Size = new System.Drawing.Size(912, 830);
            this.iterationTab.TabIndex = 7;
            this.iterationTab.Text = "Resultados por iteración";
            this.iterationTab.UseVisualStyleBackColor = true;
            // 
            // searchTab
            // 
            this.searchTab.Location = new System.Drawing.Point(4, 22);
            this.searchTab.Name = "searchTab";
            this.searchTab.Padding = new System.Windows.Forms.Padding(3);
            this.searchTab.Size = new System.Drawing.Size(912, 830);
            this.searchTab.TabIndex = 6;
            this.searchTab.Text = "Búsqueda";
            this.searchTab.UseVisualStyleBackColor = true;
            // 
            // allResults
            // 
            this.allResults.AllowUserToAddRows = false;
            this.allResults.AllowUserToDeleteRows = false;
            this.allResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.It,
            this.type,
            this.Bb,
            this.Insr,
            this.mrg});
            this.allResults.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.allResults.Location = new System.Drawing.Point(3, 274);
            this.allResults.Name = "allResults";
            this.allResults.ReadOnly = true;
            this.allResults.Size = new System.Drawing.Size(502, 545);
            this.allResults.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblElements);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtelements);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.txtinterval);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtIteration);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 255);
            this.panel1.TabIndex = 12;
            // 
            // It
            // 
            this.It.HeaderText = "Iteración";
            this.It.Name = "It";
            this.It.ReadOnly = true;
            this.It.Width = 80;
            // 
            // type
            // 
            this.type.HeaderText = "Tipo lista";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 80;
            // 
            // Bb
            // 
            this.Bb.HeaderText = "Tiempo burbuja";
            this.Bb.Name = "Bb";
            this.Bb.ReadOnly = true;
            // 
            // Insr
            // 
            this.Insr.HeaderText = "Tiempo Inserción";
            this.Insr.Name = "Insr";
            this.Insr.ReadOnly = true;
            // 
            // mrg
            // 
            this.mrg.HeaderText = "Tiempo merge";
            this.mrg.Name = "mrg";
            this.mrg.ReadOnly = true;
            // 
            // algo
            // 
            this.algo.HeaderText = "Algoritmo";
            this.algo.Name = "algo";
            this.algo.ReadOnly = true;
            this.algo.Width = 80;
            // 
            // typeList
            // 
            this.typeList.HeaderText = "Tipo de lista";
            this.typeList.Name = "typeList";
            this.typeList.ReadOnly = true;
            this.typeList.Width = 80;
            // 
            // minTime
            // 
            this.minTime.HeaderText = "Tiempo mínimo (ms)";
            this.minTime.Name = "minTime";
            this.minTime.ReadOnly = true;
            // 
            // avg
            // 
            this.avg.HeaderText = "Tiempo promedio (ms)";
            this.avg.Name = "avg";
            this.avg.ReadOnly = true;
            // 
            // MxTime
            // 
            this.MxTime.HeaderText = "Tiempo máximo (ms)";
            this.MxTime.Name = "MxTime";
            this.MxTime.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 856);
            this.Controls.Add(this.tabControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algortimos de Ordenamiento";
            this.tabControl.ResumeLayout(false);
            this.generationTab.ResumeLayout(false);
            this.generationTab.PerformLayout();
            this.generalTab.ResumeLayout(false);
            this.chartRestultsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.randomResultChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inversedResultChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rangedResultChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repeatedResultChart)).EndInit();
            this.tablesPanel.ResumeLayout(false);
            this.tablesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resumeResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allResults)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generationTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblElements;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtelements;
        private System.Windows.Forms.TextBox txtinterval;
        private System.Windows.Forms.TextBox txtIteration;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblIteration;
        private System.Windows.Forms.TabControl tabIterations;
        private System.Windows.Forms.TabPage generalTab;
        private System.Windows.Forms.TabPage searchTab;
        private System.Windows.Forms.Label resultsLabel;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.TabPage iterationTab;
        private System.Windows.Forms.FlowLayoutPanel tablesPanel;
        private System.Windows.Forms.DataGridView resumeResults;
        private System.Windows.Forms.TableLayoutPanel chartRestultsPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart randomResultChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart inversedResultChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart rangedResultChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart repeatedResultChart;
        private System.Windows.Forms.DataGridView allResults;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn algo;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeList;
        private System.Windows.Forms.DataGridViewTextBoxColumn minTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn MxTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn It;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Insr;
        private System.Windows.Forms.DataGridViewTextBoxColumn mrg;
    }
}

