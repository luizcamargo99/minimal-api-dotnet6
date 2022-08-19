using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/users", () =>
{
    return JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"./Data/users.json"));

});

app.MapGet("/user", (int id) =>
{
    var users = new List<User>();
    users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(@"./Data/users.json"));
    return users.FirstOrDefault(u => u.Id == id);
});

app.Run();

internal record User(int Id, string Name, int Age);