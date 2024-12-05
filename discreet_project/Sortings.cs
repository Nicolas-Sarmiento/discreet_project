using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discreet_project
{
    public class Sortings
    {
       
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
