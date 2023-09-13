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

// this will handle GET requests to this endpoint. So when an HTTP GET request is sent from the client to this endpoint ON THE SERVER then the client will get this return
app.MapGet("/api/hello", () =>
{
    return new { Message = "Welcome to DeShawn's Dog Walking test"};
    
});

//^ MapGet functions
    //What does MapGet do? It "handles HTTP GET requests for specific routes".."This method is used to specify a route that should handle HTTP GET requests. It maps a URL path to a specific action or handler in your application."

//^ Get a list of ALL dogs from the API database
//^ ENDPOINT TO GET ALL DOGS
// this responds to the HTTP request
app.MapGet("/api/dogs", () =>
{
    return dogs; //this return runs when there is an http request for the endpoint /api/dogs
});

//get a dog by id using a route parameter 
// handler
app.MapGet("/api/dogs/{id}", (int id) => 
{
    //* Below in English: Dog type Dog instance will be assigned the result of a dogs list search for the first or default. So if "1" is passed as the id, then the FOD method on the dogs list will find the dogId number "1" and store that dog instance as a "Dog"
    Dog dog = dogs.FirstOrDefault(d => d.Id == id); //get a dog
    if (dog == null)
    {
        return Results.NotFound();
    }
    City city = cities.FirstOrDefault(c => c.Id == dog.CityId); //match the cityId to the Dog's cityId
    dog.City = city;
    dog.Walker = walkers.FirstOrDefault(w => w.Id == dog.WalkerId);
    return Results.Ok(dog);
});

app.Run();
