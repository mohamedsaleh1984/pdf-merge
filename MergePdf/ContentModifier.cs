using iTextSharp.text.pdf;
using System.Text;

namespace MergePdf
{
	internal class ContentModifier
	{
		public  void ChangeContent(string oldFile,string newFile)
		{
			PdfReader reader = new PdfReader(oldFile);
			RandomAccessFileOrArray accessFileOrArray = new RandomAccessFileOrArray(oldFile);
			byte[] pageBytes= reader.GetPageContent(1, accessFileOrArray);

			string dataInAscii =  Encoding.ASCII.GetString(pageBytes);
			Console.WriteLine(dataInAscii);

			reader.Close();
		}

		public void GetPdfInfo(string filePath)
		{
			// open the reader
			PdfReader reader = new PdfReader(filePath);
			Console.WriteLine($"IsEncrypted {reader.IsEncrypted()}");
			Console.WriteLine($"Appendable {reader.Appendable}");
			Console.WriteLine($"Is128Key {reader.Is128Key()}");
			Console.WriteLine($"IsHybridXref {reader.IsHybridXref()}");
			Console.WriteLine($"IsNewXrefType {reader.IsNewXrefType()}");
			Console.WriteLine($"IsTagged {reader.IsTagged()}");
			Console.WriteLine($"IsRebuilt {reader.IsRebuilt()}");
			Console.WriteLine($"IsOpenedWithFullPermissions {reader.IsOpenedWithFullPermissions}");
			
			Dictionary<string, string> data = reader.Info;
			foreach( string key in data.Keys )
				Console.WriteLine($"key {data[key]}");

			reader.Close();
		}
	}
}
