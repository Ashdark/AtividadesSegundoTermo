using Senai.Sstop.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class EstiloRepository
    {
        //List<EstiloDomain> estilos = new List<EstiloDomain>()
        //    {
        //        new EstiloDomain { IdEstilo = 1, Nome = "Rock"}
        //        , new EstiloDomain { IdEstilo = 2, Nome = "Pop"}
        //        , new EstiloDomain {IdEstilo = 3, Nome = "Indie"}
        //        , new EstiloDomain {IdEstilo = 4, Nome = "MPB"}
        //    };

        private string StringConexao = "Data Source = .\\SqlExpress; initial catalog=M_Sstop; User Id=sa;Pwd=132;";

        public EstiloDomain BuscarPorId(int Id){
            string Query = "Select IdEstiloMusical, Nome from EstilosMusicas Where IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao)){
                con.Open();
                SqlDataReader sdr;

            using (SqlCommand cmd = new SqlCommand(Query,con)){
                cmd.Parameters.AddWithValue("@IdEstiloMusical", Id);
                sdr = cmd.ExecuteReader();

                if(sdr.HasRows){
                    while(sdr.Read()){
                            EstiloDomain estilo = new EstiloDomain{
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["Nome"].ToString()
                           };
                        return estilo;
                    }
                }
                return null;
            }
        }
    }
        public List<EstiloDomain> Listar()
        {

            List<EstiloDomain> estilos = new List<EstiloDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicas";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EstiloDomain estilo = new EstiloDomain
                        {
                            IdEstilo = Convert.ToInt32(rdr["IdEstiloMusical"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        estilos.Add(estilo);
                    }
                }
            }
                return estilos;
            }
        public void Cadastrar (EstiloDomain estilo)
        {
            string Query = "INSERT INTO EstilosMusicas (Nome) VALUES (@Nome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(EstiloDomain estilo)
        {
            string Query = "Update EstilosMusicas SET Nome = @Nome Where IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estilo.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estilo.IdEstilo);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Deletar(int id)
        {
            string Query = "Delete from EstilosMusicas Where IdEstiloMusical = @IdEstiloMusical";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                con.Open();
                cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
