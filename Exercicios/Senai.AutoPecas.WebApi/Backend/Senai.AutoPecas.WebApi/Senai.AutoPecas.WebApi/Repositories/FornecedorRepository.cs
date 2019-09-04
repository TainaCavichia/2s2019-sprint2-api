using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public void Atualizar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Fornecedores FornecedorBuscado = ctx.Fornecedores.FirstOrDefault(x => x.FornecedorId == fornecedor.FornecedorId);
                FornecedorBuscado.Endereco = fornecedor.Endereco;
                ctx.Fornecedores.Update(fornecedor);
                ctx.SaveChanges();
            }
        }

        public Fornecedores BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.FirstOrDefault(x => x.FornecedorId == id);
            }
        }

        public void Cadastrar(Fornecedores fornecedor)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(fornecedor);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Fornecedores FornecedorBuscado = ctx.Fornecedores.Find(id);
                ctx.Fornecedores.Remove(FornecedorBuscado);
                ctx.SaveChanges();
            }
        }

        public List<Fornecedores> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Fornecedores.ToList();
            }
        }
    }
}
