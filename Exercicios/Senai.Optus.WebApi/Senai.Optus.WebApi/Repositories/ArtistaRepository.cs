using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        //listar
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.ToList();
            }

        }//fim listar

        //cadastrar
        public void Cadastrar(Artistas artistas)
        {
            using (OptusContext ctx = new OptusContext())
            {
                //INSERT INTO
                ctx.Artistas.Add(artistas);
                ctx.SaveChanges();
            }
        }//fim cadastrar

    }
}