using Senai.Sstop.WebApi.NovaPasta;
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
        //        new EstiloDomain {IdEstilo = 1, Nome = "Rock"}
        //        , new EstiloDomain {IdEstilo = 2, Nome = "Alternativo"}
        //    };

        private string StringConexao = "Data Source=.\\SqlExpress;initial catalog=M_SStop;User Id=sa;Pwd=132";

        public void Cadastrar(EstiloDomain estilo)
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

        public EstiloDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdEstiloMusical, Nome FROM EstilosMusicas WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            EstiloDomain estilo = new EstiloDomain
                            {
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

        public void Alterar(EstiloDomain estiloDomain)
        {
            string Query = "UPDATE EstilosMusicas SET Nome = @Nome WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", estiloDomain.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", estiloDomain.IdEstilo);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM EstilosMusicas WHERE IdEstiloMusical = @IdEstiloMusical";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}

