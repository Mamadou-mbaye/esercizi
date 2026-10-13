
public class PuzzleOne
{
    private readonly string puzzleFilePath = "./puzzleOne.txt";
    public void ReadFile()
    {
        var lines = File.ReadAllLines(puzzleFilePath);
        int position = 50;
        int secretCode = 0;
        foreach (var line in lines)
        {
            char direction = line[0];
            _ = int.TryParse(line[1..], out int rotate);
            if (rotate == 0) continue;
            position = ChangePosition(position, rotate, direction);
            if (position == 0) secretCode++;
        }
        Console.WriteLine("Secret code: " + secretCode);
    }
    private int ChangePosition(int position, int rotate, char direction)
    {
        // setto positivo o negativo in base alla rotazione
        int delta = direction == 'L' ? -rotate : rotate;
        int totale = position + delta;
        //quanto resta dopo che abbiamo tolto tutti i possibili 100 dal totale
        int result = (totale) % 100;
        //Se negativo allora portarlo al positivo, non faccio math-abs perché non ci interessa il numero assoluto ma ci interresso di riportare il numero in positivo
        if (result < 0) result += 100;
        return result;
    }
    // private int ChangePosition(int position, int rotate, char direction)
    // {
    //     int value = 0;
    //     int minValue = 0;
    //     int maxValue = 99;
    //     if (direction.Equals('L'))
    //     {
    //         value = ChangePositionToLeft(position, rotate, maxValue, minValue);
    //     }
    //     else if (direction.Equals('R'))
    //     {
    //         value = ChangePositionToRight(position, rotate, maxValue, minValue);
    //     }
    //     return value;
    // }
    private int ChangePositionToLeft(int position, int rotate, int maxValue, int minValue)
    {
        while (rotate > 0)
        {
            position--;
            if (position < minValue) position = maxValue;
            rotate--;
        }
        return position;
    }
    private int ChangePositionToRight(int position, int rotate, int maxValue, int minValue)
    {
        while (rotate > 0)
        {
            position++;
            if (position > maxValue) position = minValue;
            rotate--;
        }
        return position;
    }

}