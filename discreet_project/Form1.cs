using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace discreet_project
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        List<List<List<double>>> iterationList;
        List<List<List<Stopwatch>>> times;
        Sortings sortings;
        int numbOfSorts = 3;

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

                await Task.Run(() =>
                {
                    getSortingResults();
                });
                generateResultGraphs();
                btnStart.Text = "Generar";
            }
            catch (Exception ex) {
            }
            finally
            {
                btnStart.Enabled = true;
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
        private void getSortingResults()
        {
            Sortings sortingsTool = new Sortings();
            times = new List<List<List<Stopwatch>>>();
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
                    
                    timesByIteration.Add(timesByMethod);
                }
                times.Add(timesByIteration);
            }
        }

        //Genera los elementos gráficos de los resultados de los ordenamientos
        private void generateResultGraphs()
        {

            string[] algorithms = { "Burbuja", "Inserción", "Merge" };

            loadResultGeneralChart(randomResultChart, 0);
            loadResultGeneralChart(inversedResultChart, 1);
            loadResultGeneralChart(rangedResultChart, 2);
            loadResultGeneralChart(repeatedResultChart, 3);

            loadDataGridsGeneralResults();

        }



        //Cargar Charts con resultados de los ordenamientos
        private void loadResultGeneralChart(Chart chart, int listTypeIndex)
        {
            string[] algorithms = { "Burbuja", "Inserción", "Merge" };

            //random Result Chart
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
