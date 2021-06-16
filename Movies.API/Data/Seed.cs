using System;
using System.Collections.Generic;
using System.Linq;
using Movies.API.Models;

namespace Movies.API.Data
{
    public class Seed
    {
        public static void SeedAsync(DataContext context)
        {
            if (!context.Movies.Any())
            {
                var movies = new List<Movie>
                {
                    new Movie
                    {
                        Id = 1,
                        Title = "The Shawshank Redemption",
                        Genre = "Drama",
                        Rating = "9.3",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Id = 2,
                        Title = "The Godfather",
                        Genre = "Crime",
                        Rating = "9.2",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1972, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Id = 3,
                        Title = "The Dark Knight",
                        Genre = "Action",
                        Rating = "9.1",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(2008, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Id = 4,
                        Title = "12 Angry Men",
                        Genre = "Crime",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1957, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Id = 5,
                        Title = "Schindler's List",
                        Genre = "Biography",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1993, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Id = 6,
                        Title = "Pulp Fiction",
                        Genre = "Drama",
                        Rating = "8.9",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "alice"
                    },
                    new Movie
                    {
                        Id = 7,
                        Title = "Fight Club",
                        Genre = "Drama",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1999, 5, 5),
                        Owner = "bob"
                    },
                    new Movie
                    {
                        Id = 8,
                        Title = "Forrest Gump",
                        Genre = "Romance",
                        Rating = "8.8",
                        ImageUrl = "images/src",
                        ReleaseDate = new DateTime(1994, 5, 5),
                        Owner = "bob"
                    }
                };
                context.Movies.AddRange(movies);
                context.SaveChanges();
            }
        }
    }
}