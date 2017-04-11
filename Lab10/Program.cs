using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable MegaMovieList =LoadMovieList();

            Console.WriteLine("Please enter a category:");
            string input = Console.ReadLine();
            // hello 
            if (MegaMovieList[input] != null)
            {
                List<Movie> FoundList = (List<Movie>)MegaMovieList[input];

                foreach (Movie item in FoundList)
                {
                    Console.WriteLine(item.Title);
                }

            }


        }

        private static Hashtable LoadMovieList()
        {
            Hashtable MovieList = new Hashtable();
            
            // build indivisual movie lists 
            List<Movie> DramaList = new List<Movie>();

            DramaList.Add(new Movie("Citizen Kane", "drama"));
            DramaList.Add(new Movie("Casablanca", "drama"));
            DramaList.Add(new Movie("The Godfather", "drama"));
            DramaList.Add(new Movie("Gone With The Wind", "drama"));

            List<Movie> HorrorList = new List<Movie>();

            HorrorList.Add(new Movie("The Silence Of The Lambs", "horror"));
            HorrorList.Add(new Movie("Frankenstein", "horror"));

            // add the movie lists to the hashtable 
            MovieList.Add("drama", DramaList);

            MovieList.Add("horror", HorrorList);

            return MovieList; 
        }

        private static Hashtable LoadDynamicMovieList()
        {
            Hashtable movieList = new Hashtable();

            for (int i = 1; i <=100; i++)
            {
                Movie temp = MovieIO.getMovie(i);
                string cat = temp.Category;

                if (movieList[cat] != null)// I do have a list 
                {
                    List<Movie> FoundList = (List<Movie>)movieList[cat];
                    FoundList.Add(temp);

                }
                else
                {
                    List<Movie> catList = new List<Movie>();
                    catList.Add(temp);

                    movieList.Add(cat,catList);

                }

                

            }
return movieList;
        }
    }
}
