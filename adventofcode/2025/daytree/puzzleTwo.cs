
public class PuzzleTwo
{
    private readonly string puzzleFilePath = "./puzzleOne.txt";

    public void Run()
    {
        long totalJoltage = 0;
        List<string> listBanks = GetListBanks(puzzleFilePath);
        foreach (var item in listBanks)
        {
            if (string.IsNullOrWhiteSpace(item)) continue;
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

    private long GetMaxJoltage(List<int> bank)
    {
        int numberLen = 12;
        List<int> listaContainer = new();

        int budget = bank.Count - numberLen;
        for (int i = 0; i <= bank.Count - 1; i++)
        {
            int item = bank[i];
            int lastItem = listaContainer.LastOrDefault();
            while (listaContainer.Count != 0 && lastItem < item && budget > 0)
            {
                listaContainer.RemoveAt(listaContainer.Count - 1);
                lastItem = listaContainer.LastOrDefault();
                budget--;
            }
            listaContainer.Add(item);
        }

        if (listaContainer.Count > numberLen)
            listaContainer = listaContainer. Take(12).ToList();
        long result =long.Parse(string.Join("", listaContainer));
        return result ;
    }
}