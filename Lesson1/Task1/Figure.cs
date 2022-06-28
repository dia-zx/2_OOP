namespace Chess
{
    public enum FigureColor : byte{
        White = 0, Black = 1
    }

    public enum FigureType : byte
    {
        pawn = 0,//пешка
        rook = 1,//ладья
        horse = 2,// конь
        elephant = 3,// слон
        queen = 4, //ферзь
        king = 5, // король
    }

    /// <summary>
    /// абстрактный клас описывающий фигуру
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// цвет фигуры
        /// </summary>
        public FigureColor Color { get; set; }
        /// <summary>
        /// тип фигуры
        /// </summary>
        public FigureType Type { get; set; }
        /// <summary>
        /// ценность фигуры (может меняться, например, в зависимости от положения...)
        /// </summary>
        /// <returns></returns>
        public abstract byte GetCost();
        /// <summary>
        /// положение фигуры по X
        /// </summary>
        public byte X { get; set; }
        /// <summary>
        /// положение фигуры по Y
        /// </summary>
        public byte Y { get; set; }
        /// <summary>
        /// выдает список всех возможных ходов фигуры
        /// </summary>
        /// <param name="player1">класс с описанием состояния и фигур игрока 1</param>
        /// <param name="player2">класс с описанием состояния и фигур игрока 2</param>
        /// <returns>список возможных состояний игроков с наборами фигур... </returns>
        public abstract List<(Player player1, Player player2)> GetMooves(Player player1, Player player2);
    }


}
