using LuhnNet;

string luhn, state;
int n = 10;
state = "is";
if (args.Length == 1 && args[0].ToLower().Equals("-c"))
{
    Console.Write("Enter a number to validate: ");
    luhn = Console.ReadLine();
    state = Luhn.IsValid(luhn) ? "is" : "is not";
    Console.WriteLine($"{luhn} is {luhn.Length} characters long.\r\nIt {state} a valid Luhn number!");
}
else if (args.Length == 1 && int.TryParse(args[0], out n))
{
    Console.WriteLine($"{n} test numbers requested!");
}
else
{
    Console.WriteLine($"Here are {n} test numbers!");
}
for (int i = 1; i <= n; i++)
{
    Console.WriteLine(Luhn.Generate());
}
Console.ReadKey();
