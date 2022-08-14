using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Webview2Demo;

internal static class Program
{

    [STAThread]
    static void Main()
    {
        // 需要修改 csproj 文件才能使用 (Sdk="Microsoft.NET.Sdk.Web")
        var builder = WebApplication.CreateBuilder();

        // 指定 C# 服务器的端口
        builder.WebHost.UseUrls("http://localhost:5000");

        builder.Services.AddControllers();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("all", builder =>
            {
                builder
                .WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
                .AllowAnyHeader()
                .AllowAnyOrigin();
                //.AllowCredentials()
            });
        });


        var app = builder.Build();

        app.UseCors("all");
        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.MapControllers();
        app.Start();// 启动 web 服务器, Start() 不会阻塞.

        // 启动 winform 窗口
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}