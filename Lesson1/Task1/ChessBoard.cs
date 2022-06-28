namespace Chess
{
    public class ChessBoard
    {
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public static void DrawBoard(Player player1, Player player2) { 
        }
        public Settings settings { get; set; }
        public bool Save() { return true; }
        public bool Load() { return true; }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
