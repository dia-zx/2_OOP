namespace Chess
{
    /// <summary>
    /// Класс описывающий игрока (человека / компьютера)
    /// </summary>
    public class Player
    {
        public bool IsHuman { get; set; }
        public FigureColor Color { set; get; }
        public int Score { get; set; }
        public List<Figure> Figures { get; set; } = new List<Figure>();
        public void Reset()
        {

        }
    }
}
