using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
// Adiciona o servi�o de controllers
builder.Services.AddControllers();

// Adiciona o servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
    // Define os par�metros de valida��o do Token
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Valida quem est� solicitando
            ValidateIssuer = true,

            // Valida quem est� recebendo
            ValidateAudience = true,

            // Define se o tempo de expira��o do token ser� validado
            ValidateLifetime = true,

            // Forma de criptografia e ainda valida��o da chave de autentica��o
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

            // Valida o tempo de expira��o do token
            ClockSkew = TimeSpan.FromMinutes(5),

            // De onde est� vindo (issuer)
            ValidIssuer = "webapi.filmes.tarde",

            // Para onde est� indo (audience)
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

    // Usando a autentica��o no Swagger
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

// Utiliza as autentica��es e autoriza��es
app.UseAuthentication();
app.UseAuthorization();

// Mapear os controllers
app.MapControllers();
app.Run();