using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Autor
{
    //Aqui na interface nós vamos iniciar colocando os métodos que a gente precisa
    public interface IAutorInterface
    {
        //Task -> porque vai ser um método assíncrono
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);
    }
}
