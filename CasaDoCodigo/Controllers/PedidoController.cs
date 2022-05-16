using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ICategoriaRepository categoriaRepository;
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository,
            IPedidoRepository pedidoRepository,
            IItemPedidoRepository itemPedidoRepository,
            ICategoriaRepository categoriaRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
            this.categoriaRepository = categoriaRepository;
        }

        public IActionResult Carrossel()
        {
            return RedirectToAction("BuscaDeProdutos");
        }

        public async Task<IActionResult> Carrinho(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                await pedidoRepository.AddItem(codigo);
            }

            Pedido taskPedido = await pedidoRepository.GetPedido();
            List<ItemPedido> itens = taskPedido.Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel);
        }

        public async Task<IActionResult> Cadastro()
        {
            var pedido = await pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }

            return View(pedido.Cadastro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resumo(Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                return View(await pedidoRepository.UpdateCadastro(cadastro));
            }
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<UpdateQuantidadeResponse> UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return await pedidoRepository.UpdateQuantidade(itemPedido);
        }
 
        public async Task<IActionResult> BuscaDeProdutos(string pesquisa)
        {
            if (string.IsNullOrEmpty(pesquisa))
            {
                var buscaNula = new BuscaDeProdutosViewModel(await produtoRepository.GetProdutos(), true);
                return View(buscaNula);
            }
            if(produtoRepository.GetProdutos(pesquisa).Result.Count() == 0)
            {
                var buscaSemResultado = new BuscaDeProdutosViewModel(false);
                return View(buscaSemResultado);
            }
            var buscaProdutos = new BuscaDeProdutosViewModel(await produtoRepository.GetProdutos(pesquisa), true);
            return View(buscaProdutos);
        }
    }
}
