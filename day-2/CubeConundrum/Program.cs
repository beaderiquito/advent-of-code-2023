namespace CubeConundrum
{
    public class GameConfigurationChecker
    {
        static void Main(string[] args)
        {
            // Initialize values
            int idTotal = 0;
            int powerTotal = 0;
            int validRed = 12;
            int validGreen = 13;
            int validBlue = 14;
            
            // Open the file
            StreamReader sr = new StreamReader("D:\\Interview Practice\\advent-of-code-2023\\day-2\\input.txt");

            // Loop through each line in the text file
            string line;
            string[] separators = { "Game ", ": " };

            while ((line = sr.ReadLine()) != null)
            {
                int powerSubTotal = 0;
                string[] gameInfo = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                // Retrieve Game Set Info
                Game game = new Game(gameInfo[0], gameInfo[1]);
                
                // For Part 1
                bool isGameValid = game.isValid(validRed, validGreen, validBlue);
                if (isGameValid) idTotal += game.gameId;
                

                // For Part 2
                powerSubTotal = game.powerTotal;
                powerTotal += powerSubTotal;

                Console.WriteLine($"{game.gameId} => isGameValid = {isGameValid} => powerSubTotal = {powerSubTotal}");

            }
            // For Part 1
            Console.WriteLine($"idtotal = {idTotal}");

            // For Part 2
            Console.WriteLine($"powerTotal = {powerTotal}");
        }
    }

    public class Game
    {
        public int gameId
        { get; set; }
        public int maxRed
        { get; set; }
        public int maxGreen
        { get; set; }
        public int maxBlue
        { get; set; }
        public List<GameSet> gameSets = new List<GameSet>();
        public int powerTotal
        { get; set; }


        public Game(string gameId, string gameInfo)
        {
            this.gameId = Int32.Parse(gameId);
            this.maxRed = 0;
            this.maxGreen = 0;
            this.maxBlue = 0;

            string[] infoStringArray = gameInfo.Split("; ");
            foreach (string infoString in infoStringArray)
            {
                GameSet gameSet = new GameSet(infoString);
                this.gameSets.Add(gameSet);

                if (gameSet.redCount > this.maxRed) this.maxRed = gameSet.redCount;
                if (gameSet.greenCount > this.maxGreen) this.maxGreen= gameSet.greenCount;
                if (gameSet.blueCount > this.maxBlue) this.maxBlue= gameSet.blueCount;
            }

            this.powerTotal = this.maxRed * this.maxGreen * this.maxBlue;
        }

        // For Part 1
        public bool isValid(int redCount, int greenCount, int blueCount)
        {
            foreach (GameSet gameSet in this.gameSets)
            {
                if (gameSet.redCount > redCount) return false;
                if (gameSet.greenCount > greenCount) return false;
                if (gameSet.blueCount > blueCount) return false;
            }

            return true;
        }
    }

    public class GameSet
    {
        public int redCount
        { get; set; }
        public int blueCount
        { get; set; }
        public int greenCount
        { get; set; }

        public GameSet(string gameSetInfo)
        {

            this.redCount = 0;
            this.blueCount = 0;
            this.greenCount = 0;

            string[] infoStringArray = gameSetInfo.Split(", ");
            foreach (string infoString in infoStringArray)
            {
                string[] countInfoArray = infoString.Split(' ');
                int count = Int32.Parse(countInfoArray[0]);

                if (countInfoArray[1].Equals("red")) this.redCount = count;
                else if (countInfoArray[1].Equals("green")) this.greenCount = count;
                else if (countInfoArray[1].Equals("blue")) this.blueCount = count;
            }
        }
    }
}
