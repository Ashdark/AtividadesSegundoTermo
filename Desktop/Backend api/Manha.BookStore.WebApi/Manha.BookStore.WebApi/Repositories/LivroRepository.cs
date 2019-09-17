using Manha.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Manha.BookStore.WebApi.Repositories
{
    public class LivroRepository
    {
        string C = "Data Source = .\\SqlExpress; initial catalog = M_BookStore; User Id = sa; Pwd=132;";

        public List<LivroDomain> Listar()
        {
            List<LivroDomain> livros = new List<LivroDomain>();

            using (SqlConnection con = new SqlConnection(C))
            {
                string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero";

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroDomain livro = new LivroDomain
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
                            livros.Add(livro);
                            }
                        } return livros;
                    }
                }
            }
        public LivroDomain BuscarId(int id)
        {
            string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero where Livros.IdLivro = @IdLivro";

            using (SqlConnection con = new SqlConnection(C))
            {
                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdLivro", id);

                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            LivroDomain livro = new LivroDomain
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
                            return livro;
                        }
                    } return null;
                }
            }
        }

        public void Cadastrar (LivroDomain Livro)
        {
            string Query = "Insert Livros (Descricao,IdAutor,IdGenero) Values (@Descricao,@IdAutor,@IdGenero)";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", Livro.Titulo);
                    cmd.Parameters.AddWithValue("@IdAutor", Livro.IdAutor);
                    cmd.Parameters.AddWithValue("@IdGenero", Livro.IdGenero);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Atualizar (int id, LivroDomain Livro)
        {
            string Query = "Update Livros SET Livros.Descricao = @Descricao, Livros.IdAutor = @IdAutor, Livros.IdGenero = @IdGenero Where Livros.IdLivro = @IdLivro";
            using (SqlConnection con = new SqlConnection(C))
            {
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Descricao", Livro.Titulo);
                    cmd.Parameters.AddWithValue("@IdAutor", Livro.IdAutor);
                    cmd.Parameters.AddWithValue("@IdGenero", Livro.IdGenero);
                    cmd.Parameters.AddWithValue("@IdLivro", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Deletar (int id)
        {
            string Query = "Delete from Livros Where Livros.IdLivro = @IdLivro";
            using(SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdLivro", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
