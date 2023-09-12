using Microsoft.OpenApi.Services;

//?namespace below is supposedly not needed here bc we aren't declaring any classes in this file.
using DeShawnsAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(); //? this allows for cross-something sharing to where other ports are allowed to provide data

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //? not sure what this means
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => //? something to dow ith security (cors)
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });
}

app.UseHttpsRedirection(); //? don't know what this does

//^ Lists of objects/instances

//^Create a list of dogs with dog type
List<Dog> dogs = new List<Dog>
{
    new Dog()
    {Id = 1, Name = "Fido", CityId = 1, WalkerId = 1},
    new Dog()
    {Id = 2, Name = "Ralph", CityId = 3, WalkerId = 2},
    new Dog()
    {Id = 3, Name = "Dot", CityId = 4, WalkerId = 3},
    new Dog()
    {Id = 4, Name = "Speckles", CityId = 2, WalkerId = 1},
    new Dog()
    {Id = 5, Name = "Socks", CityId = 1, WalkerId = 2},
    new Dog()
    {Id = 6, Name = "Copper", CityId = 3, WalkerId = 1}
};

//^Create a list of walkers with walker type
List<Walker> walkers = new List<Walker>
{
    new Walker()
    {Id = 1, Name = "Fred", Cities = "Denver"},
    new Walker()
    {Id = 2, Name = "John", Cities = "Houston"},
    new Walker()
    {Id = 3, Name = "Tony", Cities = "Nashville"},
    new Walker()
    {Id = 4, Name = "Armando", Cities = "Tampa"},
    new Walker()
    {Id = 5, Name = "Steve", Cities = "Jacksonville"}
};

//^Create a list of cities with city type
List<City> cities = new List<City>
{
    new City()
    {Id = 1, Name = "Houston"},
    new City()
    {Id = 2, Name = "Denver"},
    new City()
    {Id = 3, Name = "Jacksonville"},
    new City()
    {Id = 4, Name = "Nashville"},
    new City()
    {Id = 5, Name = "Tampa"}
};

//^Create a list of walkercities with walkercity type
List<WalkerCity> walkerCities = new List<WalkerCity>
{
    new WalkerCity()
    {Id = 1, CityId = 1, WalkerId = 2}, //walkercity 1 is a Houston-based walker named John
    new WalkerCity()
    {Id = 2, CityId = 4, WalkerId = 3}, //walkercity 2 is a Nashville-based walker named Tony
    new WalkerCity()
    {Id = 3, CityId = 3, WalkerId = 5}, //walkercity 3 is a Jax-based walker named Steve
    new WalkerCity()
    {Id = 4, CityId = 5, WalkerId = 4}, //walkercity 4 is a Tampa-based walker named Armando
    new WalkerCity()
    {Id = 5, CityId = 2, WalkerId = 1} //walkercity 5 is a Denver-based walker named Fred
};

app.MapGet("/api/hello", () =>
{
    return new { Message = "Welcome to DeShawn's Dog Walking" };
});

//^ MapGet functions

//^ Get a list of ALL dogs from the API database
//^ENDPOINT TO GET ALL DOGS
app.MapGet("/api/dogs", () =>
{
    return dogs;
});

app.Run();

//get a dog by id using a route parameter 
// app.MapGet("/api/dog/{i}", (int id) => 
// {
//     //* Below in English: Dog type Dog instance will be assigned the result of a dogs list search for the first or default. So if "1" is passed as the id, then the FOD method on the dogs list will find the dogId number "1" and store that dog instance as a "Dog"
//     Dog dog = dogs.FirstOrDefault(d => d.Id == id);
//     if (dog == null)
//     {
//         return Results.NotFound();
//     }
//     return Results.Ok(dog);
// });

