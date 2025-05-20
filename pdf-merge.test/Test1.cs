using Microsoft.VisualStudio.TestPlatform.TestHost;
using MergePdf;
namespace pdf_merge.test
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestArguments()
        {
            string[] args = { "D:\\repo\\Oreilly-Scrape\\Oreilly\\bin\\Debug\\net8.0\\Building Low Latency Applications with C++", "Building Low Latency Applications with C++.pdf" };
            MergePdf.Program.Main(args);
            Assert.IsTrue(true);
        }
    }
}
