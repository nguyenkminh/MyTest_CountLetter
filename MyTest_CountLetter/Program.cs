using System;

namespace MyTest_CountLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count Sum Letter from 1 - 1000: {0}", CountLetter.CountLetterFrom1To1000_LazyWay());
            Console.WriteLine("Count Sum Letter from 1 - 1000: {0}", CountLetter.CountLetterFrom1To1000());
        }
    }
    public class CountLetter
    {
        static readonly int[] my1s = {
                0,
                "one".Length,
                "two".Length,
                "three".Length,
                "four".Length,
                "five".Length,
                "six".Length,
                "seven".Length,
                "eight".Length,
                "nine".Length,
                "ten".Length,
                "eleven".Length,
                "twelve".Length,
                "thirteen".Length,
                "fourteen".Length,
                "fifteen".Length,
                "sixteen".Length,
                "seventeen".Length,
                "eighteen".Length,
                "nineteen".Length};
        static readonly int[] my10s = {
                        "twenty".Length,
                        "thirty".Length,
                        "forty".Length,
                        "fifty".Length,
                        "sixty".Length,
                        "seventy".Length,
                        "eighty".Length,
                        "ninety".Length};
        static readonly int hundred = "hundred".Length;

        public static int CountLetterFrom1To1000_LazyWay()
        {
            int count = "one".Length + "thousand".Length;

            for (int i = 1; i < 1000; i++)
                count += CountUnder1000(i);
            return count;
        }

        public static int CountLetterFrom1To1000()
        {
            int count = 11;//one thousand
            int count100s = 0;

            for (int i = 1; i < 100; i++)
                count100s += CountUnder1000(i);
            count += count100s;

            for (int i = 1; i < 10; i++)
            {
                count += CountUnder100(i) + hundred;// one hundred
                // "one hundred and" repeative 99 time + the sum from 1-99
                count += (CountUnder100(i) + hundred + "and".Length) * 99 + count100s;
            }


            return count;
        }

        static int CountUnder100(int number)
        {
            if (number < 20)
            {
                return my1s[number];
            }
            int x = number / 10;
            int y = number - x * 10;
            return my10s[x - 2] + my1s[y];

        }
        static int CountUnder1000(int number)
        {
            int x = number / 100;
            int y = number - x * 100;
            if (y == 0)
                return my1s[x] + hundred;
            if (x == 0)
                return CountUnder100(y);
            return my1s[x] + 10 + CountUnder100(y);
        }

    }
}
