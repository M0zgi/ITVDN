using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async(context) => 
{
    context.Response.ContentType = "text/html; charset=utf-8";
    var path = context.Request.Path;
    var response = context.Response;

 
    if (path=="/Test/Message")
        await response.WriteAsync("Hello world");
    else if (path == "/List/Info")
    {
        var stringBuilder = new System.Text.StringBuilder("<html lang=\"en\">\r\n  <head>\r\n    <!-- Required meta tags -->\r\n    <meta charset=\"utf-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n\r\n    <!-- Bootstrap CSS -->\r\n    <link href=\"https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css\" rel=\"stylesheet\" integrity=\"sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC\" crossorigin=\"anonymous\">\r\n\r\n    <title>List - Info!</title>\r\n  </head>\r\n  <body>");

        stringBuilder.Append("<ul class=\"list-group\">");
        stringBuilder.Append("<li class=\"list-group-item\">A simple default list group item</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-primary\">A simple primary list group item</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-success\">A simple success list group item</li>");
        stringBuilder.Append("<li class=\"list-group-item list-group-item-danger\">A simple danger list group item</li>");
        stringBuilder.Append(" <li class=\"list-group-item list-group-item-warning\">A simple warning list group item</li>");

        stringBuilder.Append("</ul> </body>\r\n</html>");
        await response.WriteAsync(stringBuilder.ToString());
    }
        
    else
        await response.WriteAsync("Hello CyberBionic Systematics");
});
app.Run();
