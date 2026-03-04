using LuhnNet;

string luhn, state, sansCheck;
int n = 10;
state = "is";
bool doCheck = args.Length == 1 && args[0].ToLower().Equals("-c");
if (doCheck)
{
    Console.Write("Enter a number to validate: ");
    luhn = Console.ReadLine();
    sansCheck = luhn.Remove(luhn.Length - 1);
    state = Luhn.IsValid(luhn) ? "is" : "is not";
    Console.WriteLine($"{luhn} is {luhn.Length} characters long.\r\nIt {state} a valid Luhn number:\r\nSum: {Luhn.Sum(sansCheck)}\r\nCheck Digit: {Luhn.CalculateCheckDigit(sansCheck)}");
}
else if (args.Length == 1 && int.TryParse(args[0], out n))
{
    Console.WriteLine($"{n} test numbers requested!");
}
else
{
    if (n == 0)
        n = new Random().Next(1, 50);
    Console.WriteLine($"Here are {n} test numbers!");
}
if (!doCheck)
{
    for (int i = 1; i <= n; i++)
    {
        Console.WriteLine(Luhn.Generate());
    }
}
Console.ReadKey();
