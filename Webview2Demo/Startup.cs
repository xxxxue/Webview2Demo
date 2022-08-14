using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Webview2Demo;


public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {

        services.AddCorsAccessor();

        services.AddControllers()
                .AddInjectWithUnifyResult();

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        //app.UseHttpsRedirection();

        // 将 "/index.html" 映射到 "/"
        app.UseDefaultFiles();

        // 重写 静态文件路由
        //app.UseStaticFiles(new StaticFileOptions
        //{
        //    FileProvider = new PhysicalFileProvider(
        //    Path.Combine(env.ContentRootPath, "Next.js/my-app/out")),
        //    RequestPath = ""
        //});
        //app.UseStaticFiles(new StaticFileOptions
        //{
        //    FileProvider = new PhysicalFileProvider(
        //        Path.Combine(env.ContentRootPath, "wwwroot")),
        //    RequestPath = "/wwwroot"
        //});

        app.UseStaticFiles();


        app.UseRouting();

        app.UseCorsAccessor();

        app.UseAuthentication();
        app.UseAuthorization();

        // 使用furion . 并指定 swagger 的地址前缀 
        app.UseInject("swagger"); //http://localhost:5000/swagger 可以跳转到swagger页面

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
