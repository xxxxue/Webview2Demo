using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace Webview2Demo;

[ApiController]
public class MyController : ControllerBase
{

    [HttpGet("/ShowMessageBox")]
    public async Task<bool> ShowMessageBox([FromQuery] string msg = "我是消息")
    {
        MessageBox.Show(msg, "标题", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        return await Task.FromResult(true);
    }
}
