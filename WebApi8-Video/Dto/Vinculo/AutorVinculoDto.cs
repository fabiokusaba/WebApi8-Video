namespace WebApi8_Video.Dto.Vinculo
{
    //Quando tentávamos criar um livro estávamos utilizando o 'AutorModel' e quando abrimos ele nós temos a propriedade
    //'Livros' e isso estava gerando um erro em que não estávamos preenchendo a propriedade 'Livros', então para solucionar
    //esse problema nós criamos um 'AutorVinculoDto' para criar esse vínculo entre o 'Autor' e o 'Livro', um vínculo onde
    //esse 'AutorVinculoDto' que vamos estar criando ele não tenha essa propriedade de 'Livros' e tenha apenas as propriedades
    //'Id', 'Nome', 'Sobrenome'
    public class AutorVinculoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
