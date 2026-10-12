using RougeLike;

string levelFile = Path.Combine(AppContext.BaseDirectory, "Level1.txt");
if (!File.Exists(levelFile))
{
    Console.WriteLine($"Could not find level file: {levelFile}");
    return;
}

new Game().Start(levelFile);
