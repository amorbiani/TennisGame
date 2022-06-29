using TennisGame;

Console.WriteLine("------------------");
Console.WriteLine("CONSOLE TENNIS GAME");
Console.WriteLine("------------------");

TennisMatch match = InitializeMatch();

match.Menu();

// Method for initializing match requirements
TennisMatch InitializeMatch()
{
    string namePlayer1;
    string namePlayer2;

    Console.WriteLine();

    do
    {
        Console.WriteLine("Insert Name Player1: ");
        namePlayer1 = Console.ReadLine();
    } while (namePlayer1.Length < 1);


    Console.WriteLine();

    do
    {
        Console.WriteLine("Insert Name Player2: ");
        namePlayer2 = Console.ReadLine();
    } while (namePlayer2.Length < 1);

    TennisPlayer player1 = new TennisPlayer(namePlayer1);
    TennisPlayer player2 = new TennisPlayer(namePlayer2);

    return new TennisMatch(player1, player2);
}
