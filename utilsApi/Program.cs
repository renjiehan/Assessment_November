
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// For CORS issue.
// Additionally, using axios to deal with the issue at frontend
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000",
                                 "https://localhost:3000");
        });
});

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
// ref https://www.bytehide.com/blog/cors-aspnet-core#:~:text=an%20exhilarating%20ride!-,Step%2Dby%2Dstep%20Guide%20to%20Enabling%20CORS%20in%20Web%20API,by%2Dstep%20with%20code%20examples.

// Instead of applying AllowAnyOrigin that is unsafe to the server that could be attacked from malicious user,
// allowing specific port mitigate the risk from attacking
// Below are the options to use CORS
// app.UseCors(builder => builder.AllowAnyOrigin()); // Allow requests from any origin
// app.UseCors(builder => builder.WithOrigins("http://domain.com")); // Allow requests only from domain.com
// app.UseCors(builder => builder.AllowAnyHeader()); // Allow any header in the request
// app.UseCors(builder => builder.AllowAnyMethod()); // Allow any HTTP method in the request
app.UseCors(MyAllowSpecificOrigins);

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.Run();
