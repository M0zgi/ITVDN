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
        float a, b, c = 0;
        string line = path;
        int pos = line.LastIndexOf('/');
        b = Convert.ToInt32(line.Substring(pos + 1));
        line = line.Remove(line.LastIndexOf(@"/"));
        pos = line.LastIndexOf('/');
        a = Convert.ToInt32(line.Substring(pos + 1));

        if (filter.Contains("Add"))
        {
            c = a + b;
            await response.WriteAsync($"{a} + {b} = {c}");
        }
            
        else if (filter.Contains("Mul"))
        {
            c = a * b;
            await response.WriteAsync($"{a} * {b} = {c}");
        }
            
        else if (filter.Contains("Div"))
        {
            if (b == 0)
                await response.WriteAsync("ƒелить нельз€ на 0");
            else
            {
                c = a / b;
                await response.WriteAsync($"{a} / {b} = {c}");
            }
        }

        else if (filter.Contains("Sub"))
        {
            c = a - b;
            await response.WriteAsync($"{a} - {b} = {c}");
        }
                
        else
        {
            await response.WriteAsync("Ќеизвестна€ операци€");
        }
    }

    else
    {
        var stringBuilder = new System.Text.StringBuilder("<html lang=\"en\">\r\n  <head>\r\n    <!-- Required meta tags -->\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n\r\n    <!-- Bootstrap CSS -->\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">\r\n\r\n    <title>List - Info!</title>\r\n  </head>\r\n  <body>");

        stringBuilder.Append("<ul class=\"list-group\">");
        stringBuilder.Append("<li class=\"list-group-item\">—оздайте веб приложение, которое будет обрабатывать запросы по шаблону (цифры ввод€тс€ произвольные):</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-primary\">Calc/Add/20/20 выполн€ет сложение и возвращает значение 40;</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-success\">Calc/Mul/20/10 выполн€ет умножение и возвращает значение 200</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-danger\">Calc/Div/20/10 выполн€ет деление и возвращает значение 2;</li>");
        stringBuilder.Append(" <li class=\"list-group-item list-group-item-warning\">Calc/Sub/20/10 выполн€ет вычитание и возвращает значение 10.</li>");

        stringBuilder.Append("</ul> </body>\r\n</html>");
        await response.WriteAsync(stringBuilder.ToString());
    }
});
app.Run();