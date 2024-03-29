﻿using DataStructure.Array;
using DataStructure.Sort.SortImpl;
using System;

namespace DataStructure.Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new Array<int>(10);
            Random rnd = new Random(100);
            for (int i = 0; i < 10; i++)
            {
                arr.Insert(i, rnd.Next(0, 100));
            }

            Console.WriteLine("Before sorting: ");
            arr.DisplayElements();
            Console.WriteLine("During sorting: ");
            BubbleSort.BubbleSortImpl(arr);
            Console.WriteLine("After sorting: ");
            arr.DisplayElements();

            //int[] testDatas = InitializeData(10000);

            //CodeTimer.Time("MergeSort_Test", 1, () =>
            //{
            //    SortingHelper<int>.MergeSort(testDatas, 0, testDatas.Length - 1);
            //});
            //PrintData(testDatas);

            //int[] smallDatas = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };
            //SortingHelper<int>.BubbleSort(smallDatas, new Comparison<int>((p1, p2) => p2 - p1));
            //PrintData(smallDatas);

        }

        #region 初始化数组

        static int[] InitializeData(int length = 100000)
        {
            int[] arrNumber = new int[length];
            // 首先生成有序数组进行初始化
            for (int i = 0; i < length; i++)
            {
                arrNumber[i] = i;
            }
            Random rand = new Random();
            // 随机将数组中的数字打乱顺序
            for (int i = 0; i < length; i++)
            {
                int randIndex = rand.Next(i, length);
                // 交换两个数字
                int temp = arrNumber[i];
                arrNumber[i] = arrNumber[randIndex];
                arrNumber[randIndex] = temp;
            }

            return arrNumber;
        }

        #endregion

        #region 打印数组

        static void PrintData(int[] arr)
        {
            Console.WriteLine("----------------------------------------------------\r\n");
            for (int i = 0, count = 1; i < arr.Length; i++, count++)
            {
                if (count % 10 == 0)
                {
                    count = 1;
                    Console.Write(arr[i]);
                    Console.WriteLine();
                }
                else
                {
                    count++;
                    Console.Write(arr[i] + " ");
                }
            }
            Console.WriteLine("\r\n----------------------------------------------------");
        }

        #endregion
    }
}
