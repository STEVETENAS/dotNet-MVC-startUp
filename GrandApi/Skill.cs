using System.Text.Json.Serialization;

namespace GrandApi
{
    public class Skill
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public int Damage { get; set; }
        [JsonIgnore]
        public List<Character> Characters { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;

    }
}
