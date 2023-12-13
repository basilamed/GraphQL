namespace gqlSI.Models
{
    public class Recipe
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string BakingTime { get; set; }
        public string Instructions { get; set; }
        public string Notes { get; set; }
        public string Source { get; set; }
    }
}
