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
        public async Task SaveCategorias(string nome)
        {
            if (!contexto.Set<Categoria>().Where(c => c.Nome == nome).Any())
            {
                var categoria = new Categoria(nome);
                dbSet.Add(categoria);
            }
            await contexto.SaveChangesAsync();
        }
    }
}
