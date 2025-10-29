using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int userNumber;
        do
        {
            Console.Write("Enter number: ");
            string userResponse = Console.ReadLine();

            // Safety parse 
            if (int.TryParse(userResponse, out userNumber))
            {
                if (userNumber == 0)
                    break;

                numbers.Add(userNumber);
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        } while (true);

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Average
        int average = sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine($"The largest number is: {max}");
    }
}