namespace MergePdf
{
    public class Program
    {
        public static void Main(string[] args)
        {

            GeneratePDF("C:\\Users\\Moham\\OneDrive\\Desktop\\Job Offer", "C:\\Users\\Moham\\OneDrive\\Desktop\\Job Offer\\Job-Offer.pdf");
        }

        public static void GeneratePDF(string strInput, string strOutputFileName)
        {
            List<string> files = Directory.GetFiles(strInput).Where(x => x.ToLower().EndsWith(".pdf")).ToList();
            MergePdf cls = new  MergePdf();
            cls.MergeUsingQuest(files, strOutputFileName);
        }

        private static void Cmd(string[] args)
        {
            if (args.Length > 1)
            {
                string strDir = args[0];
                Console.Write(strDir);
                string strFileName = args[1];
                Console.Write(strFileName);
                string strOutputFileName = Path.Combine(strDir, strFileName);
                Console.Write(strOutputFileName);
                GeneratePDF(strDir, strOutputFileName);
            }
            else
            {
                throw new Exception("Parameter are missing.");
            }
        }
    }
}