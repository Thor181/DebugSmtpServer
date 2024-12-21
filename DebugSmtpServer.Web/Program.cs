using DebugSmtpServer.Web.Services.Hubs;
using DebugSmtpServer.Web.Services.SmtpListener;
using System.Diagnostics;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace DebugSmtpServer.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSignalR().AddJsonProtocol(op =>
            {
                op.PayloadSerializerOptions = new System.Text.Json.JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            });

            builder.Services.AddHostedService<SmtpListener>();

            var app = builder.Build();

            app.UseFileServer();

            app.MapHub<MailHub>("/mailhub");

            app.MapGet("/", async (context) =>
            {
                const string indexPath = "wwwroot/frontend/scripts/dist/index.html";
#if DEBUG
            step1:
                try
                {
                    context.Response.ContentType = "text/html";
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    await context.Response.WriteAsync(System.IO.File.ReadAllText(indexPath));
                    return;
                }
                catch (FileNotFoundException)
                {
                    goto step1;
                }
#endif

                context.Response.ContentType = "text/html";
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                await context.Response.WriteAsync(System.IO.File.ReadAllText(indexPath));
            });

            app.Run();
        }
    }
}
