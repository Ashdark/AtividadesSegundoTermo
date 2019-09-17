using Senai.Filmes.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Manha.Repositories
{
    public class FilmeRepository
    {
        private string Conexao = "Data Source = .\\SqlExpress; initial catalog=RoteiroFilmes; User Id=sa;Pwd=132;";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> Filmes = new List<FilmeDomain>();
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Select * from Filmes, Generos";
                con.Open();
                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            Titulo = sdr["Titulo"].ToString(),
                            IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                            Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            }

                        };
                        Filmes.Add(filme);
                    }
                }
                return Filmes;
            }
        }
        public FilmeDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Select * from Filmes,Generos where IdFilme = @IdFilme";
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmeDomain Filme = new FilmeDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Nome = sdr["Nome"].ToString()
                                }

                            };
                            return Filme;
                        }
                    } return null;
                }
            }
        }
        public void Cadastrar (FilmeDomain Filme)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Insert Filmes (Titulo,IdGenero) VALUES (@Titulo,@IdGenero)";
                con.Open();

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", Filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", Filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
