using Senai.Filmes.WebApi.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Filmes.WebApi.Manha.Repositories
{
    public class GeneroRepository
    {
        private string Conexao = "Data Source = .\\SqlExpress; initial catalog=RoteiroFilmes; User Id=sa;Pwd=132;";
        public List<GeneroDomain> Listar()
        {
            List<GeneroDomain> generos = new List<GeneroDomain>();
            using(SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Select Nome, IdGenero from Generos";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain
                        {
                            Nome = rdr["Nome"].ToString(),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }
        public GeneroDomain BuscarId(int id)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Select Nome, IdGenero from Generos Where IdGenero = @IdGenero";
                con.Open();
                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            GeneroDomain Genero = new GeneroDomain
                            {
                                Nome = rdr["Nome"].ToString(),
                                IdGenero = Convert.ToInt32(rdr["IdGenero"])
                            };
                            return Genero;
                        }
                    }
                } return null;
            }
        }
        public void Cadastrar(GeneroDomain Genero)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Insert Generos (Nome) VALUES (@Nome)";
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", Genero.Nome);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Editar(int id, string nome)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Update Generos SET Nome = @Nome where IdGenero = @IdGenero";
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void Deletar (int id)
        {
            using (SqlConnection con = new SqlConnection(Conexao))
            {
                string Query = "Delete from Generos where IdGenero = @IdGenero";
                con.Open();
                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
