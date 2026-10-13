
public class PuzzleTwo
{
    private readonly string puzzleFilePath = "./puzzleOne.txt";
    private readonly HashSet<long> invalidNumbers = new();
    public void ReadFile()
    {
        var lines = File.ReadAllLines(puzzleFilePath);
        //Aggiungere tutti i range nella lista
        List<string> ranges = [.. lines[0].ToString().Split(",")];
        foreach (string range in ranges)
        {
            var rangeArr = range.Split("-");
            _ = long.TryParse(rangeArr[0].ToString(), out long inizioRange);
            _ = long.TryParse(rangeArr[1].ToString(), out long fineRange);
            TrovaInvalid(inizioRange, fineRange);
        }

        long sumInvalidID = invalidNumbers.Sum();
        Console.WriteLine("Sum of invalid ID: " + sumInvalidID);
    }
    private void TrovaInvalid(long inizioRange, long fineRange)
    {
        // Troviamo quante cifre ha il numero più grande del range
        int maxDigits = fineRange.ToString().Length;
        for (int totalLen = 2; totalLen <= maxDigits; totalLen++)
        {
            for (int blockLen = 1; blockLen < totalLen; blockLen++)
            {
                if (totalLen % blockLen != 0) continue;
                int repeatCount = totalLen / blockLen;

                long minBlock = (long)Math.Pow(10, blockLen - 1);
                long maxBlock = (long)Math.Pow(10, blockLen) - 1;
                if (blockLen == 1) minBlock = 1;

                for (long block = minBlock; block <= maxBlock; block++)
                {
                    string blockStr = block.ToString();
                    string repeated = string.Concat(Enumerable.Repeat(blockStr, repeatCount));
                    long candidato = long.Parse(repeated);

                    if (candidato >= inizioRange && candidato <= fineRange)
                    {
                            invalidNumbers.Add(candidato);
                    }
                }
            }
        }
    }
}