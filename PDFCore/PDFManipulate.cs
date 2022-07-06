using PdfSharp.Pdf.IO;
using System.Text;

namespace PDFEncrypter
{
    public class PDFManipulate
    {
        /// <summary>
        /// Lejelszavazza a forrás állományt, és lementi egy új néven.
        /// </summary>
        /// <param name="sPath">Forrás útvonal</param>
        /// <param name="dPath">Cél útvonal</param>
        /// <param name="pw">Jelszó</param>
        /// <returns>True, ha sikerült</returns>
        /// <exception cref="FileNotFoundException">Forrás állomány nem létezik.</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool EncryptPDF(string sPath, string dPath, string pw)
        {
            if (!File.Exists(sPath)) throw new FileNotFoundException("Source file not found!");
            if (pw == null || pw == string.Empty) throw new ArgumentNullException("Pasword is null, or empty!");

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            using (var streamReader = new FileStream(sPath, FileMode.Open, FileAccess.ReadWrite))
            using (var pdfDoc = PdfReader.Open(streamReader))
            {
                pdfDoc.SecuritySettings.UserPassword = pw;
                pdfDoc.Save(dPath);

                pdfDoc.Close();
            }

            return true;
        }
    }
}
