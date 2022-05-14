using CasaDoCodigo.Models;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategorias(string nome);
    }
}
