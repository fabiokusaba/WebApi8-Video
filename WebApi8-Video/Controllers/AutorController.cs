using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;
using WebApi8_Video.Services.Autor;

namespace WebApi8_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        //Primeiro precisamos receber a nossa interface para termos acessos aos métodos
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        //Criando os endpoints que vão buscar as informações

        //É um método 'public' público, assíncrono 'async' porque precisamos esperar, consequentemente ele é um 'Task', ele vai
        //nos retornar um 'ActionResult' porque ele pode nos retornar um resultado '200' que tudo deu certo, '404', '409', '500'
        //vai depender da 'Action' que vamos querer estar retornando, esse nosso 'ActionResult' vai ser do tipo 'ResponseModel'
        //e nosso 'ResponseModel' vai ser do tipo 'List' de 'AutorModel' e o nome do nosso método vai ser 'ListarAutores'
        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autor = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autor);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDto);
            return Ok(autores);
        }

        [HttpDelete("ExcluirAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);
        }
    }
}
