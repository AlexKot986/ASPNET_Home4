using GraphQlApi.GraphQls;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<HttpClient>();
builder.Services.AddScoped<IGraphService, GraphService>();


builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();



var app = builder.Build();

app.MapGraphQL();


app.Run();

