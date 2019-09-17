using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source = .\\SqlExpress; initial catalog=M_Sstop; User Id=sa;Pwd=132;";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "Select A.IdArtista, A.NomeArtista, A.IdEstiloMusical, E.Nome as NomeEstilo FROM Artistas A Inner Join EstilosMusicas E on A.IdEstiloMusical = E.IdEstiloMusical";
                con.Open();
                SqlDataReader sdr;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdArtista"]),
                            Nome = sdr["NomeArtista"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["NomeEstilo"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }
                }
            } return artistas;
        }
        public void Cadastrar(ArtistaDomain artista)
        {
            using (SqlConnection con = new SqlConnection(StringConexao)) {
                string Query = "Insert Artistas (NomeArtista, IdEstiloMusical) VALUES (@Nome, @IdEstiloMusical)";

                SqlCommand com = new SqlCommand(Query, con);
                com.Parameters.AddWithValue("@Nome", artista.Nome);
                com.Parameters.AddWithValue("@IdEstiloMusical", artista.EstiloId);

                con.Open();
                com.ExecuteNonQuery();
            }
        }
    }
}
