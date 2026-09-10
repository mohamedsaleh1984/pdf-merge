//using iTextSharp.text;
//using iTextSharp.text.pdf;
using QuestPDF.Fluent;
//using Spire.Pdf;
//using System.Text.RegularExpressions;
//using PdfDocument = Spire.Pdf.PdfDocument;

namespace MergePdf
{
    public class MergePdf
    {
        //public void MergeUsingITextSharp(List<string> files, string fileName)
        //{
        //    string[] fileArray = files.ToArray();

        //    PdfReader? reader = null;
        //    Document? sourceDocument = null;
        //    PdfCopy pdfCopyProvider = null;
        //    PdfImportedPage importedPage;
        //    string outputPdfPath = fileName;
        //    try
        //    {
        //        sourceDocument = new Document();
        //        pdfCopyProvider = new PdfCopy(sourceDocument, new FileStream(outputPdfPath, FileMode.Create));

        //        // Output file Open  
        //        sourceDocument.Open();

        //        // Files list wise Loop  
        //        for (int f = 0; f < fileArray.Length; f++)
        //        {
        //            int pages = TotalPageCount(fileArray[f]);

        //            reader = new PdfReader(fileArray[f]);

        //            // Add pages in new file  
        //            for (int i = 1; i <= pages; i++)
        //            {
        //                importedPage = pdfCopyProvider.GetImportedPage(reader, i);
        //                pdfCopyProvider.AddPage(importedPage);
        //            }

        //            reader.Close();
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
            
        //    // Save the output file  
        //    sourceDocument.Close();
        //}

        //private int TotalPageCount(string file)
        //{
        //    using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(file)))
        //    {
        //        Regex regex = new Regex(@"/Type\s*/Page[^s]");
        //        MatchCollection matches = regex.Matches(sr.ReadToEnd());

        //        return matches.Count;
        //    }
        //}
        //public void ReverseFileITextSharp(string infileName, string outfileName)
        //{
        //    PdfReader reader = null;
        //    Document sourceDocument = null;
        //    PdfCopy pdfCopyProvider = null;
        //    PdfImportedPage importedPage;
        //    string outputPdfPath = outfileName;

        //    sourceDocument = new Document();
        //    pdfCopyProvider = new PdfCopy(sourceDocument, new System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create));
        //    //output file Open  
        //    sourceDocument.Open();

        //    int pages = TotalPageCount(infileName);

        //    reader = new PdfReader(infileName);
        //    int i = pages;

        //    while (i != 0)
        //    {
        //        importedPage = pdfCopyProvider.GetImportedPage(reader, i);
        //        pdfCopyProvider.AddPage(importedPage);
        //        i--;
        //    }

        //    reader.Close();
        //    sourceDocument.Close();
        //}


        //public void MergeUsingSpire(List<string> files, string outputFilePath)
        //{
        //    string[] fileArray = files.ToArray();
        //    PdfDocumentBase pdf = PdfDocument.MergeFiles(fileArray);

        //    // Save the result file
        //    pdf.Save(outputFilePath, FileFormat.PDF);
        //}

        public void MergeUsingQuest(List<string> files, string outputFilePath)
        {
            string[] fileArray = files.ToArray();
            // Load the first document and merge the rest
            var operation = DocumentOperation.LoadFile(fileArray[0]);

            for (int i = 1; i < fileArray.Length; i++)
            {
                operation = operation.MergeFile(fileArray[i]);
            }

            // Save the merged document
            operation.Save(outputFilePath);
        }
    }
}
