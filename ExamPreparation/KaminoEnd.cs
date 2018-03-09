using System;
using System.Collections.Generic;
using System.Linq;

namespace E2
{

    public class KaminoEnd
    {
        public static void Main()
        {
            string[] bestDna = null;
            int bestLength = -1;
            int leftIndex = -1;
            int sumBest = 0;
            int bestSampleIndex = 0;

            int seqLength = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int sampleIndex = 0;

            while (input != "Clone them!")
            {
                string[] currentDna = input.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries);
                int currentLength = 0;
                int currentMaxLength = 0;
                int biggestSeqStartIndex = 0;

                int currentSum = currentDna.Select(int.Parse).ToArray().Sum();
                
                for (int i = 0; i < currentDna.Length; i++)
                {
                    if (currentDna[i] == "1")
                    {
                        currentLength++;
                       
                        if (currentLength > currentMaxLength)
                        {
                            currentMaxLength = currentLength;
                            biggestSeqStartIndex = i - currentLength + 1;
                        }
                    }
                    else
                    {
                        currentLength = 0;
                    }
                }
                
                bool isCurrentBest = false;

                if (currentMaxLength > bestLength)
                {
                    isCurrentBest = true;
                }
                else if (currentMaxLength == bestLength)
                {
                    if (biggestSeqStartIndex < leftIndex)
                    {
                        isCurrentBest = true;
                    }
                    else if(biggestSeqStartIndex == leftIndex)
                    {
                        if (currentSum > sumBest)
                        {
                            isCurrentBest = true;
                        }
                    }
                }
                
                sampleIndex++;

                if (isCurrentBest)
                {

                    bestDna = currentDna;
                    bestLength = currentMaxLength;
                    leftIndex = biggestSeqStartIndex;
                    bestSampleIndex = sampleIndex;
                    sumBest = currentSum;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {sumBest}.");
            Console.WriteLine($"{string.Join(" ", bestDna)}");
        }
    }
}