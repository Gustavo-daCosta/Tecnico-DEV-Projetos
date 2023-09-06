using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Adiciona o serviço de controllers
builder.Services.AddControllers();

// Adiciona o serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
    // Define os parâmetros de validação do Token
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Valida quem está solicitando
            ValidateIssuer = true,

            // Valida quem está recebendo
            ValidateAudience = true,

            // Define se o tempo de expiração do token será validado
            ValidateLifetime = true,

            // Forma de criptografia e ainda validação da chave de autenticação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            // Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            // De onde está vindo (issuer)
            ValidIssuer = "webapi.filmes.tarde",

            // Para onde está indo (audience)
            ValidAudience = "webapi.filmes.tarde",
        };
    });



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "InLock Games API",
        Description = "An ASP.NET Core Web API for games management - API, Sprint 2",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Gustavo-daCosta Github",
            Url = new Uri("https://github.com/Gustavo-daCosta")
        }
    });

    // Configure o Swagger para usar o arquivo XML gerado
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    // Usando a autenticação no Swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
            },
            new string[]{}
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Utiliza as autenticações e autorizações
app.UseAuthentication();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();
app.Run();