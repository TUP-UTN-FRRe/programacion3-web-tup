namespace ClubWorldCup.Core.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int Number { get; set; }


        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name) 
                    && !string.IsNullOrEmpty(Position) 
                    && Number > 0;
        }

    }
}
