var builder = WebApplication.CreateBuilder(args);
var example = new example_space.Example();
              Dictionary<string, string> options = new Dictionary<string, string>();
              options["organizations"] = "";
              options["users"] = "";
              options["projects"] = "";
              string auth = example.auth("rkcudjoe@hookengine.com","hookdev001");
              example.screenshots("2016-09-01", "2016-09-07", 0, options, auth);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
