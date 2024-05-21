using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Dto.Livro;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Livro;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterace;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterace = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await _livroInterace.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int idLivro)
        {
            var livro = await _livroInterace.BuscarLivroPorId(idLivro);
            return Ok(livro);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            var livro = await _livroInterace.BuscarLivroPorIdAutor(idAutor);
            return Ok(livro);
        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            var livros = await _livroInterace.CriarLivro(livroCriacaoDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterace.EditarLivro(livroEdicaoDto);
            return Ok(livros);
        }

        [HttpDelete("ExcluirLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int idLivro)
        {
            var livros = await _livroInterace.ExcluirLivro(idLivro);
            return Ok(livros);
        }
    }
}
