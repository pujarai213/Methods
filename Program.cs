Console.WriteLine("Number Guessing Game");
string name = AskName();
Console.WriteLine($"Hello, {name}! I'm thinking of a number between 1 and 100. ");

int secret = Random.Shared.Next(1, 101);
const int MaxAttempts = 7;

bool won = PlayRound(secret, MaxAttempts, out int attemptsUsed);

if (won) Console.WriteLine($"Correct, {name}! You got it in {attemptsUsed} attempts. ");
else Console.WriteLine($"Out of attempts. The number was {secret}.");

string AskName()
{
    Console.Write("What is your name?");
    string? text = Console.ReadLine();
    return string.IsNullOrWhiteSpace(text) ? "player" : text.Trim();
}

int? ReadGuess(int attemptNumber, int limit)
{
    Console.Write($"Attempt {attemptNumber}/{limit}. Your guess: ");
    string? input = Console.ReadLine();
    return int.TryParse(input, out int value) ? value : null;
}

bool PlayRound(int target, int limit, out int attempts)
{
    attempts = 0;
    while (attempts < limit)
    {
        int? guess = ReadGuess(attempts + 1, limit);
        if (guess is null)
        {
            Console.WriteLine("Please type a whole number.");
            continue;
        }
        attempts++;

        if (guess == target) return true;
        Console.WriteLine(guess < target ? "Too low!" : "Too high!");
    }
    return false;
}