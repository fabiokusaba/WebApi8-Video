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

//O nosso código já entendeu que o 'AutorService' implementa os métodos que estão na 'IAutorInterface', porém 'IAutorInterface'
//em nenhum momento colocamos em nosso código para que ele entenda que os métodos que vão estar aqui estão implementados dentro
//da 'Service' então para isso precisamos informar ao nosso código através do 'AddScoped' completando a relação deles
builder.Services.AddScoped<IAutorInterface, AutorService>();
builder.Services.AddScoped<ILivroInterface, LivroService>();

//Aqui é o arquivo que inicia o nosso projeto nós podemos fazer algumas configurações antes do nosso arquivo ter iniciado
//Antes de construir o nosso projeto você precisa pegar a string de conexão que está no 'appsettings' e mandar para o nosso
//AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    //Para essa classe nós precisamos receber algumas informações, nosso construtor recebe informações, portanto vamos receber
    //os nossos 'options' e a primeira coisa que precisamos passar aqui é qual o banco que vamos estar utilizando 'SQL Server',
    //agora precisamos passar a string de conexão para esse banco
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
