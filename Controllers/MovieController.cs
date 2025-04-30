using Microsoft.AspNetCore.Mvc;

namespace modul10_103022300121.Controllers;

[ApiController]
[Route("/api/Movies")]
public class MovieController : ControllerBase
{
    private static readonly List<Movie> Movies = new()
    {
        new Movie("The Shawshank Redemption", "Frank Darabont", new List<string> { "Bob Gunton", "Morgan Freeman", "Tim Robbins" }, "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."),
        new Movie("The Godfather", "Francis Ford Coppola", new List<string> { "James Caan", "Al Pacino", "Marlon Brando" }, "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."),
        new Movie("The Dark Knight", "Frank Darabont", new List<string> { "Aaron Eckhart", "Heath Ledger", "Christian Bale" }, "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."),
    };

    [HttpGet]
    public ActionResult<Movie> GetAll()
    {
        return Ok(Movies);
    }

    [HttpGet("{index}")]
    public ActionResult<Movie> GetByIndex(int index)
    {
        if (index < 0 || index >= Movies.Count)
        {
            return NotFound("Movie not found at the given index.");
        }

        return Ok(Movies[index]);
    }

    [HttpPost]
    public ActionResult Add([FromBody] Movie newMovie)
    {
        if (newMovie == null || string.IsNullOrEmpty(newMovie.Title) || string.IsNullOrEmpty(newMovie.Director) || 
            newMovie.Stars.Count == 0 || string.IsNullOrEmpty(newMovie.Description))
        {
            return BadRequest("Invalid Movie data.");
        }

        Movies.Add(newMovie);
        return CreatedAtAction(nameof(GetByIndex), new { index = Movies.Count - 1 }, newMovie);
    }

    [HttpDelete("{index}")]
    public ActionResult Delete(int index)
    {
        if (index < 0 || index >= Movies.Count)
        {
            return NotFound("Movie not found at the given index.");
        }

        Movies.RemoveAt(index);
        return NoContent();
    }

}
