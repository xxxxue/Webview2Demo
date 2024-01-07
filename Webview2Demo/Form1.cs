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
        // ����ʱ ʹ��ǰ����Ŀ�Լ��ķ�������ַ (���� webpack , vite ��)
        webView2.Source = new Uri("http://localhost:3000");
#else
        // ������, ���html���Ƶ� wwwroot ����C#�й�
        // ���������� c# �������ĵ�ַ
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