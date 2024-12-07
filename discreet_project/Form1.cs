using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace discreet_project
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<List<List<double>>> iterationList;
        List<List<List<Stopwatch>>> times;
        List<List<List<List<TimeSpan>>>> timesSearch;
        List<List<List<long>>> searchFounds;
        Sortings sortings;
        double randomToSearch;
        int numbOfSorts = 3;
        int numberOfSearchs = 2;

        public Form1()
        {
            InitializeComponent();
          
        }

        //Accion del botón generar, luego de eso ordena
        private async void btnStart_ClickAsync(object sender, EventArgs e)
        {
            int[] inputs = validateInputs();
            if (inputs == null) { 
                return;
            }
            int elements = inputs[0];
            int intervals = inputs[1];
            int iterations = inputs[2];

            iterationList = new List<List<List<double>>>();

            btnStart.Text = "En proceso...";
            btnStart.Enabled = false;
            randomGenerateButton.Enabled = false;
            randomNumLabel.Text = "-.-";
            generalSearchDG.Visible = false;
            generalSearchChart.Visible = false;
            searchIterationTab.Visible = false;


            prgBarGeneration.Value = 0;
            var progress = new Progress<int>(percent =>
            {
                prgBarGeneration.Value = percent; // Actualiza la barra de progreso
            });

            try
            {
                tabIterations.TabPages.Clear();
                iterationList.Clear();
                await Task.Run(() =>
                {
                    for (int i = 0; i < iterations; i++)
                    {
                       generateRandomData(elements, intervals);
                    }
                });


                for (int i = 0; i < iterations; i++)
                {
                    TabPage tabPage = new TabPage();
                    TableLayoutPanel panel = generateChartPanel(iterationList[i]);
                    tabPage.Controls.Add(panel);
                    tabPage.Text = "Iteración " + (i + 1).ToString();
                    tabIterations.TabPages.Add(tabPage);
                }

                btnStart.Text = "Ordenando";
                progressPanel.Visible = true;

                await Task.Run(() =>
                {
                    getSortingResults(progress);
                });
                generateResultGraphs();

                btnStart.Text = "Generar";
            }
            catch (Exception ex) {
            }
            finally
            {
                btnStart.Enabled = true;
                randomGenerateButton.Enabled = true;
                progressPanel.Visible = false;
            }
        }



        // Acción del botón de buscar en las listas
        private async void randomGenerateButton_Click(object sender, EventArgs e)
        {
            randomNumLabel.Text = "-.-";
            await Task.Delay(100);
            randomToSearch = random.NextDouble();
            randomToSearch *= 10;
            randomToSearch = Math.Floor(randomToSearch);
            randomToSearch /= 10;
            randomNumLabel.Text = randomToSearch.ToString("F1");

            if( iterationList.Count < 0) { return; }

            randomGenerateButton.Enabled= false;
            try
            {
                await Task.Run(() =>
                {
                    getSearchingResults();
                });
                Console.WriteLine(timesSearch[0].Count);
                generateSearchResultGraph();
                genertateGeneralSearchResults();

            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                randomGenerateButton.Enabled = true;
                generalSearchDG.Visible = true;
                generalSearchChart.Visible = true;
                searchIterationTab.Visible = true;
            }
        }



        //Genera todos los datos aleatorios (4 listas por iteracion)
        private void generateRandomData(int elements, int intervals)
        {
            double randItem = 0;
            int intv = elements / intervals;
            int intvincr = -1;
            double mult = (double)1 / intervals;
            double probability = random.NextDouble() * 0.3 + 0.2;
            int randomIndex;
            List<List<double>> lists = new List<List<double>>();
            for (int i = 0; i < 4; i++)
            {
               
                List<double> randData = new List<double>();
                switch (i)
                {
                    case 0: //random
                        for (int j = 0; j < elements; j++)
                        {
                            randItem = random.NextDouble();
                            randData.Add(randItem);
                            
                        }
                     

                        break;
                    case 1: //sorted
                        randData = new List<double>(lists[0]);
                        randData.Sort();
                        randData.Reverse();
                        break;
                    case 2: //ranged 
                        for (int j = 0; j < elements; j++)
                        {
                            if (j % intv == 0 && intvincr < intervals - 1)
                            {
                                intvincr++;
                            }
                            randItem = (random.NextDouble() * mult) + mult * intvincr;
                            randData.Add(randItem);
                           
                        }
                       
                        break;
                    case 3: //repeated
                        for (int j = 0; j < elements; j++)
                        {
                            if (randData.Count > 0 && probability <= random.NextDouble())
                            {
                                randomIndex = random.Next(randData.Count);
                                randItem = randData[randomIndex];
                            }
                            else
                            {
                                randItem = random.NextDouble();
                            }
                            randData.Add(randItem);
                            
                        }
                      
                        break;
                }

                lists.Add(randData);
            }
            iterationList.Add(lists);
        }

        //Ordena todas las listas de todas las iteraciones
        private void getSortingResults(IProgress<int> progress)
        {
            Sortings sortingsTool = new Sortings();
            times = new List<List<List<Stopwatch>>>();
            int totalProgress = iterationList.Count * 12;
            int currentProgress = 0;
            for (int i = 0; i < iterationList.Count; i++)
            {
                List<List<Stopwatch>> timesByIteration = new List<List<Stopwatch>>();
                for (int j = 0; j < iterationList[i].Count; j++)
                {
                    List<Stopwatch> timesByMethod = new List<Stopwatch>();
                    for( int k = 0; k < numbOfSorts; k++)
                    { 
                        List<double> auxList = new List<double>(iterationList[i][j]);
                        Stopwatch stopWatch = new Stopwatch();
                        switch (k)
                        {
                            case 0: // bubble
                                stopWatch.Start();

                                sortingsTool.bubbleSort(auxList);
                                
                                stopWatch.Stop();
                                break;
                            case 1: //insertion

                                stopWatch.Start();

                                sortingsTool.insertionSort(auxList);

                                stopWatch.Stop();
                                break ;
                            case 2: // merge
                                
                                GC.Collect();
                                GC.WaitForPendingFinalizers();
                                GC.Collect();
                                stopWatch.Start();

                                sortingsTool.mergeSort(auxList, 0, auxList.Count-1);

                                stopWatch.Stop();
                                iterationList[i][j] = auxList;
                                break ;
                        }
                        timesByMethod.Add(stopWatch);
                    }

                    currentProgress += 3;
                    int percentComplete = (int)((currentProgress) * 100.0 / totalProgress);
                    progress?.Report(percentComplete);

                    timesByIteration.Add(timesByMethod);
                }
                times.Add(timesByIteration);
            }
        }

       
        // Realizar las búsquedas
        private void getSearchingResults()
        {
            Search linear = new Search();
            Search exp = new Search();
            long linearFounds = 0;
            long expFounds = 0;
            timesSearch = new List<List<List<List<TimeSpan>>>>();
            searchFounds = new List<List<List<long>>>();


            for (int i = 0; i < iterationList.Count; i++) {
                List<List<long>> auxFounds = new List<List<long>>();
                List<List<List<TimeSpan>>> aux = new List<List<List<TimeSpan>>>();
                
                for (int j = 0; j < iterationList[i].Count; j++)
                {
                    List<List<TimeSpan>> timesBySearch = new List<List<TimeSpan>>();
                    List<long> foundsBySearch = new List<long>();

                    linearFounds = linear.linearSearch(iterationList[i][j], randomToSearch);
                    expFounds = exp.exponentialSearch(iterationList[i][j], randomToSearch);

                    timesBySearch.Add(new List<TimeSpan> { linear.stopWatchFirst.Elapsed, exp.stopWatchFirst.Elapsed });
                    timesBySearch.Add(new List<TimeSpan> { linear.stopWatchAll.Elapsed, exp.stopWatchAll.Elapsed });

                    foundsBySearch.Add(linearFounds);
                    foundsBySearch.Add(expFounds);

                    aux.Add(timesBySearch);
                    auxFounds.Add(foundsBySearch);
                }
               
                timesSearch.Add(aux);
                searchFounds.Add(auxFounds);
            }
        }
        
        

        //Genera los elementos gráficos de los resultados de la búsqueda por cada iteración
        private void generateSearchResultGraph()
        {
            String[] listTypes = { "Datos Aleatorios", "Datos Ordenados Inversamente", "Datos por Rangos", "Datos con Repetidos" };
            searchIterationTab.TabPages.Clear();
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular);
            for(int i = 0; i < iterationList.Count; i++)
            {
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.RowCount = 2;
                panel.ColumnCount = 2;
                panel.Dock = DockStyle.Fill;
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

                for (int j = 0; j < 4; j++)
                {
                    TableLayoutPanel container = new TableLayoutPanel() {
                        Dock = DockStyle.Fill,
                        ColumnCount = 1,
                        RowCount = 2,
                    };
                    container.RowStyles.Add(new RowStyle(SizeType.Percent, 80F)); // Gráficos ocupan 80%
                    container.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));

                    TableLayoutPanel chartContainer = new TableLayoutPanel()
                    {
                        Dock = DockStyle.Fill,
                        ColumnCount = 2,
                        RowCount = 1,
                    };
                    chartContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F)); // Cada gráfico 50%
                    chartContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
                    Chart searchChart = new Chart()
                    {
                        Dock = DockStyle.Fill,
                    };



                    searchChart.Titles.Add($"Tiempos empleados en la búsqueda de un decimal en una lista con {listTypes[j]} de la iteración {i+1}");
                    searchChart.Titles[0].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                    ChartArea chartArea = new ChartArea("MainArea");
                    chartArea.AxisX.Title = "Algoritmos de Búsqueda";
                    chartArea.AxisY.Title = "Tiempo (ticks)";
                    chartArea.AxisY.TitleFont = font;
                    chartArea.AxisX.TitleFont = font;
                    chartArea.AxisX.Interval = 1;
                    searchChart.ChartAreas.Add(chartArea);

                    AddSeries(searchChart, "Primera Incidencia", System.Drawing.Color.Blue);
                    AddSeries(searchChart, "Tiempo Total", System.Drawing.Color.Red);



                    String[] algorithms = new[] { "Lineal", "Exponencial" };

                    List<long> timeFirst = timesSearch[i][j][0].Select(s => s.Ticks).ToList();
                    List<long> timeAll = timesSearch[i][j][1].Select(s => s.Ticks).ToList();


                    AddDataToSeries(searchChart, "Primera Incidencia", algorithms, timeFirst);
                    AddDataToSeries(searchChart, "Tiempo Total", algorithms, timeAll);


                    Legend legend = new Legend("Legend")
                    {
                        Title = "Tiempo de Incidencia",
                        Docking = Docking.Bottom,
                        Alignment = StringAlignment.Center,
                        Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
                    };
                    searchChart.Legends.Add(legend);

                    foreach (Series serie in searchChart.Series)
                    {
                        serie.Legend = "Legend";
                    }

                    Chart searchFoundsChart = new Chart()
                    {
                        Dock = DockStyle.Fill
                    };

                    searchFoundsChart.Titles.Add($"Cantidad de incidencias encontradas en una lista con {listTypes[j]} de la iteración {i + 1}");
                    searchFoundsChart.Titles[0].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                    ChartArea chartAreaFounds = new ChartArea("MainArea");
                    chartAreaFounds.AxisX.Title = "Algoritmos de Búsqueda";
                    chartAreaFounds.AxisY.Title = "Cantidad de incidencias";
                    chartAreaFounds.AxisY.TitleFont = font;
                    chartAreaFounds.AxisX.TitleFont = font;
                    chartAreaFounds.AxisX.Interval = 1;
                    searchFoundsChart.ChartAreas.Add(chartAreaFounds);

                    AddSeries(searchFoundsChart, "Encontrados", System.Drawing.Color.Purple);

                    AddDataToSeries(searchFoundsChart, "Encontrados", algorithms, new List<long> { searchFounds[i][j][0], searchFounds[i][j][1] });

                    DataGridView foundsDataGrid = new DataGridView
                    {
                        Dock = DockStyle.Bottom,
                        Height = 150,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        ReadOnly = true, 
                        AllowUserToAddRows = false, 
                        AllowUserToResizeRows = false, 
                        AllowUserToResizeColumns = false

                    };

                    foundsDataGrid.Columns.Add("Col1", "Algoritmo");
                    foundsDataGrid.Columns.Add("Col2", "Tiempo Primero");
                    foundsDataGrid.Columns.Add("Col3", "Tiempo Total");
                    foundsDataGrid.Columns.Add("Col3", "Encontrados");
                    foundsDataGrid.Rows.Add("Lineal", timesSearch[i][j][0][0].ToString(), timesSearch[i][j][1][0].ToString(), searchFounds[i][j][0]);
                    foundsDataGrid.Rows.Add("Exponencial", timesSearch[i][j][0][1].ToString(), timesSearch[i][j][1][1].ToString(), searchFounds[i][j][1]);

                    chartContainer.Controls.Add(searchChart, 0, 0);
                    chartContainer.Controls.Add(searchFoundsChart, 1, 0);
                    container.Controls.Add(chartContainer, 0, 0);
                    container.Controls.Add(foundsDataGrid, 0, 1);

                    int row = j / 2;
                    int col = j % 2;
                    panel.Controls.Add(container, col, row);

                }
                TabPage page = new TabPage();
                page.Controls.Add(panel);
                page.Text = $"Búsqueda Iteración {i + 1}";
                searchIterationTab.TabPages.Add(page);

            }
        }


        //Carga información en el dataGrid y chart de Búsqueda General (Promedios)
        private void genertateGeneralSearchResults()
        {
            double avgFirstLn = 0;
            double avgAllLn = 0;

            double avgFirstEx = 0;
            double avgAllEx = 0;

            for (int i = 0; i < timesSearch.Count; i++)
            {
                for(int j = 0; j < timesSearch[i].Count; j++)
                {
                    avgFirstLn += timesSearch[i][j][0][0].TotalMilliseconds;
                    avgFirstEx += timesSearch[i][j][0][1].TotalMilliseconds;

                    avgAllLn += timesSearch[i][j][1][0].TotalMilliseconds;
                    avgAllEx += timesSearch[i][j][1][1].TotalMilliseconds;
                }
            }

            double total = timesSearch[0].Count * timesSearch[0][0].Count;

            avgFirstLn = avgFirstLn / total;
            avgFirstEx = avgFirstEx / total;
            avgAllLn = avgAllLn / total;
            avgAllEx = avgAllEx / total;


            generalSearchChart.Series.Clear();

            Series avgFirstSeries = new Series("Promedio primer Incidencia")
            {
                ChartType = SeriesChartType.Bar,
            };

            Series avgAllSeries = new Series("Promedio Tiempo total")
            {
                ChartType = SeriesChartType.Bar,
            };

            generalSearchChart.Series.Add(avgFirstSeries);
            generalSearchChart.Series.Add(avgAllSeries);

            generalSearchChart.Series[0].Points.AddXY("Lineal", avgFirstLn);
            generalSearchChart.Series[0].Points.AddXY("Exponencial", avgFirstEx);

            generalSearchChart.Series[1].Points.AddXY("Lineal", avgAllLn);
            generalSearchChart.Series[1].Points.AddXY("Exponencial", avgAllEx);

            generalSearchDG.Rows.Clear();
            generalSearchDG.Rows.Add("Lineal", avgFirstLn.ToString(), avgAllLn.ToString());
            generalSearchDG.Rows.Add("Exponencial", avgFirstEx.ToString(), avgAllEx.ToString());



        }


        //Genera los elementos gráficos de los resultados de los ordenamientos
        private void generateResultGraphs()
        {

            loadResultGeneralChart(randomResultChart, 0);
            loadResultGeneralChart(inversedResultChart, 1);
            loadResultGeneralChart(rangedResultChart, 2);
            loadResultGeneralChart(repeatedResultChart, 3);

            loadDataGridsGeneralResults();
            generateIterationCharts();

        }


        //Cargar Charts con resultados de los ordenamientos generales por tipo de lista
        private void loadResultGeneralChart(Chart chart, int listTypeIndex)
        {
            string[] algorithms = { "Burbuja", "Inserción", "Merge" };

            chart.Series.Clear();
            for (int algoIndex = 0; algoIndex < 3; algoIndex++)
            {
                string seriesName = $"{algorithms[algoIndex]}";
                Series series = new Series(seriesName)
                {
                    ChartType = SeriesChartType.Column
                };

                for (int i = 0; i < times.Count; i++)
                {
                    series.Points.AddY(times[i][listTypeIndex][algoIndex].ElapsedTicks);
                }

                chart.Series.Add(series);
            }
        }

        //Data Grids de los resultados generales de los ordenamientos
        private void loadDataGridsGeneralResults()
        {


            double[] avgBubble = {0,0,0,0};
            double[] avgInsert = { 0, 0, 0, 0 };
            double[] avgMerge = { 0, 0, 0, 0 };

            double[] minBubble = { 1e10, 1e10, 1e10, 1e10 };
            double[] maxBuubble = { -1, -1, -1, -1 };

            double[] minInsert = { 1e10, 1e10, 1e10, 1e10 };
            double[] maxInsert = { -1, -1, -1, -1 };

            double[] minMerge = { 1e10, 1e10, 1e10, 1e10 };
            double[] maxMerge = { -1, -1, -1, -1 };
            allResults.Rows.Clear();
            string[] typeLists = { "Aleatorio", "Invertida","Rangos", "Repetida" };
            for (int i = 0; i < times.Count; i++)
            {
                for (int j = 0; j < times[i].Count; j++)
                {
                    allResults.Rows.Add($"{i + 1}", typeLists[j],times[i][j][0].Elapsed, times[i][j][1].Elapsed, times[i][j][2].Elapsed);

                    avgBubble[j] += times[i][j][0].Elapsed.TotalMilliseconds;
                    avgInsert[j] += times[i][j][1].Elapsed.TotalMilliseconds;
                    avgMerge[j] += times[i][j][2].Elapsed.TotalMilliseconds;

                    minBubble[j] = Math.Min(minBubble[j], times[i][j][0].Elapsed.TotalMilliseconds);
                    minInsert[j] = Math.Min(minInsert[j], times[i][j][1].Elapsed.TotalMilliseconds);
                    minMerge[j] = Math.Min(minMerge[j], times[i][j][2].Elapsed.TotalMilliseconds);

                    maxBuubble[j] = Math.Max(maxBuubble[j], times[i][j][0].Elapsed.TotalMilliseconds);
                    maxInsert[j] = Math.Max(maxInsert[j], times[i][j][1].Elapsed.TotalMilliseconds);
                    maxMerge[j] = Math.Max(maxMerge[j], times[i][j][2].Elapsed.TotalMilliseconds);
                }
            }

            resumeResults.Rows.Clear();
            for (int i = 0; i < avgBubble.Length; i++) {
                avgBubble[i] /= times.Count;
                avgInsert[i] /= times.Count;
                avgMerge[i] /= times.Count;

                resumeResults.Rows.Add("Burbúja",typeLists[i] ,minBubble[i], avgBubble[i], maxBuubble[i]);
                resumeResults.Rows.Add("Inserción", typeLists[i], minInsert[i], avgInsert[i], maxInsert[i]);
                resumeResults.Rows.Add("Merge", typeLists[i], minMerge[i], avgMerge[i], maxMerge[i]);
            }


        }
        
        //Graficos en cada iteración de ordenamiento
        private void generateIterationCharts()
        {
            while (resultsTabControl.TabPages.Count > 1)
            {
                resultsTabControl.TabPages.RemoveAt(1);
            }
            Font font = new System.Drawing.Font("Microsoft Sans Serif", 9, System.Drawing.FontStyle.Regular);

            for (int i = 0; i < times.Count; i++)
            {
                Chart sortingChart = new Chart
                {
                    Dock = DockStyle.Fill
                };

                sortingChart.Titles.Add($"Tiempo de ordenamiento en la iteración {i + 1} con cada tipo de lista y algoritmo de ordenamiento");
                sortingChart.Titles[0].Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);

                ChartArea chartArea = new ChartArea("MainArea");
                chartArea.AxisX.Title = "Algoritmos de Ordenamiento";
                chartArea.AxisY.Title = "Tiempo (ticks)";
                chartArea.AxisY.TitleFont = font;
                chartArea.AxisX.TitleFont = font;
                chartArea.AxisX.Interval = 1; 
                sortingChart.ChartAreas.Add(chartArea);
                
                AddSeries(sortingChart, "Datos Aleatorios", System.Drawing.Color.Blue);
                AddSeries(sortingChart, "Datos Ordenados Inversamente", System.Drawing.Color.Red);
                AddSeries(sortingChart, "Datos por Rangos", System.Drawing.Color.Green);
                AddSeries(sortingChart, "Datos con Repetidos", System.Drawing.Color.Purple);


                String[] algorithms = new[] { "Burbuja", "Inserción", "Merge" };

                List<long> timeRandom = times[i][0].Select(s => s.ElapsedTicks).ToList();
                List<long> timeInverse = times[i][1].Select(s => s.ElapsedTicks).ToList();
                List<long> timeRanged = times[i][2].Select(s => s.ElapsedTicks).ToList();
                List<long> timeRepeated = times[i][3].Select(s => s.ElapsedTicks).ToList();

                AddDataToSeries(sortingChart, "Datos Aleatorios", algorithms, timeRandom);
                AddDataToSeries(sortingChart, "Datos Ordenados Inversamente", algorithms, timeInverse);
                AddDataToSeries(sortingChart, "Datos por Rangos", algorithms, timeRanged);
                AddDataToSeries(sortingChart, "Datos con Repetidos", algorithms, timeRepeated);

                Legend legend = new Legend("Legend")
                {
                    Title = "Tipos de listas", 
                    Docking = Docking.Bottom, 
                    Alignment = StringAlignment.Center, 
                    Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Bold)
                };
                sortingChart.Legends.Add(legend);

                foreach(Series serie in sortingChart.Series)
                {
                    serie.Legend = "Legend";
                }



                TabPage page = new TabPage();
                page.Controls.Add(sortingChart);
                page.Text = $"Iteración {i+1}"; 
                resultsTabControl.TabPages.Add(page);
            }
        }

        //Add Series to iteration charts
        private void AddSeries(Chart sortingChart, string name, System.Drawing.Color color)
        {
            Series series = new Series(name)
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "MainArea",
                IsValueShownAsLabel = true,
                Color = color
            };
            sortingChart.Series.Add(series);
        }

        //Carga los datos en los gráficos por iteraciones
        private void AddDataToSeries(Chart sortingChart, string seriesName, string[] xValues, List<long> yValues)
        {
            Series series = sortingChart.Series[seriesName];
            for (int i = 0; i < xValues.Length; i++)
            {
                series.Points.AddXY(xValues[i], yValues[i]);
            }
        }


        //Crear Charts para los datos aleatorios de cada iteración
        private Chart createDataChart(string xaxis, string yaxis)
        {
            Series serie = new Series("Series1") { ChartType = SeriesChartType.Column };
            Chart chart = new Chart();
            ChartArea chartArea = new ChartArea();
            
            chartArea.AxisX.Title = xaxis;
            chartArea.AxisY.Title = yaxis;
            chart.ChartAreas.Add(chartArea);
            chart.Dock = DockStyle.Fill;
            chart.Series.Add(serie);
            
            return chart;
        }

        //Crea los paneles de cada Tab Para cada iteración de datos aleatorios
        private TableLayoutPanel generateChartPanel(List<List<double>> iteration)
        {
          
            TableLayoutPanel panel = new TableLayoutPanel();
            panel.RowCount = 2;
            panel.ColumnCount = 2;
            panel.Dock = DockStyle.Fill;
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

   
            for (int i = 0; i < 4; i++)
            {

                Chart chart = createDataChart("índice", "valor");
                String chartTitle = "";
                List<double> elements = iteration[i];
                switch (i)
                {
                    case 0: //random
                        for (int j = 0; j < elements.Count; j++)
                        {
                            chart.Series[0].Points.AddY(elements[j]);
                        }
                        chartTitle = "Datos aleatorios";
                        
                        break;
                    case 1: //sorted

                        for(int j = 0; j < elements.Count; j++)
                        {
                            chart.Series[0].Points.AddY(elements[j]);
                        }
                        chartTitle = "Datos Ordenados descendentemente";
                        break;
                    case 2: //ranged 
                        for (int j = 0; j < elements.Count; j++)
                        {

                            chart.Series[0].Points.AddY(elements[j]);
                        }
                        chartTitle = "Datos aleatorios por intervalos";
                        break;
                    case 3: //repeated
                        for (int j = 0; j < elements.Count; j++)
                        {

                            chart.Series[0].Points.AddY(elements[j]);
                        }
                        chartTitle = "Datos aleatorios con repetición";
                        break;
                }
                chart.Titles.Add(chartTitle);

                int row = i / 2; 
                int col = i % 2; 
                panel.Controls.Add(chart, col, row);

            }
            return panel;
        }

        //Valida los datos de entrada de la generación de los datos aleatorios
        private int[] validateInputs()
        {
            int elements = 0;
            int intervals = 0;
            int iterations = 0;

            bool elementTry = int.TryParse(txtelements.Text, out elements);
            bool intervalTry = int.TryParse(txtinterval.Text, out intervals);
            bool iterationsTry = int.TryParse(txtIteration.Text, out iterations);

            elementTry = elementTry && elements > 0;
            intervalTry = intervalTry && intervals > 0;
            iterationsTry = iterationsTry && iterations > 0;

            if (!elementTry || !intervalTry || !iterationsTry) {

                String errorMessage = "";
                if (!elementTry)
                {
                    errorMessage += "Ingrese un número entero mayor a 0 para el número de elementos\n";
                }
                if (!intervalTry) { 
                    errorMessage += "Ingrese un número entero mayor a 0 para el número de intervalos\n";
                }
                if (!iterationsTry)
                {
                    errorMessage += "Ingrese un número entero mayor a 0 para el número de iteraciones\n";
                }
                MessageBox.Show(errorMessage);
                return null;
            }
            return new int[] { elements, intervals, iterations };
        }
    }

}
