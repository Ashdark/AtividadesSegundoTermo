using Senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository
    {

        private string StringConexao = "Data Source = .\\SqlExpress; initial catalog=RoteiroFilmes; User Id=sa;Pwd=132;";


        public List<FilmeDomain> ListarTodos()
        {

            List<FilmeDomain> generos = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FilmeDomain genero = new FilmeDomain
                        {
                            IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                            Nome = sdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
        public FilmeDomain ListarPorId(int id)
        {
            string Query = "Select IdGenero, Nome from Generos Where = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;

            using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain genero = new FilmeDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }
            }
        }
    }
}
