using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository
    {
     
        private string StringConexao = "Data Source=.\\SqlExpress;initial catalog=M_Peoples;User Id=sa;Pwd=132";

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionarios = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {

                string Query = "SELECT IdFuncionario, Nome, Sobrenome FROM Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FuncionariosDomain funcionario = new FuncionariosDomain()
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"])
                            ,
                            Nome = rdr["Nome"].ToString()
                            ,
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };

                        funcionarios.Add(funcionario);
                    }
                }
                return funcionarios;
            }

        }
    
        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFuncionario, Nome, Sobrenome " +
                    "FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFuncionario", id);
                    sdr = cmd.ExecuteReader();

                    if(sdr.HasRows)
                    {
                        while(sdr.Read())
                        {
                            FuncionariosDomain funcionario = new FuncionariosDomain()
                            {
                                IdFuncionario = Convert.ToInt32(sdr["IdFuncionario"])
                            ,
                                Nome = sdr["Nome"].ToString()
                            ,
                                Sobrenome = sdr["Sobrenome"].ToString()
                            };
                            return funcionario;
                        }
                    }
                    return null;
                }
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Funcionarios WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", id);
                con.Open();
                cmd.ExecuteNonQuery();
                    
            }
        }

        public void Atualizar(FuncionariosDomain funcionarios)
        {
            string Query = "UPDATE Funcionarios SET Nome = @Nome, Sobrenome = @Sobrenome WHERE IdFuncionario = @IdFuncionario";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdFuncionario", funcionarios.IdFuncionario);
                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                con.Open();
                cmd.ExecuteNonQuery();
                
            }
        }

        public void Cadastrar(FuncionariosDomain funcionario)
        {
            string Query = "INSERT INTO Funcionarios (Nome, Sobrenome) VALUES (@Nome, @Sobrenome)";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", funcionario.Sobrenome);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
       
}
