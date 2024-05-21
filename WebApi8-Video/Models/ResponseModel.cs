namespace WebApi8_Video.Models
{
    //Padronização de respostas -> para não precisarmos criar um 'ResponseModel' para 'Autores' e outro para 'Livros' nós
    //vamos ter um 'ResponseModel' genérico, ou seja, um tipo qualquer, a gente pode receber qualquer tipo para esse modelo
    public class ResponseModel<T>
    {
        //Vamos colocar que o 'Dados' pode ser nulo porque ele pode vir nulo quando a gente não encontra nada dentro do banco
        //se der algum erro ele vai ser nulo também e assim por diante, então colocamos essa interrogação '?' para exemplificar
        //isso
        public T? Dados { get; set; }
        //Propriedade que inicia com uma string vazia se não colocarmos nada
        public string Mensagem { get; set; } = string.Empty;
        //Propriedade que inicia como 'true' se não marcarmos nada
        public bool Status { get; set; } = true;

    }
}
