namespace EvilCorp.Lupita.WebApi.Dtos
{
    // Create a destination class
    public class RecipeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Instructions { get; set; } = null!;

        public string? Course { get; set; }

        public int? PrepTime { get; set; }

        public int? CookTime { get; set; }
    }
}
