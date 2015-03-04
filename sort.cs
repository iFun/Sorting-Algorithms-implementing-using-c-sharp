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
		SortAlgo.init(90000);
		int [] Sarray = SortAlgo.SelectionSort();
		Console.WriteLine();
		int [] Iarray = SortAlgo.InsertionSort();
		//SortAlgo.OutputArray(Sarray);
	
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
		//Console.WriteLine();
	
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
	public static int[] MergeSort()
	{
	
	
	
	}

	
	
	
	
	
	
	
	
	
}