using WebApi8_Video.Dto.Vinculo;

namespace WebApi8_Video.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Titulo { get; set; }
        //E agora quando eu for criar o meu 'LivroCriacaoDto' eu não uso um 'AutorModel', eu uso um 'AutorVinculoDto'
        public AutorVinculoDto Autor { get; set; }
    }
}
