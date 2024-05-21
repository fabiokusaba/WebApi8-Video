using System.Text.Json.Serialization;

namespace WebApi8_Video.Models
{
    //Classe que vai ser mapeada e que vai servir como base para criação da nossa tabela de autor
    public class AutorModel
    {
        //Propriedades que essa classe vai ter e que vão ser mapeadas mais pra frente em colunas
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        //A diretiva JsonIgnore vai ser útil para quando estamos criando um autor não precisarmos preencher com todos os livros
        //que ele já tem registrado, ele vai ignorar essa propriedade que serve apenas para fazer a correlação entre LivroModel
        //e AutorModel não sendo utilizada efetivamente para criar os livros no momento que estou criando o autor
        [JsonIgnore]
        //Relacionamento entre tabelas -> cada autor pode ter vários livros em seu nome
        public ICollection<LivroModel> Livros { get; set; }
    }
}
