using System;

namespace Base_Number_Conversion
{
    public static class Util
    {
        public static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input)) return "0";

            string output = "";

            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }

            return output;
        }
        public static int dec2bin(int number)
        {
            string output = "";
            int x = number;
            while (x > 0)
            {
                output += (x % 2);
                x = x / 2;
            }
            output = ReverseString(output);
            return Int32.Parse(output);
        }

        public static int dec2oct(int number)
        {
            string output = "";
            int x = number;

            while (x > 0)
            {
                output += (x % 8);
                x = x / 8;
            }
            output = ReverseString(output);
            return Int32.Parse(output);
        }

        public static int bin2dec(int number)
        {
            int output = 0;
            string input = number.ToString();
            int power = input.Length - 1;

            int x = 0;
            int y = 0;


            for (int i = 0; i < input.Length; i++)
            {
                x = Int32.Parse(input[i].ToString());
                y = (int)Math.Pow(2, power);

                output += x * y;
                power--;
            }

            return output;
        }

        public static int bin2oct(int number) => dec2oct(bin2dec(number));


        public static int oct2dec(int number)
        {
            int output = 0;
            string input = number.ToString();
            int power = input.Length - 1;

            int x = 0;
            int y = 0;

            for (int i = 0; i < input.Length; i++)
            {
                x = Int32.Parse(input[i].ToString());
                y = (int)Math.Pow(8, power);

                output += x * y;
                //output += (input[i]) * ((int)Math.Pow(8, power));
                power--;
            }

            return output;
        }

        public static int oct2bin(int number) => dec2bin(oct2dec(number));

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the integer to convert: ");
            string n1 = Console.ReadLine();
            int number = int.Parse(n1);

            Console.Write("Please enter the base to convert from [2 | 8 | 10] : ");
            string n2 = Console.ReadLine();
            int from = int.Parse(n2);

            Console.WriteLine($"Number: {number}, base : {from}");
            int result = 0;

            if (from == 10)
            {
                result = Util.dec2bin(number);
                Console.WriteLine($"binary conversion is {result}");
                result = Util.dec2oct(number);
                Console.WriteLine($"octal conversion is {result}");
            }
            else if (from == 2)
            {
                result = Util.bin2dec(number);
                Console.WriteLine($"decimal conversion is {result}");
                result = Util.bin2oct(number);
                Console.WriteLine($"octal conversion is {result}");
            }
            else if (from == 8)
            {
                result = Util.oct2bin(number);
                Console.WriteLine($"binary conversion is {result}");
                result = Util.oct2dec(number);
                Console.WriteLine($"decimal conversion is {result}");
            }
            else
                Console.WriteLine("Error in base to convert from");
        }
    }
}

