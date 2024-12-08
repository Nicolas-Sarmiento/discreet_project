using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discreet_project
{
    /// <summary>
    /// This is a class with sorting algorithms:
    /// - Bubble Sort
    /// - Insertion Sort
    /// -Merge Sort
    /// </summary>
    public class Sortings
    {

        /// <summary>
        /// Bubbles the sort. This method performs a bubble sort
        /// over a list of doubles.
        /// </summary>
        /// <param name="arr">The list of doubles.</param>
        public void bubbleSort(List<double> arr)
        {
            double temp = 0;
            int n = arr.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Insertions the sort. This method performs a insertion sort
        /// over a list of doubles.
        /// </summary>
        /// <param name="arr">The list of doubles.</param>
        public void insertionSort(List<double> arr)
        {
            double key = 0;
            int j = 0;
            int n = arr.Count;
            for (int i = 1; i < n; i++)
            { 
                key = arr[i];
                j = i - 1;
                while( j>= 0 && arr[j] > key)
                {
                    arr[j+1] = arr[j];
                    j--;
                }
                arr[j+1] = key;
            }
        }

        /// <summary>
        /// Merges the arrays. Merge Sort needs to merge 
        /// two ordered arrays. This metod merges two sorted arrays
        /// it uses some loops to complete the task.
        /// </summary>
        /// <param name="arr">The list of doubles.</param>
        /// <param name="l">The left pointer.</param>
        /// <param name="m">The mid pointer.</param>
        /// <param name="r">The right pointer.</param>
        void mergeArrays(List<double> arr, int l, int m, int r)
        { 
            int lenL = m- l + 1;
            int lenR = r - m;

            List<double> Left = new List<double>();
            List<double> Right = new List<double>();

            int i, j, k;
            for (i = 0; i < lenL; i++)
            {
                Left.Add(arr[l+i]);
            }
            for (j = 0; j < lenR; j++)
            {
                Right.Add(arr[m+j+1]);
            }
            i = 0; j = 0; k = l;
            while (i < lenL && j < lenR){
                if (Left[i] <= Right[j])
                {
                    arr[k] = Left[i];
                    i++;
                }
                else
                {
                    arr[k] = Right[j];
                    j++;
                }
                k++;
            }

            while(i < lenL)
            {
                arr[k] = Left[i];
                i++;k++;
            }
            while (j < lenR)
            {
                arr[k] = Right[j];
                j++; k++;
            }

        }


        /// <summary>
        /// Merges the sort. Performs a MergeSort over
        /// a list of doubles. This method uses itself to
        /// sort the whole main list. To use to sort a 
        /// whole list. left pointer is zero (0)
        /// and the right pointer is the size of the list minus one
        /// (n - 1).
        /// </summary>
        /// <param name="arr">The list of doubles.</param>
        /// <param name="l">The left pointer.</param>
        /// <param name="r">The right Pointer.</param>
        public void mergeSort( List<double> arr, int l, int r )
        {
            if( l < r)
            {
                int middle = l + (r - l)/2;
                mergeSort( arr, l, middle );
                mergeSort(arr, middle + 1, r);
                mergeArrays(arr, l, middle, r );
            }
        }
    }
}
