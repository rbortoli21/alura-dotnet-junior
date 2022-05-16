using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public IList<Categoria> Categorias { get; set; }
        public Task<IList<Produto>> Produtos { get; set; }
        public string Pesquisa { get; set; }
        public bool Encontrou { get; set; }
        public BuscaDeProdutosViewModel(Task<IList<Produto>> produtos, IList<Categoria> categorias, bool encontrou)
        {
            Categorias = categorias;
            Produtos = produtos;
            Encontrou = encontrou;
        }
        public BuscaDeProdutosViewModel(bool encontrou)
        {
            Encontrou = encontrou;
        }

    }
}
