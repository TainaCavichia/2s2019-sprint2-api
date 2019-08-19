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
                    while(rdr.Read())
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
    }
}
