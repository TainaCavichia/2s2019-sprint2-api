using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository : IPecaRepository
    {
        public void Atualizar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscada = ctx.Pecas.FirstOrDefault(x => x.PecaId == peca.PecaId);
                PecaBuscada.PrecoVenda = peca.PrecoVenda;
                ctx.Pecas.Update(PecaBuscada);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.PecaId == id);
            }
        }

        public void Cadastrar(Pecas peca)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(peca);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas PecaBuscada = ctx.Pecas.Find(id);
                ctx.Pecas.Remove(PecaBuscada);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
