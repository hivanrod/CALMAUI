namespace CalCore23
{
    public class Program
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        if (app.Environment.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
        }
        app.UseBlazorFrameworkFiles();
        app.MapFallbackToFile("index.html");
        //app.MapRazorPages(); // Remove this line.
        app.Run();
    }
}
