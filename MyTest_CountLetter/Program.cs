using System;

namespace MyTest_CountLetter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Count Sum Letter from 1 - 1000: {0}",CountLetter.CountLetterFrom1To1000_LazyWay());
            Console.WriteLine("Count Sum Letter from 1 - 1000: {0}", CountLetter.CountLetterFrom1To1000());
        }
    }
    public class CountLetter
    {
        public static int CountLetterFrom1To1000_LazyWay()
        {
            int count = 11;//one thousand           
            
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
                count += CountUnder10(i) + 7;// one hundred
                // "one hundred and" repeative 99 time + the sum from 1-99
                count += (CountUnder10(i) + 10) * 99 + count100s;
            }


            return count;
        }


        static int CountUnder10(int number)
        {
            switch (number)
            {
                case 1:
                    return 3;// "one"
                case 2:
                    return 3;// "two"
                case 3:
                    return 5;// "three"
                case 4:
                    return 4;// "four"
                case 5:
                    return 4;// "five"
                case 6:
                    return 3;// "six"
                case 7:
                    return 5;// "seven"
                case 8:
                    return 5;// "eight"
                case 9:
                    return 4;// "nine"
            }
            return 0; // error
        }
        static int CountUnder100(int number)
        {
            if (number < 10)
            {
                return CountUnder10(number);
            }
            else if (number < 20)
            {
                switch (number)
                {
                    case 10:
                        return 3;// "ten"
                    case 11:
                        return 6;// "eleven"
                    case 12:
                        return 6;// "twelve"
                    case 13:
                        return 8;// "thirteen"
                    case 14:
                        return 8;// "fourteen"
                    case 15:
                        return 7;// "fifteen"
                    case 16:
                        return 7;// "sixteen"
                    case 17:
                        return 9;// "seventeen"
                    case 18:
                        return 8;// "eighteen"
                    case 19:
                        return 8;// "nineteen"
                }
            }
            else
            {

                int x = number / 10;
                int count1s = number - x * 10 > 0 ? CountUnder10(number - x * 10) : 0;
                switch (x)
                {
                    case 2:
                        return 6 + count1s;//"twenty"
                    case 3:
                        return 6 + count1s;//"thirty"
                    case 4:
                        return 5 + count1s;//"forty"
                    case 5:
                        return 5 + count1s;//"fifty"
                    case 6:
                        return 5 + count1s;//"sixty"
                    case 7:
                        return 7 + count1s;//"seventy"
                    case 8:
                        return 6 + count1s;//"eighty"
                    case 9:
                        return 6 + count1s;//"ninety"
                }

            }
            return 0;//error

        }
        static int CountUnder1000(int number)
        {
            if (number < 10)
            {
                return CountUnder10(number);
            }
            else if (number < 100)
            {
                return CountUnder100(number);
            }
            else
            {
                int my100s = number / 100;
                int myUnder100 = number - my100s * 100;
                if (myUnder100 > 0)
                    return CountUnder10(my100s) + 10
                        + CountUnder100(myUnder100);//10 is from " hundred and "
                else
                    return CountUnder10(my100s) + 7;


            }
        }

    }
}
