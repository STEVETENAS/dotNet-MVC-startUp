namespace GrandApi
{
    public class CreateCharacterDto
    {
        public string Name { get; set; } = "Character";
        public string RpgClass { get; set; } = "knight";
        public int UserId { get; set; } = 1;
    }
}
