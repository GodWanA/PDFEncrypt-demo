// See https://aka.ms/new-console-template for more information
using PDFEncrypter;
using System.Text;

void PrintError(Exception ex)
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine(ex.Message);
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine("-----------------------------------------------------------");
}

// main:
//Console.WriteLine(args.Length);
if (args.Length != 3)
{
    Console.WriteLine("Hiányosak az argomentumok!");
    return -100;
}

var path = args[0];
var pathFinished = args[1];

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

try
{
    if (PDFManipulate.EncryptPDF(path, pathFinished, args[2]))
    {
        Console.WriteLine("Sikeresen lementve");
        Console.WriteLine(path);
        Console.WriteLine(pathFinished);
    }
}
catch (FileNotFoundException ex)
{
    PrintError(ex);
    return -101;
}
catch (ArgumentNullException ex)
{
    PrintError(ex);
    return -102;
}
catch (Exception ex)
{
    PrintError(ex);
    return -103;
}

return 0;