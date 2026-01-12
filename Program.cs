using System.Numerics;


class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Run();
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the dice throwing simulator!");
        Console.Write("How many dice rolls would you like to simulate? ");
        int rolls = int.Parse(Console.ReadLine()!);

        DiceSimulator simulator = new DiceSimulator();
        int[] results = simulator.RollDice(rolls);

        DisplayResults(results, rolls);

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
    }

    private void DisplayResults(int[] results, int totalRolls)
    {
        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine($"Total number of rolls = {totalRolls}.");

        for (int i = 2; i <= 12; i++)
        {
            int percentage = (int)Math.Round((results[i] / (double)totalRolls) * 100);
            Console.WriteLine($"{i}: {new string('*', percentage)}");
        }
    }
}

class DiceSimulator
{
    private Random random = new Random();

    public int[] RollDice(int numberOfRolls)
    {
        int[] rollCounts = new int[13]; 

        for (int i = 0; i < numberOfRolls; i++)
        {
            int die1 = random.Next(1, 7);
            int die2 = random.Next(1, 7);
            int sum = die1 + die2;
            rollCounts[sum]++;
        }

        return rollCounts;
    }
}
