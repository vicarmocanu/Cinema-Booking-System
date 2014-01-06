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
        private static SqlParameter paramMovieId = new SqlParameter("@movieId", SqlDbType.Int);
        private static SqlParameter paramName = new SqlParameter("@name", SqlDbType.NVarChar, 50);
        private static SqlParameter paramGenre = new SqlParameter("@genre", SqlDbType.NVarChar, 50);
        private static SqlParameter paramAgeLimit = new SqlParameter("@ageLimit", SqlDbType.Int);
        private static SqlParameter paramLength = new SqlParameter("@length", SqlDbType.Int);

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

            dbCmd = new SqlCommand();
            string sqlQuery = "INSERT INTO Movie VALUES " +
                "(@movieId, @name, @genre, @ageLimit, @length)";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramMovieId.Value = id;
            dbCmd.Parameters.Add(paramMovieId);

            paramName.Value = mov.Name;
            dbCmd.Parameters.Add(paramName);

            paramGenre.Value = mov.Genre;
            dbCmd.Parameters.Add(paramGenre);

            paramAgeLimit.Value = mov.AgeLimit;
            dbCmd.Parameters.Add(paramAgeLimit);

            paramLength.Value = mov.Length;
            dbCmd.Parameters.Add(paramLength);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return returnList;
        }

        //get a movie - id
        public Movie getMovieByID(int id)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Movie WHERE movieId= @movieId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramMovieId.Value = id;
            dbCmd.Parameters.Add(paramMovieId);

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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return movie;
        }

        //get a movie - name
        public Movie getMovieByName(String name)
        {
            dbCmd = new SqlCommand();
            string sqlQuery = "SELECT * FROM Movie WHERE name= @name";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramName.Value = name;
            dbCmd.Parameters.Add(paramName);

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

            dbCmd.Parameters.Clear();
            AccessDbSQLClient.Close();

            return movie;
        }

        //update a movie - id
        public int updateMovie(Movie mov)
        {
            int result = -1;

            dbCmd = new SqlCommand();
            string sqlQuery = "UPDATE Movie SET " +
                "name= @name, genre= @genre, ageLimit= @ageLimit, length= @length WHERE " +
                "movieId= @movieId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramMovieId.Value = mov.MovieId;
            dbCmd.Parameters.Add(paramMovieId);

            paramName.Value = mov.Name;
            dbCmd.Parameters.Add(paramName);

            paramGenre.Value = mov.Genre;
            dbCmd.Parameters.Add(paramGenre);

            paramAgeLimit.Value = mov.AgeLimit;
            dbCmd.Parameters.Add(paramAgeLimit);

            paramLength.Value = mov.Length;
            dbCmd.Parameters.Add(paramLength);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
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

            dbCmd = new SqlCommand();
            string sqlQuery = "DELETE FROM Movie WHERE movieId= @movieId";
            dbCmd = AccessDbSQLClient.GetDbCommand(sqlQuery);

            paramMovieId.Value = movieId;
            dbCmd.Parameters.Add(paramMovieId);

            try
            {
                result = dbCmd.ExecuteNonQuery();
                dbCmd.Parameters.Clear();
                AccessDbSQLClient.Close();
            }
            catch (SqlException)
            { }

            return result;
        }
    }
}
