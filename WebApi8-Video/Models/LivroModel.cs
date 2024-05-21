namespace WebApi8_Video.Models
{
    //Classe que vai ser mapeada e que vai servir como base para criação da nossa tabela de livro
    public class LivroModel
    {
        //Propriedades que essa classe vai ter e que vão ser mapeadas mais pra frente em colunas
        public int Id { get; set; }
        public string Titulo { get; set; }

        //Relacionamento entre tabelas -> cada livro pode ter somente um autor
        public AutorModel Autor { get; set; }
    }
}
