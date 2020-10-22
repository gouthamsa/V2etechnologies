using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace pdfsplit
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "pdfspliter.pdf";
            string filepath = @"/home/goutham/Desktop/" + filename + "/";
            string pdfPath = @"/home/goutham/Desktop/pdf-split/pdfspliter.pdf";
            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }
            string outputPath = @filepath;
            int splitlimit = 1;
            int pageName = 0;

            PdfReader scan = new PdfReader(pdfPath);

            FileInfo file = new FileInfo(pdfPath);
            string pdfFileName = file.Name.Substring(0, file.Name.LastIndexOf(".")) + "-";

            Program obj = new Program();

            for (int pageNumber = 1; pageNumber <= scan.NumberOfPages; pageNumber += splitlimit)
            {
                pageName++;
                string newPdfFileName = string.Format(pdfFileName + "{0}", pageName);
                obj.SplitAndSaveInterval(pdfPath, outputPath, pageNumber, splitlimit, newPdfFileName);
            }
        }


        private void SplitAndSaveInterval(string pdfPath, string outputPath, int startPage, int splitlimit, string pdfFileName)
        {
            using (PdfReader scan = new PdfReader(pdfPath))
            {
                Document document = new Document();
                PdfCopy copy = new PdfCopy(document, new FileStream(outputPath + " " + pdfFileName + ".pdf", FileMode.Create));
                document.Open();

                for (int pagenumber = startPage; pagenumber < (startPage + splitlimit); pagenumber++)
                {
                    if (scan.NumberOfPages >= pagenumber)
                    {
                        copy.AddPage(copy.GetImportedPage(scan, pagenumber));
                    }
                    else
                    {
                        break;
                    }

                }

                document.Close();
            }
        }
    }
}

