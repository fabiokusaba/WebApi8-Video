namespace WebApi8_Video.Dto.Autor
{
    //Modelo provisório - DTO (Data Transfer Object) -> que vai ter as propriedades 'Nome' e 'Sobrenome' e aí dentro do
    //nosso código o nosso usuário vai preencher apenas 'Nome' e 'Sobrenome' e dentro do nosso código a gente vai fazer a
    //transformação desse 'DTO' em um 'AutorModel' e aí sim efetivamente criar dentro do banco
    public class AutorCriacaoDto
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
