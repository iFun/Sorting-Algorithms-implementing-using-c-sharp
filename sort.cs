using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        SortAlgo.init(50000000);
      //  int [] Sarray = SortAlgo.SelectionSort();
        Console.WriteLine();
       // int [] Iarray = SortAlgo.InsertionSort();
        //SortAlgo.OutputArray(Sarray);
      //  Console.WriteLine();
        int [] Marray = SortAlgo.Merge_Sort();
       // SortAlgo.OutputArray(Marray);
    }


}

class SortAlgo
{
    private static int [] array;
    
    //initialize an random integer array with a given length
    public static void init(int length)
    {
        array = new int [length];
        Random r = new Random();
        Console.WriteLine("Un-sorted array");
        for(int i = 0; i < length;i++)
        {
            array[i] = r.Next(0,1000);
            //Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    
    }
    
    //helper function that exchange the value of the two members in the array
    private static void Swap(int x, int y, int [] sort)
    {
        int tmp = sort[x];
        sort[x] = sort[y];
        sort[y] = tmp;

    }
    public static void OutputArray(int [] Outarray)
    {
        for(int i = 0; i < Outarray.Length;i++)
        {
            Console.Write(Outarray[i] + " ");
        }
    
    }
    
    public static int[] InsertionSort()
    {
        int [] sortarray = new int [array.Length];
        Array.Copy(array, sortarray, array.Length);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        for(int i = 1; i < sortarray.Length; i++)
        {
            int j = i;
            while(j > 0 && sortarray[j] < sortarray[j-1])
            {
                Swap(j,j-1,sortarray);
                j--;
            }
        }
        watch.Stop();
        Console.WriteLine("Insertion Sort's Time: " + watch.Elapsed.TotalSeconds.ToString() + "s");
        return sortarray;
    }
    
    public static int[] SelectionSort()
    {
        int [] sortarray = new int [array.Length];
        Array.Copy(array, sortarray, array.Length);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        
        for(int i = 0; i < sortarray.Length -1 ; i++)
        {
            int minIndex = i;
            for(int j = 1+i; j < sortarray.Length;j++)
            {
                if(sortarray[j] < sortarray[minIndex])
                {
                    minIndex = j;
                
                }       
            }
            if(minIndex != i)
            {
                Swap(i,minIndex,sortarray);         
            }
        
        }
        watch.Stop();
        Console.WriteLine("Selection Sort's Time: " + watch.Elapsed.TotalSeconds.ToString() + "s");
        return sortarray;
    }
    private static int[] Merge(int[] left, int [] right)
    {
        int length = left.Length + right.Length;
        int [] result = new int [length];
        int indexL = 0;
        int indexR = 0;
        int indexRes= 0;

        while(indexR < right.Length || indexL < left.Length)
        {
            //both array has index need to be merge
            if(indexR < right.Length && indexL < left.Length)
            {
                if(left[indexL] <= right[indexR])
                {
                    result [indexRes] = left[indexL];
                    indexL++;
                    indexRes++;
                }
                else
                {
                    result [indexRes] = right[indexR];
                    indexR++;
                    indexRes++;
                }
            }
            else if(indexL < left.Length)//left has index right has none
            {
                result [indexRes] = left[indexL];
                indexL++;
                indexRes++; 
            }
            else
            {
                result [indexRes] = right[indexR];
                indexR++;
                indexRes++;
            }
        }
        return result;
    } 
    public static int [] Merge_Sort()
    {
        int [] sortarray = new int [array.Length];
        Array.Copy(array, sortarray, array.Length);
        Stopwatch watch = new Stopwatch();
        watch.Start();
        sortarray = MergeSort(sortarray);

        watch.Stop();
        Console.WriteLine("Merge Sort's Time: " + watch.Elapsed.TotalSeconds.ToString() + "s");

        return sortarray;
    }

    private static int [] MergeSort(int [] array1)
    {
        int [] result = new int [array1.Length];

        if(array1.Length == 1)
        {
            return array1;
        }

        int midpoint = array1.Length/2;
        int [] left = new int[midpoint];
        int [] right; 

        if(array1.Length % 2 == 0)
        {
            right = new int [midpoint];

        }
        else
        {
            right = new int [midpoint + 1];
        }

        for(int i = 0; i< midpoint; i++)
        {
            left[i] = array1[i];
        }
        int x = 0;
        for(int j = midpoint; j < array1.Length;j++)
        {
            right[x] = array1[j];
            x++;
        }
        
        left = MergeSort(left);
        right = MergeSort(right);
        result = Merge(left,right);

        return result;

    
    }

    
    
    
    
    
    
    
    
    
}