using Manha.BookStore.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Manha.BookStore.WebApi.Repositories
{
    public class AutorRepository
    {
        string C = "Data Source = .\\SqlExpress; initial catalog = M_BookStore; User Id = sa; Pwd=132;";

        public List<AutorDomain> Listar()
        {
            List<AutorDomain> autores = new List<AutorDomain>();

            using (SqlConnection con = new SqlConnection(C))
            {
                string Query = "Select * from Autores";
                SqlDataReader sdr;
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    con.Open();
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            AutorDomain Autor = new AutorDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = sdr["Nome"].ToString(),
                                Email = sdr["Email"].ToString(),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                                Ativo = Convert.ToBoolean(sdr["Ativo"])
                            };
                            autores.Add(Autor);
                        }
                    }
                }
            }
            return autores;
        }
        public void Cadastrar(AutorDomain Autor)
        {
            string Query = "Insert Autores (Nome,Email,DataNascimento,Ativo) VALUES (@Nome,@Email,@DataNascimento,@Ativo)";
                using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", Autor.Nome);
                    cmd.Parameters.AddWithValue("@Email", Autor.Email);
                    cmd.Parameters.AddWithValue("@DataNascimento", Autor.DataNascimento);
                    cmd.Parameters.AddWithValue("@Ativo", Autor.Ativo);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<LivroDomain> BuscaPorAutor(int id)
        {
            List<LivroDomain> Livros = new List<LivroDomain>();
            string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero where Autores.IdAutor = @IdAutor";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdAutor", id);
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
                    } return null;
                }
            }
        }
        public List<AutorDomain> ListarAutoresAtivos()
        {
            List<AutorDomain> autores = new List<AutorDomain>();
            string Query = "Select * from Autores where Autores.Ativo = 1";

            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    con.Open();
                    sdr = cmd.ExecuteReader();
                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            AutorDomain Autor = new AutorDomain
                            {
                                IdAutor = Convert.ToInt32(sdr["IdAutor"]),
                                Nome = sdr["Nome"].ToString(),
                                Email = sdr["Email"].ToString(),
                                DataNascimento = Convert.ToDateTime(sdr["DataNascimento"]),
                                Ativo = Convert.ToBoolean(sdr["Ativo"])
                            };
                            autores.Add(Autor);
                        }
                    }
                    return autores;
                }
            }
        }
        public List<LivroDomain> BuscaPorAutorEAtivo(int id)
        {
            List<LivroDomain> Livros = new List<LivroDomain>();
            string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero where Autores.IdAutor = @IdAutor and Autores.Ativo = 1";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    con.Open();
                    cmd.Parameters.AddWithValue("@IdAutor",id);
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
        public List<LivroDomain> DataSuperior(DateTime DataNascimento)
        {
            List<LivroDomain> Livros = new List<LivroDomain>();
            string Query = "Select Livros.*,Autores.*,Generos.IdGenero,Generos.Descricao as NomeGenero FROM Livros INNER JOIN Autores ON Livros.IdAutor = Autores.IdAutor JOIN Generos ON Livros.IdGenero = Generos.IdGenero Where Autores.DataNascimento < @DataNascimento";
            using (SqlConnection con = new SqlConnection(C))
            {
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    SqlDataReader sdr;
                    con.Open();
                    cmd.Parameters.AddWithValue("@DataNascimento", DataNascimento.GetDateTimeFormats());
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
