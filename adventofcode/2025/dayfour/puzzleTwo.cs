public class PuzzleTwo
{
    private readonly string puzzleFilePath = AppContext.BaseDirectory + "./puzzleOne.txt";

    public void Run()
    {
        string[] grid = File.ReadAllLines(puzzleFilePath);

        long totRemoved = 0;
        bool canAcces = true;
        while (canAcces)
        {
            List<Coordinate> listCandidate = new();
            long result = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                Console.WriteLine("--------------------------------");
                string row = grid[i];
                for (int y = 0; y < row.Length; y++)
                {
                    if (row[y] != '@')
                        continue;
                    char left = '.';
                    char right = '.';
                    char top = '.';
                    char bottom = '.';
                    char topLeft = '.';
                    char topRight = '.';
                    char bottomLeft = '.';
                    char bottomRight = '.';

                    if (y > 0)
                        left = row[y - 1];
                    if (y + 1 < row.Length)
                        right = row[y + 1];
                    if (i > 0)
                    {
                        top = grid[i - 1][y];
                        if (y > 0)
                            topLeft = grid[i - 1][y - 1];

                        if (y + 1 < row.Length)
                            topRight = grid[i - 1][y + 1];
                    }
                    if (i + 1 < grid.Length)
                    {
                        bottom = grid[i + 1][y];
                        if (y > 0)
                            bottomLeft = grid[i + 1][y - 1];
                        if (y + 1 < row.Length)
                            bottomRight = grid[i + 1][y + 1];
                    }
                    string rol =
                        $"{left}{right}{top}{bottom}{topLeft}{topRight}{bottomLeft}{bottomRight}";

                    int count = rol.Count(c => c == '@');
                    Console.WriteLine("Rol of paper: " + rol + " Count: " + count);
                    if (count < 4)
                    {
                        result += 1;
                        listCandidate.Add(new Coordinate(i, y));
                    }
                }
            }
            Console.WriteLine("Result: " + result);
            if (result == 0)
                canAcces = false;
            totRemoved += listCandidate.Count;
            Console.WriteLine(listCandidate);
	    
	    grid = RemoveCandidate(grid, listCandidate);
}}
	
	
private string [] RemoveCandidate(string [] grid , List<Coordinate> listCoordinate){

	List<string> listRecord = grid.ToList();
	
	foreach(var coordinate in listCoordinate){
	    listRecord.Index(coordinate); 
	}
    
return grid;
}
}

    public class Coordinate
    {
        private int _xCordinate;
        private int _yCordinate;

        public Coordinate(int xCordinate, int yCordinate)
        {
            _xCordinate = xCordinate;
            _yCordinate = yCordinate;
        }
    }

