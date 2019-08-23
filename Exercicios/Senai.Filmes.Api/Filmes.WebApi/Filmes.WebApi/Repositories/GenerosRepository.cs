using Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Filmes.WebApi.Repositories
{
    public class GenerosRepository
    {
        private string StringConexao = "Data Source=.\\SqlExpress;initial catalog=M_RoteiroFilmes;User Id=sa;Pwd=132";

        public List<GenerosDomain> Listar()
        {
            List<GenerosDomain> generos = new List<GenerosDomain>();

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "SELECT IdGenero, Nome FROM Generos";

                con.Open();

                SqlDataReader rdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    rdr = cmd.ExecuteReader();
                    while(rdr.Read())
                    {
                        GenerosDomain genero = new GenerosDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };
                        generos.Add(genero);
                    }
                }
            }
            return generos;
        }

        public void Cadastrar(GenerosDomain generos)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string Query = "INSERT INTO Generos (Nome) VALUES (@Nome)";

                SqlCommand cmd = new SqlCommand(Query, con);

                cmd.Parameters.AddWithValue("@Nome", generos.Nome);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public GenerosDomain BuscarPorId(int id)
        {
            string Query = "SELECT IdGenero, Nome FROM Generos WHERE IdGenero = @IdGenero";

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                con.Open();
                SqlDataReader sdr;
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    sdr = cmd.ExecuteReader();

                    if (sdr.HasRows)
                    {
                        while (sdr.Read())
                        {
                            GenerosDomain genero = new GenerosDomain
                            {
                                IdGenero = Convert.ToInt32(sdr["IdGenero"]),
                                Nome = sdr["Nome"].ToString()
                            };
                            return genero;
                        }
                    }
                    return null;
                }

            }
        }

        public void Alterar(GenerosDomain generos)
        {
            string Query = "UPDATE Generos SET Nome = @Nome WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@Nome", generos.Nome);
                cmd.Parameters.AddWithValue("@IdGenero", generos.IdGenero);


                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            string Query = "DELETE FROM Generos WHERE IdGenero = @IdGenero";
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.Parameters.AddWithValue("@IdGenero", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
