namespace frontend;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8.25f));
        Application.Run(new MainForm());
    }    
}