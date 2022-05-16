using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public IList<Produto> Produtos { get; set; }
        public string Pesquisa { get; set; }
        public bool Encontrou;
        public BuscaDeProdutosViewModel(IList<Produto> produtos, bool encontrou)
        {
            Produtos = produtos;
            Encontrou = encontrou;
        }
        public BuscaDeProdutosViewModel(bool encontrou)
        {
            Encontrou = encontrou;
        }

    }
}
