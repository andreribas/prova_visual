using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/inicializar")]
    public class InicializarDadosController : ControllerBase
    {
        private readonly DataContext _context;
        public InicializarDadosController(DataContext context)
        {
            _context = context;
        }

        //POST: api/inicializar/create
        [HttpPost]
        [Route("create")]
        public IActionResult Create()
        {
            _context.Categorias.AddRange(new Categoria[]
                {
                    new Categoria { CategoriaId = 1, Nome = "Comida" },
                }
            );
            _context.Produtos.AddRange(new Produto[]
                {
                    new Produto { ProdutoId = 1, Nome = "Pizza", Preco = 15, Quantidade = 10, CategoriaId = 1 },
                    new Produto { ProdutoId = 2, Nome = "Hotdog", Preco = 10, Quantidade = 20, CategoriaId = 1 },
                    new Produto { ProdutoId = 3, Nome = "Hãm Burguer", Preco = 14, Quantidade = 30, CategoriaId = 1 },
                }
            );
            _context.FormaPagamentos.AddRange(new FormaPagamento[]
                {
                    new FormaPagamento { FormaPagamentoId = 1, Tipo = "Credito", Bandeira = "Mastercard" },
                    new FormaPagamento { FormaPagamentoId = 2, Tipo = "Debito", Bandeira = "Maestro" },
                }
            );
            _context.SaveChanges();
            return Ok(new { message = "Dados inicializados com sucesso!" });
        }
    }
}