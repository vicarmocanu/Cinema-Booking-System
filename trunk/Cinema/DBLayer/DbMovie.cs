using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Cinema.ModelLayer;
using Cinema.DBLayer;
using System.Security.Cryptography;

namespace Cinema.DBLayer
{
    class DbMovie: IMovie
    {
        private static SqlCommand dbCmd = null; 

        //create a movie object from the data reader
        private static Movie createMovie(IDataReader dbReader)
        {
            Movie mov  = new Movie();

            mov.MovieId = Convert.ToInt32(dbReader["movieId"].ToString());
            mov.Name = dbReader["name"].ToString();
            mov.Genre = dbReader["genre"].ToString();
            mov.AgeLimit = Convert.ToInt32(dbReader["ageLimit"].ToString());
            mov.Length = Convert.ToInt32(dbReader["length"].ToString());

            return mov;
        }

        //insert a movie
        public int insertMovie(Movie mov)
        {
            int result = -1;

            String attrib = "movieId";
            String table = "Movie";
            int max = GetMax.getMax(attrib, table);
            int id = max + 1;
            
            string sqlQuery = "INSERT INTO Movie VALUES " +
                "('" + id + 
                "','" + mov.Name +
                "','" + mov.Genre +
                "','" + mov.AgeLimit +
                "','" + mov.Length + "')";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
        
        //get all movies
        public List<Movie> getMovies()
        {
            List<Movie> returnList = new List<Movie>();

            string sqlQuery = "SELECT * FROM Movie";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            while (dbReader.Read())
            {
                Movie mov = new Movie();
                mov = createMovie(dbReader);
                returnList.Add(mov);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a movie - id
        public Movie getMovieByID(int id)
        {
            string sqlQuery = "SELECT * FROM Movie WHERE movieId= '" + id + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Movie movie = new Movie();

            if (dbReader.Read())
            {
                movie = createMovie(dbReader);
            }
            else
            {
                movie = null;                
            }

            AccessDbSQLClient.Close();

            return movie;
        }

        //get a movie - name
        public Movie getMovieByName(String name)
        {
            string sqlQuery = "SELECT * FROM Movie WHERE name= '" + name + "'";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            IDataReader dbReader;
            dbReader = dbCmd.ExecuteReader();

            Movie movie = new Movie();

            if (dbReader.Read())
            {
                movie = createMovie(dbReader);
            }
            else
            {
                movie = null;
            }

            AccessDbSQLClient.Close();

            return movie;
        }

        //update a movie - id
        public int updateMovie(Movie mov)
        {
            int result = -1;

            string sqlQuery = "UPDATE Movie SET " +
                "name='" + mov.Name + "', " +
                "genre='" + mov.Genre + "', " +
                "ageLimit='" + mov.AgeLimit + "', " +
                "length='" + mov.Length + "' WHERE " +
                "movieId='" + mov.MovieId + "'";

            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }

        //delete movie - id
        public int deleteMovie(int movieId)
        {
            int result = -1;
            string sqlQuery = "DELETE FROM Movie WHERE movieId= '" + movieId + "'";
            try
            {
                SqlCommand cmd = AccessDbSQLClient.GetDbCommand(sqlQuery);
                result = cmd.ExecuteNonQuery();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }
            return result;
        }
    }
}
