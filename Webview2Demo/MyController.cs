using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Furion.DynamicApiController;

using Microsoft.AspNetCore.Mvc;

namespace Webview2Demo;

public class MyController : IDynamicApiController
{
    public string GetName(string name = "哈哈哈")
    {
        return name;
    }

    [HttpGet]
    public async Task<bool> ShowMessageBox([FromQuery]string msg = "我是消息")
    {
        MessageBox.Show(msg, "标题", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        return await Task.FromResult(true);
    }
}
