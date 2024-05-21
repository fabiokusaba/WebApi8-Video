using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.Dto.Autor;
using WebApi8_Video.Models;

namespace WebApi8_Video.Services.Autor
{
    //Repository Pattern como padrão de desenvolvimento -> nós precisamos ter serviços e interfaces porque basicamente não
    //queremos que todo o nosso código fique dentro do nosso 'Controller' para não criarmos controllers gordos/fat controllers
    //com muita informação dificultando a manutenabilidade do código futuramente então dentro do nosso 'Controller' ele vai ter
    //apenas uma conexão com a nossa interface, é a interface que vai ter diversos métodos que vão precisar ser executados e a
    //implementação desses métodos vão estar sendo desenvolvidos dentro dos nossos serviços
    //'Controller' -> 'Interface' -> 'Service'
    //E é o serviço que vai se conectar ao banco de dados fazer as solicitações, as inserções, as remoções e devolver as
    //informações para o nosso 'Controller'

    //'AutorService' é referenciada e respeita as regras que estão no nosso 'IAutorInterface', agora ambas estão interligadas
    public class AutorService : IAutorInterface
    {
        //Dentro dessa classe precisamos ter acesso ao nosso contexto porque precisamos ter acesso ao banco de dados, para
        //buscar o autor pelo id eu preciso me conectar ao banco e dentro do banco buscar os autores que estão lá, então
        //a partir da '_context' nós temos acesso ao nosso contexto, conseguimos nos conectar ao banco e ter acesso as nossas
        //tabelas
        private readonly AppDbContext _context;

        public AutorService(AppDbContext context)
        {
            _context = context;
        }

        //Aqui no 'Task' podemos colocar um 'async' porque vai ser um método assíncrono
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = autor;
                resposta.Mensagem = "Autor localizado!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                //Aqui a gente está buscando um autor específico de acordo com um id de um livro que nós colocarmos
                //Dessa vez nós vamos entrar dentro da tabela de 'Livros' e não de 'Autores' porque dentro da tabela de 'Livros'
                //eu tenho o meu 'AutorId' e meu 'LivroId', perceba que nesse nosso método nós estamos passando o 'idLivro'
                //então vou precisar entrar na tabela de 'Livros' encontrar o 'idLivro' e daí vou pegar o 'AutorId'
                //Aqui precisamos dar um 'Include' porque dentro do nosso modelo de 'LivroModel' eu tenho objeto de 'AutorModel'
                //estamos fazendo o seguinte -> vou pegar o 'LivroModel', toda a propriedade de livro, porém preciso entrar
                //dentro do 'AutorModel' e pegar todos os dados do autor e é isso que o 'Include' está fazendo
                //Pegando todas as propriedades nós podemos utilizar o 'FirstOrDefaultAsync' para pegar o primeiro elemento que
                //obedeça a uma regra
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor localizado!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor criado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }

                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum autor localizado!";
                    return resposta;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor removido com sucesso!";

                return resposta;
            }
            catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            //Criando o nosso objeto de resposta
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            //Primeira coisa que precisamos fazer é colocar o nosso 'try catch' porque vamos tentar efetuar uma informação
            //um trecho de código e se der algum erro nós caímos dentro do 'catch', então já temos uma tratavida de erros aqui
            //vamos tentar realizar uma operação e se não der certo a gente cai dentro do 'catch', caindo dentro do 'catch' a
            //gente pode tratar o erro e enviar um erro mais personalizado para o nosso usuário final
            try
            {
                //Vamos tentar pegar uma lista de autores de dentro do nosso banco, para isso nós precisamos entrar dentro
                //do nosso banco '_context', entrar na nossa tabela de 'Autores' e dentro dessa tabela dar um 'ToList', porém
                //eu não sei se a minha quantidade de autores no banco são 10 autores ou se são 1000 autores e dependendo da
                //quantidade de autores que eu tenho cadastrado esse processo pode demorar ou esse processo pode ser rápido e
                //eu só quero que o meu código continue para a próxima diretiva quando ele tenha pegado todos os autores que
                //tem dentro do banco, então eu preciso esperar, esperar que o processo de coleta de dados dentro do banco
                //ocorra antes que eu efetivamente possa dar continuidade ao nosso código e pra esperar nós utilizamos esse
                //método assíncrono 'async' então já coloquei que ele é assíncrono e retorna um 'Task' agora preciso colocar
                //aqui que eu quero esperar 'await' que esse processo ocorra
                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
                resposta.Mensagem = "Todos os autores foram coletados!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
