namespace Webview2Demo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
#if DEBUG
        // 开发时 使用前端项目自己的服务器地址 (比如 webpack , vite 等)
        webView2.Source = new Uri("http://localhost:3000");
#else
        // 发布后, 会把html复制到 wwwroot 交给C#托管
        // 所以这里填 c# 服务器的地址
        webView2.Source = new Uri("http://localhost:5000");

#endif
    }

    private void webView2_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
    {
        //webView2.CoreWebView2.ExecuteScriptAsync("alert('aaa')");
    }

    private void webView2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
    {
        var data = e.WebMessageAsJson;
        webView2.CoreWebView2.PostWebMessageAsJson(data);
    }
}