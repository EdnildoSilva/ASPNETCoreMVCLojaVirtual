using LojaVirtual.Database;
using LojaVirtual.Models;
using LojaVirtual.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace LojaVirtual.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private IConfiguration _conf;
        LojaVirtualContext _banco;
        public CategoriaRepository(LojaVirtualContext banco, IConfiguration configuration)
        {
            _banco = banco;
            _conf = configuration;
        }

        public void Atualizar(Categoria categoria)
        {
            _banco.Update(categoria);
            _banco.SaveChanges();
        }

        public void Cadastrar(Categoria categoria)
        {
            _banco.Add(categoria);
            _banco.SaveChanges();
        }

        public void Excluir(int id)
        {
            Categoria categoria = ObterCategoria(id);
            _banco.Remove(categoria);
            _banco.SaveChanges();
        }

        public Categoria ObterCategoria(int id)
        {
            return _banco.Categorias.Find(id);
        }

        public IPagedList<Categoria> ObterTodasCategorias(int? pagina)
        {
            int RegistrosPorPagina = _conf.GetValue<int>("RegistrosPorPagina");
            int NumeroPagina = pagina ?? 1;
            return _banco.Categorias.Include(a=>a.CategoriaPai).ToPagedList<Categoria>(NumeroPagina, RegistrosPorPagina);
        }

        public IEnumerable<Categoria> ObterTodasCategorias()
        {
            return _banco.Categorias;
        }
    }
}
