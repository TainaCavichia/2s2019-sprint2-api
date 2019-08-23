using Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.WebApi.Repositories
{
    public class FilmesRepository
    {
        string StringConexao = "Data Source=.\\SqlExpress;initial catalog=M_RoteiroFilmes;User Id=sa;Pwd=132";

        public List<FilmesDomain> Listar()
        {
            List<FilmesDomain> filmes = new List<FilmesDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FilmesDomain filme = new FilmesDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"])
                        }
                        };
                        filmes.Add(filme);
                    }
                }
            }
            return filmes;
        }

        public FilmesDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdFilme, Titulo, IdGenero FROM Filmes WHERE IdFilme = @IdFilme";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            FilmesDomain filme = new FilmesDomain
                            {
                                IdFilme = Convert.ToInt32(sdr["IdFilme"]),
                                Titulo = sdr["Titulo"].ToString(),
                                Genero = new GenerosDomain
                                {
                                    IdGenero = Convert.ToInt32(sdr["IdGenero"])
                                }
                            };
                            return filme;
                        }
                    }
                    return null;
                }

            }
        }

        public void Cadastrar(FilmesDomain filmes)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Filmes (Titulo, IdGenero) VALUES (@Titulo, @IdGenero)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Titulo", filmes.Titulo);
                cmd.Parameters.AddWithValue("@IdGenero", filmes.GeneroId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
