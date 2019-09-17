using Manha.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Manha.BookStore.WebApi.Repositories
{
    public class GeneroRepository
    {
        string C = "Data Source = .\\SqlExpress; initial catalog = M_BookStore; User Id = sa; Pwd=132;";
        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();

            using (SqlConnection con = new SqlConnection(C))
            {
                string Query = "Select * from Generos";

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;

                    con.Open();

                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GeneroDomain Genero = new GeneroDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Descricao = sdr["Descricao"].ToString()
                            };
                            generos.Add(Genero);
                        }
                    }
                }
            }
            return generos;
        }
        public void Cadastrar(GeneroDomain Genero)
        {
            string Query = "Insert Generos (Descricao) VALUES (@Descricao)";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", Genero.Descricao);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<LivroDomain> BuscaPorGenero(string nome)
        {
            List<LivroDomain> Livros = new List<LivroDomain>();
            string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero Where Generos.Descricao = @DescricaoGenero";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    con.Open();
                    cmd.Parameters.AddWithValue("@DescricaoGenero", nome);
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroDomain Livro = new LivroDomain
                            {
                                IdLivro = Convert.ToInt32(sdr["IdLivro"]),
                                Titulo = sdr["Descricao"].ToString(),
                                Autor = new AutorDomain
                                {
                                    IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                    Nome = sdr["Nome"].ToString(),
                                    Email = sdr["Email"].ToString(),
                                    Ativo = Convert.ToBoolean(sdr["Ativo"]),
                                    DataNascimento = Convert.ToDateTime(sdr["DataNascimento"])
                                },
                                Genero = new GeneroDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                    Descricao = sdr["NomeGenero"].ToString()
                                }
                            };
                            Livros.Add(Livro);

                        }
                        return Livros;
                    }
                    return null;
                }
            }

        }
    }
}
