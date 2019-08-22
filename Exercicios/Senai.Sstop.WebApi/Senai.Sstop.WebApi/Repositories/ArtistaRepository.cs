using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.NovaPasta;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Repositories
{
    public class ArtistaRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;initial catalog=M_SStop;User Id=sa;Pwd=132";

        public List<ArtistaDomain> Listar()
        {
            List<ArtistaDomain> artistas = new List<ArtistaDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT A.IdArtista, A.Nome, A.IdEstiloMusical, E.Nome AS NomeEstilo FROM Artistas A INNER JOIN EstilosMusicas E ON A.IdEstiloMusical = E.IdEstiloMusical";

                con.Open();

                SqlDataReader sdr;

                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    sdr = cmd.ExecuteReader();

                    while(sdr.Read())
                    {
                        ArtistaDomain artista = new ArtistaDomain
                        {
                            IdArtista = Convert.ToInt32(sdr["IdEstiloMusical"]),
                            Nome = sdr["Nome"].ToString(),
                            Estilo = new EstiloDomain
                            {
                                IdEstilo = Convert.ToInt32(sdr["IdEstiloMusical"]),
                                Nome = sdr["Nome"].ToString()
                            }
                        };
                        artistas.Add(artista);
                    }
                    
                }
            }
            return artistas;
        }

        public void Cadastrar(ArtistaDomain artista)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Artistas (Nome,IdEstiloMusical) VALUES (@Nome, @IdEstiloMusical)";

                SqlCommand cmd = new SqlCommand(Query, con);
                
                cmd.Parameters.AddWithValue("@Nome", artista.Nome);
                cmd.Parameters.AddWithValue("@IdEstiloMusical", artista.EstiloId);
                con.Open();

                cmd.ExecuteNonQuery();
            }
        }
    }
}
