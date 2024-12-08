using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discreet_project
{
    /// <summary>
    /// This is a class to search a value in a list of double values
    /// and mesuare the time to complete that task and the time for 
    /// find the first value of them. The search can be perform by two
    /// algorithms: Linear search and Exponential search
    /// </summary>
    internal class Search
    {
        /// <summary>
        /// Gets or sets the stop watch first incidence.
        /// </summary>
        /// <value>
        /// The stop watch first.
        /// </value>
        public Stopwatch stopWatchFirst { get; set; }
        /// <summary>
        /// Gets or sets the stop watch to complete the whole search task.
        /// </summary>
        /// <value>
        /// The stop watch all.
        /// </value>
        public Stopwatch stopWatchAll { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Search"/> class.
        /// </summary>
        public Search()
        {
            stopWatchAll = new Stopwatch();
            stopWatchFirst = new Stopwatch();
        }

        /// <summary>
        /// Trunc the value to 1 decimal position.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private double roundValue(double number)
        {
            double rounded = 0;
            number *= 10;
            number = Math.Floor(number);
            rounded = number / 10;
            return rounded;
        }

        /// <summary>
        /// Linears the search. In a list of doubles. It returns
        /// the number of incidences found in the list.
        /// </summary>
        /// <param name="list">The list of double values.</param>
        /// <param name="value">The Target value.</param>
        /// <returns></returns>
        public long linearSearch(List<double> list, double value)
        {
            long finds = 0;
            bool findFirst = false;

            stopWatchFirst.Restart();
            stopWatchAll.Restart();
            for (int i = 0; i < list.Count; i++)
            {
                if (value == roundValue(list[i]))
                {
                    if (!findFirst)
                    {
                        stopWatchFirst.Stop();
                        findFirst = true;
                    }
                    finds++;
                }

            }
            stopWatchFirst.Stop();
            stopWatchAll.Stop();

            return finds;
        }


        /// <summary>
        /// Exponentials the search. In a list of doubles. It returns 
        /// the number of incidences found in the list.
        /// </summary>
        /// <param name="list">The list of double values.</param>
        /// <param name="value">The Target value.</param>
        /// <returns></returns>
        public long exponentialSearch(List<double> list, double value)
        {
            long finds = 0;
            stopWatchFirst.Restart();
            stopWatchAll.Restart();

            int n = list.Count;
            int i = 1;
            while (i < n && roundValue(list[i]) <= value)
            {
                i = i * 2;
            }
            i = Math.Min(i, n-1);
            int j = i;
            while (j > 0 && roundValue(list[j]) >= value)
            {
                j = j/2;
            }

            int left = BinarySearch(list, value, j, i, true);
            int right = BinarySearch(list, value, j, i, false);
            if (left == -1) finds = 0;
            else
            {
                finds = (right+1) - left ;
            }

            stopWatchFirst.Stop();
            stopWatchAll.Stop();
            return finds;
        }

        /// <summary>
        /// Binaries the search. Due Exponential search is a 
        /// improve of binary search. This method performs a binary search
        /// that works as well as lower bound or upper bound. With the flag
        /// lowerBound this method performs a lowerBound search and with that
        /// flag as false performs an UpperBound search. Finally this method
        /// returns an a position
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="target">The target.</param>
        /// <param name="low">The low.</param>
        /// <param name="high">The high.</param>
        /// <param name="lowerBound">if set to <c>true</c> [lower bound].</param>
        /// <returns></returns>
        private int BinarySearch(List<double> array, double target, int low, int high, bool lowerBound)
        {
            int result = -1;
            bool foundFirst = false; 
            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (roundValue(array[mid]) == target)
                {
                    result = mid;
                    if (!foundFirst)
                    {
                        stopWatchFirst.Stop();
                        foundFirst = true;
                    }
                    if (lowerBound)
                    {
                        high = mid - 1;
                    }
                    else
                    {
                        low = mid + 1;
                    }
                }
                else if (roundValue(array[mid]) < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }
            return result;
        }
    }
}
