using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap_Sorting
{
    internal class Program
    {
        class Heap
        {
            int[] data;
            int maxsize;
            int csize;
            public Heap()
            {
                maxsize = 10;
                data = new int[maxsize];
                csize = 0;
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = 0;
                }

            }
            public int length()
            {
                return csize;
            }
            public bool isEmpty()
            {
                return csize == 0;
            }
            public void heap_insert(int e)
            {
                if (csize == maxsize)
                {
                    Console.WriteLine("No Space");
                    return;
                }
                csize = csize + 1;
                int hi = csize;
                while (hi > 1 && e > data[hi / 2])
                {
                    data[hi] = data[hi / 2];
                    hi = hi / 2;
                }
                data[hi] = e;
            }
            public void heap_delete()
            {
                int e = data[1];
                data[1] = data[csize];
                data[csize] = 0;
                csize = csize - 1;
                int i = 1;
                int j = i * 2;
                while (j <= csize)
                {
                    if (data[j] < data[j + 1])
                    {
                        j = j + 1;
                    }
                    if (data[i] < data[j])
                    {
                        int temp = data[i];
                        data[i] = data[j];
                        data[j] = temp;
                        i = j;
                        j = i * 2;
                    }
                    else
                    {
                        break;
                    }
                }

            }
            public int max()
            {
                if (isEmpty())
                {
                    Console.WriteLine("Heap is Empty");
                    return -1;
                }
                return data[1];
            }
            public void display()
            {
                for (int i = 0; i < data.Length; i++)
                {
                    Console.Write(data[i] + " ");

                }
                Console.WriteLine();
            }
        }
        class Sort
        {
            public void heapsort(int[] A, int n)
            {
                Heap h = new Heap();
                for (int i = 0; i < n; i++)
                    h.heap_insert(A[i]);
                int k = n - 1;
                for (int i = 0; i < n; i++)
                {
                    A[k] = h.max();
                    h.heap_delete();
                    k = k - 1;
                }
            }

            public void display(int[] A, int n)
            {
                for (int i = 0; i < n; i++)
                    Console.Write(A[i] + " ");
                Console.WriteLine();
            }

            static void Main(string[] args)
            {
                int[] arr = { 12, 11, 13, 5, 6, 7 };
                int n = arr.Length;
                Sort sorter = new Sort();
                sorter.heapsort(arr, n);
                sorter.display(arr, n);
                Console.ReadLine();

            }

        }
    }
}
