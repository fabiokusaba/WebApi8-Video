using Microsoft.EntityFrameworkCore;
using WebApi8_Video.Data;
using WebApi8_Video.Services.Autor;
using WebApi8_Video.Services.Livro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//O nosso c�digo j� entendeu que o 'AutorService' implementa os m�todos que est�o na 'IAutorInterface', por�m 'IAutorInterface'
//em nenhum momento colocamos em nosso c�digo para que ele entenda que os m�todos que v�o estar aqui est�o implementados dentro
//da 'Service' ent�o para isso precisamos informar ao nosso c�digo atrav�s do 'AddScoped' completando a rela��o deles
builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddScoped<ILivroInterface, LivroService>();

//Aqui � o arquivo que inicia o nosso projeto n�s podemos fazer algumas configura��es antes do nosso arquivo ter iniciado
//Antes de construir o nosso projeto voc� precisa pegar a string de conex�o que est� no 'appsettings' e mandar para o nosso
//AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //Para essa classe n�s precisamos receber algumas informa��es, nosso construtor recebe informa��es, portanto vamos receber
    //os nossos 'options' e a primeira coisa que precisamos passar aqui � qual o banco que vamos estar utilizando 'SQL Server',
    //agora precisamos passar a string de conex�o para esse banco
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
