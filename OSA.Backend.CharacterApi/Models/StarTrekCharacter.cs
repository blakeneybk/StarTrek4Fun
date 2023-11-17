namespace OSA.Backend.CharacterApi.Models
{
    public class StarTrekCharacter : IDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Species { get; set; }
        public string Assignment { get; set; } // e.g., "USS Enterprise"
    }
}
