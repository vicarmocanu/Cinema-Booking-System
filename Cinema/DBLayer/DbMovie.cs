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
            mov.Lenght = dbReader["lenght"].ToString();

            return mov;
        }

        //insert a movie into the table
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
                "','" + mov.Lenght + "')";
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

            Movie mov = new Movie();

            while (dbReader.Read())
            {
                mov = createMovie(dbReader);
                returnList.Add(mov);
            }

            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a movie based on its id
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

        //update a movie based on its id
        public int updateMovie(Movie mov)
        {
            int result = -1;

            string sqlQuery = "UPDATE Movie SET " +
                "name='" + mov.Name + "', " +
                "genre='" + mov.Genre + "', " +
                "ageLimit='" + mov.AgeLimit + "', " +
                "lenght='" + mov.Lenght + "' WHERE " +
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
    }
}
