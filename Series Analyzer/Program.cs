using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        List<int> StandardList = InputFromUser();
        Menu(StandardList);


        List<int> InputFromUser()
        {
            Console.WriteLine("Please enter a series of numbers separated by a space: ");
            string input = Console.ReadLine()!;
          
            List<int> SuitableNumbers = new List<int>();
            string[] parts = input.Split(' ');

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    SuitableNumbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"{part} is Not a valid number");
                }
            }

            if (NumberOfValue(SuitableNumbers) >= 3)
                {
                    return SuitableNumbers;
                }
            else
            {
                return InputFromUser();
            }

        }



        void Menu(List<int> series)
        {
            while (true)
            {
                Console.WriteLine("Please enter your choice:\n" +
                "1. Enter a new series\n" +
                "2. Display the series as entered\n" +
                "3. Display the series in reverse order\n" +
                "4. Display the series in ascending order\n" +
                "5. Display the maximum value in the series\n" +
                "6. Display the minimum value in the series\n" +
                "7. Display the average of the series\n" +
                "8. Display the number of values in the series\n" +
                "9. Display the sum of the values in the series\n" +
                "10. Exit");


                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        series = InputFromUser();
                        break;
                    case "2":
                        Printer(PrintingOriginalSeries(series));
                        break;

                    case "3":
                        Printer(PrintRevers(series));
                        break;

                    case "4":
                        Printer(PrintSorted(series));
                        break;

                    case "5":
                        Console.WriteLine(maximum(series));
                        break;

                    case "6":
                        Console.WriteLine(minimum(series));
                        break;

                    case "7":
                        Console.WriteLine(average(series));
                        break;

                    case "8":
                        Console.WriteLine(NumberOfValue(series));
                        break;

                    case "9":
                        Console.WriteLine(SumOfValue(series));
                        break;

                    case "10":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }

            }
        }

    }

    static void Printer(List<int> function)
    {
        foreach (int i in function)
        {
            Console.WriteLine(i);
        }
    }



    static List<int> PrintingOriginalSeries(List<int> seriesList)
    {
        List<int> originalList = new List<int>();

        foreach (int i in seriesList)
        {
             originalList.Add(i);
        }
        return originalList;

    }

    static List<int> PrintRevers(List<int> seriesList)
    {
        List<int> ReversList = new List<int>();

        for (int i = NumberOfValue(seriesList) - 1; i >= 0; i--)
        {
            ReversList.Add(seriesList[i]);
        }
        return ReversList;
    }


    static List<int> PrintSorted(List<int> seriesList)
    {
        List<int> sortedlist = new List<int>(seriesList);

        for (int i = 0; i < NumberOfValue(sortedlist) - 1; i++)
        {
            for(int j = 0; j < NumberOfValue(sortedlist) - 1; j++)
            {
                if (sortedlist[j] > sortedlist[j+1])
                {
                    int temp = sortedlist[j];
                    sortedlist[j] = sortedlist[j+1];
                    sortedlist[j+1] = temp;
                }
            }
        }
        return sortedlist;
        
    }


    static int maximum(List<int> seriesList)
    {
        int bigger = seriesList[0];

        for (int i = 1; i < NumberOfValue(seriesList); i++)
        {
            if (seriesList[i] > bigger)
            {
                bigger = seriesList[i];
            }
        }
        return bigger; 
    }


    static int minimum(List<int> seriesList)
    {
        int small = seriesList[0];

        for (int i = 1; i < NumberOfValue(seriesList); ++i)
        {
            if (seriesList[i] < small)
            {
                small = seriesList[i];
            }
        }
        return small;
    }

    
    static int average(List<int> seriesList)
    {
        int average = 0;
        int len = NumberOfValue(seriesList);
        int SomOfList = 0;

        foreach (var item in seriesList)
        {
            SomOfList += item;
        }
        average = SomOfList / len;
        return average;
    }


    static int NumberOfValue(List<int> seriesList)
    {
        int counter = 0;
        foreach(var item in seriesList)
        {
            counter++;
        }
        return counter;
    }


    static int SumOfValue(List<int> seriesList)
    {
        int sum = 0;
        foreach(int item in seriesList)
        {
            sum += item;
        }
        return sum;
    }
}

