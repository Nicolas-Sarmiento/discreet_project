using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discreet_project
{
    internal class Search
    {
        public Stopwatch stopWatchFirst { get; set; }
        public Stopwatch stopWatchAll { get; set; }

        public Search()
        {
            stopWatchAll = new Stopwatch();
            stopWatchFirst = new Stopwatch();
        }

        private double roundValue(double number)
        {
            double rounded = 0;
            number *= 10;
            number = Math.Floor(number);
            rounded = number / 10;
            return rounded;
        }

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
