using stringMatching;
namespace frontend;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        int posn = BM.BMmatch("aaaaaaaaa", "aaaa");
        Console.WriteLine(posn);
    }
}
