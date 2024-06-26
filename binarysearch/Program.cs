﻿
using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
string array_range;
string search_data;

for (; ; )
{



    for (; ; )
    {
        Console.WriteLine("配列の範囲を指定してください(9桁以内)");

        array_range = Console.ReadLine() + "";

        if ((Regex.IsMatch(array_range, @"^[0-9]+$")) == true && array_range.Length < 10)
        {
            break;
        }
        else
        {
            Console.WriteLine("数値以外が入力されました。または小数点が含まれているか、入力桁がオーバーしています");
        }

    }

    var array = Enumerable.Range(1, Convert.ToInt32(array_range)).ToArray();

    for (; ; )
    {
        Console.WriteLine("探索するデータの値を入力してください");

        search_data = Console.ReadLine() + "";

        if (Regex.IsMatch(search_data, @"^[0-9]+$") == true && search_data.Length < 10)
        {

            if (Convert.ToInt32(search_data)<=Convert.ToInt32(array_range))
            {

                break;
            }
            else
            {
                Console.WriteLine("データが配列の範囲外の値です");
            }
        }
        else
        {
            Console.WriteLine("数値以外が入力されました。または小数点が含まれているか、入力桁がオーバーしています");
        }

    }

    Console.WriteLine("探索を開始します\n");

    var sw = new Stopwatch();
    sw.Start();
    int min = 0;
    int abs_max = Convert.ToInt32(array_range);
    int max = Convert.ToInt32(array_range);
    int mid = max / 2;
    int goal_num = Convert.ToInt32(search_data);
    int count=0;


    count++;
    Console.WriteLine("{0}:中央値:{1}", count, mid);

    for (; ; )
    {
        if (mid < goal_num)
        {

            if (mid + 1 == abs_max)
            {
                count++;
                Console.WriteLine("{0}:中央値:{1}", count,mid+1);
                Console.WriteLine("\n探索完了\n");
                break;
            }


            min = mid;
            mid = mid + ((max - min) / 2);

        }
        else if (mid > goal_num)
        {

            if (mid - 1 == 0)
            {
                count++;
                Console.WriteLine("{0}:中央値:{1}",count, mid - 1);
                Console.WriteLine("\n探索完了\n");
                break;
            }

            max = mid;
            mid = min + ((max - min) / 2);
          
        }
        else if (mid == goal_num)
        {
            Console.WriteLine("\n探索完了\n");
            break;
        }
        count++;
        Console.WriteLine("{0}:中央値:{1}",count, mid);
    }

    sw.Stop();

    
    Console.WriteLine($"探索時間: {TimeSpan.FromTicks(sw.ElapsedTicks)}, 対象データ: {goal_num}, 試行回数:{count}");

    for (; ; )
    {
        Console.WriteLine("探索を続けますか? ,YES = 1 ,NO = 0");

        string read = Console.ReadLine() + "";

        if (read == "1")
        {
            break;
        }
        else if (read == "0")
        {
            return;
        }

    }

}