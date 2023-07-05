using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    //everytime we try to instantiate a IBreakfastService we use the implementaion of BreakfastService
    builder.Services.AddScoped<IBreakfastService,BreakfastService>();
}

var app = builder.Build();  
{   
    //In case of an exception, redirect to "/error"
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();  
    app.MapControllers();
    app.Run();
}

