var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseRouting();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapFallbackToFile("index.cshtml");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "index",
    defaults: new { controller = "Home", action = "Index" });

app.UseMvc(routes =>
{

    routes.MapRoute(
        name: "default",
        template: "{contoller=Home}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
