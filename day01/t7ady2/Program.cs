int highscore = 0;
string highscorePlayer = "";

UpdateHighscore(50, "abdo");
UpdateHighscore(42069, "abood");
UpdateHighscore(420, "3oobad");

void UpdateHighscore(int score, string playerName)
{
    if (score > highscore)
    {
        Console.WriteLine($"New high score is {score}");
        Console.WriteLine($"New high score player is {playerName}");
        highscore = score;
        highscorePlayer = playerName;
    }
    else
    {
        Console.WriteLine($"The old high score of {highscore} could not be broken and is still held by {highscorePlayer}.");
        Console.WriteLine($"{highscorePlayer} is still the WWE HEAVY WEIGHT CHAMPION");
    }
}
