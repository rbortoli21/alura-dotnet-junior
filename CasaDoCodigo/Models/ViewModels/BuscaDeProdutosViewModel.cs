using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.ViewModels
{
    public class BuscaDeProdutosViewModel
    {
        public IList<Categoria> Categorias { get; set; }
        public IList<Produto> Produtos { get; set; }
        public BuscaDeProdutosViewModel(IList<Produto> produtos, IList<Categoria> categorias) 
        {
           Categorias = categorias; 
           Produtos = produtos;   
        }
       
    }
}
