
using System.Security.Cryptography.X509Certificates;

public class PuzzleOne
{
    private readonly string puzzleFilePath = "./puzzleOne.txt";

    public void Run()
    {
        // string bank = "";
        int totalJoltage = 0;
        List<string> listBanks = GetListBanks(puzzleFilePath);

        foreach (var item in listBanks)
        {
            if (string.IsNullOrWhiteSpace(item)) continue;
            // string data = "81818119112111"; // Example string
            List<int> bank = item.Select(c => c - '0').ToList();
            totalJoltage += GetMaxJoltage(bank);
        }
        Console.WriteLine(totalJoltage);
    }
    public List<string> GetListBanks(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        return lines.AsEnumerable().ToList();
    }


    private int GetMaxJoltage(List<int> bank)
    {
        int maxDigitValue = bank.Max();
        int idxMaxNumber = bank.IndexOf(maxDigitValue);
        int secondMaxNumber = 0;

        if (idxMaxNumber == bank.Count - 1)
        {
            secondMaxNumber = maxDigitValue;
            maxDigitValue = bank
            .Where((item, idx) => idx != idxMaxNumber)
            .ToList()
            .Max();
        }
        else
        {
            secondMaxNumber = bank
            .Where((item, idx) => idx > idxMaxNumber)
            .ToList()
            .Max();
        }
        return  maxDigitValue * 10 + secondMaxNumber ;
    }
}


