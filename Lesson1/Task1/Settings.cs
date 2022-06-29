namespace Chess
{
    public class Settings
    {
        public void Draw() { }
        public bool HumanIsWhite { get; set; }
        public int Difficalty { get; set; }
        public bool Save() { return true; }
        public bool Load() { return true; }
    }
}
