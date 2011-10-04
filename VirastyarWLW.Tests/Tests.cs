using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace VirastyarWLW.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TextRun_Replace()
        {
            var run = new TextRun("سلومی چو بوی خوش آشنایی");
            var newRuns = run.Replace(0, 5, "سلام").ToList();

            Assert.AreEqual(newRuns.Count, 2);

            Assert.AreEqual(newRuns[0].Text, "سلام");
            Assert.AreEqual(newRuns[0].OriginalLength, "سلومی".Length);

            Assert.AreEqual(newRuns.Text(), "سلام چو بوی خوش آشنایی");
        }

        [Test]
        public void StringReplacement_1()
        {
            const string referenceText = "سلومی چوی بوی خوشگ آشنیی";
            const string finalText = "سلام چوی بویتهای خوش آشنایی";
            var stringRplc = new StringReplacement(referenceText);

            stringRplc.Replace(0, 5, "سلام");

            stringRplc.Replace(referenceText.IndexOf("بوی"), 3, "بویتهای");

            stringRplc.Replace(referenceText.IndexOf("خوشگ"), 4, "خوش");

            stringRplc.Replace(referenceText.IndexOf("آشنیی"), 5, "آشنایی");

            Assert.AreEqual(finalText, stringRplc.Text);
        }

        [Test]
        public void StringReplacement_2()
        {
            const string referenceText = "من به همه گفتم من هستم اما او من نیست";
            const string finalText = "مهرداد به همه گفتم مهرداد هستم اما او مهرداد نیست";

            var stringRplc = new StringReplacement(referenceText);

            stringRplc.Replace("من", "مهرداد");

            Assert.AreEqual(finalText, stringRplc.Text);
        }
    }
}
