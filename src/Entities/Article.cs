namespace DotNet_AWS_Deployment_Demo.Entities
{
    public class Article
    {
        public long Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
    }
}