namespace Webview2Demo
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {

            Serve.Run(RunOptions.DefaultSilence, urls: "http://localhost:5000");

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}