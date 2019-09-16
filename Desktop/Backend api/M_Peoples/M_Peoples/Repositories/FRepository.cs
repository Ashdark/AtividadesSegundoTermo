using M_Peoples.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace M_Peoples.Repositories
{
    public class FRepository
    {
        private string StringConexao = "Data source = .\\SqlExpress; initial catalog = M_Peoples; User Id = sa; pwd=132;";


        public List<FDomain> Listar()
        {
            List<FDomain> funcionarios = new List<FDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select IdFuncionario, Nome, Sobrenome,DataNascimento FROM Funcionarios";
                SqlDataReader L;

                using(SqlCommand cmd = new SqlCommand(Query, con))
                {
                    L = cmd.ExecuteReader();
                    while (L.Read())
                    {
                        FDomain funcionario = new FDomain
                        {
                            IdFuncionario = Convert.ToInt32(L["IdFuncionario"]),
                            Nome = L["Nome"].ToString(),
                            Sobrenome = L["Sobrenome"].ToString(),
                            DataNascimento =Convert.ToDateTime(L["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
        public List<NomescompletoVM> NomesCompletos()
        {
            List<NomescompletoVM> funcionarios1 = new List<NomescompletoVM>();
            List<FDomain> funcionarios = new List<FDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select distinct IdFuncionario, Nome, Sobrenome,DataNascimento FROM Funcionarios";
                SqlDataReader L;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    L = cmd.ExecuteReader();
                    while (L.Read())
                    {
                        FDomain funcionario = new FDomain
                        {
                            IdFuncionario = Convert.ToInt32(L["IdFuncionario"]),
                            Nome = L["Nome"].ToString(),
                            Sobrenome = L["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(L["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    foreach (var item in funcionarios)
                        {   if (funcionario.Nome == funcionario.Nome)
                            {
                                NomescompletoVM nomescompletosvm = new NomescompletoVM();
                                nomescompletosvm.nomecompleto = funcionario.Nome + " " + funcionario.Sobrenome;
                                nomescompletosvm.PessoasId = funcionario.IdFuncionario;
                                funcionarios1.Add(nomescompletosvm);
                            }
                        }
                    }
                }
            }
            return funcionarios1;
        }
        public FDomain BuscarPorId(int Id)
        {
            string Query = "Select IdFuncionario,Nome,Sobrenome from Funcionarios Where IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader L;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", Id);
                    L = cmd.ExecuteReader();

                    if (L.HasRows)
                    {
                        while (L.Read())
                        {
                            FDomain funcionario = new FDomain
                            {
                                IdFuncionario = Convert.ToInt32(L["IdFuncionario"]),
                                Nome = L["Nome"].ToString(),
                                Sobrenome = L["Sobrenome"].ToString(),
                                DataNascimento = Convert.ToDateTime(L["DataNascimento"])
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }
        public FDomain BuscarPorNome(string nome)
        {
            string Query = "Select IdFuncionario,Nome,Sobrenome, DataNascimento from Funcionarios Where Nome = @Nome";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader L;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", nome);
                    L = cmd.ExecuteReader();

                    if (L.HasRows)
                    {
                        while (L.Read())
                        {
                            FDomain funcionario = new FDomain
                            {
                                IdFuncionario = Convert.ToInt32(L["IdFuncionario"]),
                                Nome = L["Nome"].ToString(),
                                Sobrenome = L["Sobrenome"].ToString(),
                                DataNascimento = Convert.ToDateTime(L["DataNascimento"])
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }
        public List<FDomain> Ordernar(string ordenacao)
        {
            List<FDomain> funcionarios = new List<FDomain>();
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                string Query = "Select IdFuncionario,Nome,Sobrenome, DataNascimento from Funcionarios order by Funcionarios.Nome @ordenacao";
                SqlDataReader L;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@ordenacao", ordenacao);
                    L = cmd.ExecuteReader();
                    while (L.Read())
                    {
                        FDomain funcionario = new FDomain
                        {
                            IdFuncionario = Convert.ToInt32(L["IdFuncionario"]),
                            Nome = L["Nome"].ToString(),
                            Sobrenome = L["Sobrenome"].ToString(),
                            DataNascimento = Convert.ToDateTime(L["DataNascimento"])
                        };
                        funcionarios.Add(funcionario);
                    }
                }
            }
            return funcionarios;
        }
        public void Cadastrar(FDomain funcionario)
        {
            string Query = "INSERT Funcionarios (Nome,Sobrenome) VALUES (@Nome,@Sobrenome)";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar (FDomain funcionario)
        {
            string Query = "Update Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome, DataNascimento = @DataNascimento Where IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                cmd.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionario.IdFuncionario);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Deletar(int id)
        {
            string Query = "Delete from Funcionarios Where IdFuncionario = @IdFuncionario";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
