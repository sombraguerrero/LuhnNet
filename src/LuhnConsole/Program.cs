using LuhnNet;

string luhn, state;
state = "is";
if (args.Length == 1 && args[0].ToLower().Equals("-c"))
{
    Console.Write("Enter a number to validate: ");
    luhn = Console.ReadLine();
    state = Luhn.IsValid(luhn) ? "is" : "is not";
    Console.WriteLine($"{luhn} {state} a valid Luhn number!");
}
else
{
    for (int i = 1; i <= 10; i++)
    {
        Console.WriteLine(Luhn.Generate());
    }
}
Console.ReadKey();
