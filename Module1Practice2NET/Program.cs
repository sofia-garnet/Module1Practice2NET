using System;

namespace Module1Practice2NET
{
    public class Program
    {
        private const int LetterBeforeAlphabetic = 96;
        private static int[] lettersToCapitalize = new int[] { 97, 101, 105, 100, 104, 106 };

        public static void Main(string[] args)
        {
             // array size have to be not negative
            // better use try pare to escape exteptions.
             var arraySize = int.Parse(Console.ReadLine());

             var numbersArray = new int[] { 10, 1, 3, 2, 8 };

             // new int[arraySize];
             FillByNumbers(numbersArray);
             var oddNumbers = FetchOddNumbers(numbersArray);
             var evenNumbers = FetchEvenNumbers(numbersArray);

             Letterize(oddNumbers);
             Letterize(evenNumbers);

             var firstArrayCapitalLettersCount = CountCapitalLetters(oddNumbers);
             var secondArrayCapitalLettersCount = CountCapitalLetters(evenNumbers);

             if (firstArrayCapitalLettersCount > secondArrayCapitalLettersCount)
            {
                ShowArrayAsCharString(oddNumbers);
            }
            else
            {
                ShowArrayAsCharString(evenNumbers);
            }

             void ShowArrayAsCharString(int[] numbersArray)
            {
                for (var i = 0; i < numbersArray.Length; i++)
                {
                    Console.Write((char)numbersArray[i] + (i + 1 == numbersArray.Length ? string.Empty : ","));
                }
            }

             int CountCapitalLetters(int[] numbersArray)
            {
                var count = 0;

                for (var i = 0; i < numbersArray.Length; i++)
                {
                    if (char.IsUpper((char)numbersArray[i]))
                    {
                        count++;
                    }
                }

                return count;
            }

             void Letterize(int[] numbersArray)
            {
                for (var i = 0; i < numbersArray.Length; i++)
                {
                    var currentNumber = numbersArray[i] + LetterBeforeAlphabetic;
                    for (var j = 0; j < lettersToCapitalize.Length; j++)
                    {
                        if (currentNumber == lettersToCapitalize[j])
                        {
                            currentNumber = char.ToUpper((char)currentNumber);
                            break;
                        }
                    }

                    numbersArray[i] = currentNumber;
                }
            }

             int[] FetchOddNumbers(int[] numbersArray)
            {
                var result = new int[0];
                for (var i = 0; i < numbersArray.Length; i++)
                {
                    if (numbersArray[i] % 2 == 1)
                    {
                        result = Add(result, numbersArray[i]);
                    }
                }

                return result;
            }

             int[] FetchEvenNumbers(int[] numbersArray)
            {
                var result = new int[0];
                for (var i = 0; i < numbersArray.Length; i++)
                {
                    if (numbersArray[i] % 2 == 0)
                    {
                        result = Add(result, numbersArray[i]);
                    }
                }

                return result;
            }

             void FillByNumbers(int[] arr)
            {
                var r = new Random();
                for (var i = 0; i < arr.Length; i++)
                {
                    arr[i] = r.Next(1, 27);
                }
            }
        }

        public static int[] Add(int[] target, int item)
        {
            var result = new int[target.Length + 1];
            target.CopyTo(result, 0);
            result[target.Length] = item;
            return result;
        }
    }
}
