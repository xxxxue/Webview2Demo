using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Webview2Demo;

internal static class Program
{

    [STAThread]
    static void Main()
    {
        // ��Ҫ�޸� csproj �ļ�����ʹ�� (Sdk="Microsoft.NET.Sdk.Web")
        var builder = WebApplication.CreateBuilder();

        // ָ�� C# �������Ķ˿�
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
        app.Start();// ���� web ������, Start() ��������.

        // ���� winform ����
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}