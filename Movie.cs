namespace modul10_103022300121
{
    public class Movie
    {
        public string Title { get; set; }

        public string Director { get; set; }

        public List<string> Stars { get; set; }

        public string Description { get; set; }

        public Movie(string title, string director, List<string> stars, string description)
        {
            Title = title;
            Director = director;
            Stars = stars;
            Description = description;
        }
    }
}
