
public class PuzzleOne
{
    private readonly string puzzleFilePath = "./puzzleOne.txt";
    private long sumInvalidID =0;
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
            // TrovaInvalid(inizioRange, fineRange);
            TrovaInvalidOttimizzato(inizioRange, fineRange);
            // Console.WriteLine(range);
        }
        Console.WriteLine("Sum of invalid ID: " + sumInvalidID);
    }
    private void TrovaInvalid(long inizioRange,long fineRange)
    {
        for (long i = inizioRange; i <= fineRange  ; i++)
        {
            string value = i.ToString();
            if (value.Length % 2 != 0) continue;
            int valueLen = value.Length / 2;
            _ = long.TryParse(value[..valueLen], out long firstSequence);
            _ = long.TryParse(value.Substring(valueLen, valueLen), out long secondSequence );
            if (firstSequence == secondSequence)
            {
                sumInvalidID += i;
            }
        }
    }
    private void TrovaInvalidOttimizzato(long inizioRange, long fineRange)
{
    // Troviamo quante cifre ha il numero più grande del range
    int maxDigits = fineRange.ToString().Length;

    // Controlliamo solo le lunghezze pari (es. 2, 4, 6, 8, 10 cifre)
    for (int totalLen = 2; totalLen <= maxDigits; totalLen += 2)
    {
        int halfLen = totalLen / 2;

        // "n" è la sequenza che viene ripetuta due volte
        // Esempio: se halfLen = 3, n va da 100 a 999 (numeri a 3 cifre)
        long minN = (long)Math.Pow(10, halfLen - 1);
        long maxN = (long)Math.Pow(10, halfLen) - 1;

        // Caso speciale: se halfLen = 1, n va da 1 a 9 (niente zero iniziale)
        if (halfLen == 1) minN = 1;

        for (long n = minN; n <= maxN; n++)
        {
            // Costruiamo il numero ripetendo n due volte
            // Esempio: n = 446 -> 446 * 1000 + 446 = 446446
            long candidato = n * (long)Math.Pow(10, halfLen) + n;

            // Controlliamo se il candidato cade dentro il nostro range
            if (candidato >= inizioRange && candidato <= fineRange)
            {
                sumInvalidID += candidato;
            }
        }
    }
}
    // Time Elapsed 00:00:05.09 - 8576933996
    
}


