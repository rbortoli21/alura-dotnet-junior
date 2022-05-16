using CasaDoCodigo.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public async Task<Categoria> SaveCategorias(string nome)
        {
            var categoria = dbSet.Where(c => c.Nome == nome).SingleOrDefault();
            if (categoria == null)
            {
                var novaCategoria = new Categoria()
                {
                    Nome = nome
                };
                categoria = dbSet.Add(novaCategoria).Entity;
            }
            await contexto.SaveChangesAsync();
            return categoria;
        }
    }
}
