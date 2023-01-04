using Microsoft.AspNetCore.Http;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async (context) =>
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var path = context.Request.Path;
    var response = context.Response;

    string filter = path;


    if (filter.Contains("Calc"))
    {
        int a, b, c = 0;
        string line = path;
        int pos = line.LastIndexOf('/');
        b = Convert.ToInt32(line.Substring(pos + 1));
        line = line.Remove(line.LastIndexOf(@"/"));
        pos = line.LastIndexOf('/');
        a = Convert.ToInt32(line.Substring(pos + 1));

        if (filter.Contains("Add"))
            c = a + b;
        if (filter.Contains("Mul"))
            c = a * b;
        if (filter.Contains("Div"))
        {
            if (b == 0)
                await response.WriteAsync("Делить нельзя на ");
            else 
                c = a / b;
        }
            
        if (filter.Contains("Sub"))
            c = a - b;

        await response.WriteAsync(c.ToString());
    }

    else
        await response.WriteAsync("Hello CyberBionic Systematics");
});
app.Run();