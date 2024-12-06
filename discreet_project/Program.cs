using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace discreet_project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<double> list = new List<double>() { 0.0588,0.1565,0.1598,0.16,0.3,0.58,0.781};
            double target = 0.3;
            
            Search lnSearch = new Search();
            Search expSearch = new Search();

            long lnCount = lnSearch.linearSearch(list, target); 
            long xpCount = expSearch.exponentialSearch(list, target);

            Console.WriteLine(lnCount.ToString());
            Console.WriteLine(xpCount.ToString());

            Console.WriteLine(lnSearch.stopWatchAll.Elapsed.ToString());
            Console.WriteLine(expSearch.stopWatchAll.Elapsed.ToString());


            Console.WriteLine(lnSearch.stopWatchFirst.Elapsed.ToString());
            Console.WriteLine(expSearch.stopWatchFirst.Elapsed.ToString());



        }
    }
}
