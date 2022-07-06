
namespace PDFFramework
{
    public interface IPDFManipulate
    {
        bool EncryptPDF(string sPath, string dPath, string pw);
    }
}
