using Ecommerce.Produto.Application.DTOs
using Ecommerce.Produto.API.Validators;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;

namespace Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;
        private readonly ProdutoDTOValidator _produtoDTOValidator;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
            _produtoDTOValidator = new ProdutoDTOValidator();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _produtoApplicationService.ObterTodosProdutos();
            if (produtos != null)
                return Ok(produtos);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var produto = _produtoApplicationService.ObterProdutoPorId(id);
            if (produto != null)
                return Ok(produto);

            return BadRequest("Não foi possível obter os dados");
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            ValidationResult result = _produtoDTOValidator.Validate(produtoDTO);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var produto = _produtoApplicationService.SalvarDadosProduto(produtoDTO);
            if (produto != null)
                return Ok(produto);

            return BadRequest("Não foi possível salvar os dados");
        }

        [HttpPut]
        public IActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            ValidationResult result = _produtoDTOValidator.Validate(produtoDTO);
            if (!result.IsValid)
                return BadRequest(result.Errors);

            var produto = _produtoApplicationService.EditarDadosProduto(produtoDTO);
            if (produto != null)
                return Ok(produto);

            return BadRequest("Não foi possível editar os dados");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _produtoApplicationService.DeletarDadosProduto(id);
            if (produto != null)
                return Ok(produto);

            return BadRequest("Não foi possível deletar os dados");
        }
    }
}