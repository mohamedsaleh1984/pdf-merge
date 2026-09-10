using QuestPDF.Fluent;

namespace MergePdf
{
    public class MergePdf
    {

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
