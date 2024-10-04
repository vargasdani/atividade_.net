using Ecommerce.Produto.Domain.Entities;
using Ecommerce.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaApplicationService _categoriaApplicationService;

        public CategoriaController(ICategoriaApplicationService categoriaApplicationService)
        {
            _categoriaApplicationService = categoriaApplicationService;
        }

        /// <summary>
        /// Metodo para obter todos os dados de categoria
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<CategoriaEntity>>]
        public IActionResult Get()
        {
            var categorias = _categoriaApplicationService.ObterTodasCategorias();

            if(categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }

        /// <summary>
        /// Metodo para obter uma categoria
        /// </summary>
        /// <param name="id"> Identificado da categoria</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult GetPorId(int id)
        {
            var categorias = _categoriaApplicationService.ObterCategoriaPorId(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel obter os dados");
        }


        /// <summary>
        /// Metodos para salvar a categoria
        /// </summary>
        /// <param name="entity"> Modelo de dados da Categoria</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<CategoriaEntity>]
        public IActionResult Post(CategoriaEntity entity)
        {
            var categorias = _categoriaApplicationService.SalvarDadosCategoria(entity);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel salvar os dados");
        }

        /// <summary>
        /// Metodos para editar a categoria
        /// </summary>
        /// <param name="entity"> Modelo de dados da Categoria</param>
        /// <returns></returns>
        [HttpPut]
        [Produces<CategoriaEntity>]
        public IActionResult Put(CategoriaEntity entity)
        {
            var categorias = _categoriaApplicationService.EditarDadosCategoria(entity);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel editar os dados");
        }

        /// <summary>
        /// Metodo para deletar uma categoria
        /// </summary>
        /// <param name="id"> Identificado da categoria</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<CategoriaEntity>]
        public IActionResult Delete(int id)
        {
            var categorias = _categoriaApplicationService.DeletarDadosCategoria(id);

            if (categorias is not null)
                return Ok(categorias);

            return BadRequest("Não foi possivel deletar os dados");
        }
    }
}
