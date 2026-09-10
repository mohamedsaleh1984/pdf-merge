using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace MergePdf
{
    public class MergePdf
    {
        public void MergeUsingITextSharp(List<string> files, string fileName)
        {
            string[] fileArray = files.ToArray();

            PdfReader? reader = null;
            Document? sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = fileName;

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));

            // Output file Open  
            sourceDocument.Open();

            // Files list wise Loop  
            for (int f = 0; f < fileArray.Length; f++)
            {
                int pages = TotalPageCount(fileArray[f]);

                reader = new PdfReader(fileArray[f]);

                // Add pages in new file  
                for (int i = 1; i <= pages; i++)
                {
                    importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                    pdfCopyProvider.AddPage(importedPage);
                }

                reader.Close();
            }

            // Save the output file  
            sourceDocument.Close();
        }

        private int TotalPageCount(string file)
        {
            using (StreamReader sr = new StreamReader(File.OpenRead(file)))
            {
                Regex regex = new Regex(@"/Type\s*/Page[^s]");
                MatchCollection matches = regex.Matches(sr.ReadToEnd());

                return matches.Count;
            }
        }
        public void ReverseFileITextSharp(string infileName, string outfileName)
        {
            PdfReader reader = null;
            Document sourceDocument = null;
            PdfCopy pdfCopyProvider = null;
            PdfImportedPage importedPage;
            string outputPdfPath = outfileName;

            sourceDocument = new Document();
            pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
            //output file Open  
            sourceDocument.Open();

            int pages = TotalPageCount(infileName);

            reader = new PdfReader(infileName);
            int i = pages;

            while (i != 0)
            {
                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                pdfCopyProvider.AddPage(importedPage);
                i--;
            }

            reader.Close();
            sourceDocument.Close();
        }



        public void ExtractAllPages(string infileName, string outputDir)
        {
            int pages = TotalPageCount(infileName);

            for (int i = 1; i <= pages; i++)
            {
                string outputPdfPath = Path.Combine(outputDir, $"Page-{i}.pdf");

                PdfReader? reader = null;
                Document? sourceDocument = null;
                PdfCopy pdfCopyProvider = null;
                PdfImportedPage importedPage;

                sourceDocument = new Document();
                pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));

                // Output file Open  
                sourceDocument.Open();


                reader = new PdfReader(infileName);


                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
                pdfCopyProvider.AddPage(importedPage);


                reader.Close();

                // Save the output file  
                sourceDocument.Close();
            }

        }
    }
}
