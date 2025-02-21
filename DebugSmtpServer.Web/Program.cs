using DebugSmtpServer.Web.Services.Hubs;
using DebugSmtpServer.Web.Services.SmtpListener;
using Microsoft.Extensions.FileProviders;
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

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "frontend", "scripts", "dist"))
            });

            app.MapHub<MailHub>("/mailhub");

            app.Run();
        }
    }
}
