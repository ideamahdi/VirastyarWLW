﻿using System;
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

        [Test]
        public void StringReplacement_3()
        {
            const string referenceText = "سلوم به تو ای همیشگی ترین انسان روی زمین";
            const string finalText = "سلام به تو ای همیشگی‌ترین انسان روی زمین";

            var stringRplc = new StringReplacement(referenceText);

            stringRplc.Replace(0, "سلوم".Length, "سلام");
            stringRplc.Replace(referenceText.IndexOf("همیشگی ترین"), "همیشگی ترین".Length, "همیشگی‌ترین");

            Assert.AreEqual(finalText, stringRplc.Text);
        }

        [Test]
        public void StringReplacement_4()
        {
            const string referenceText = 
@"<div dir=""rtl"">
  <pre><font face=""Tahoma"">سلوم به <strong><em>تو</em></strong> ای <strong>همیشگی ترین</strong> انسان روی زمین
</font></pre>
</div>";
            const string finalText =
@"<div dir=""rtl"">
  <pre><font face=""Tahoma"">خداحافظ به <strong><em>تو</em></strong> ای <strong>همیشگی‌ترین</strong> فرد روی ماه
</font></pre>
</div>";

            var stringRplc = new StringReplacement(referenceText);

            stringRplc.Replace(referenceText.IndexOf("سلوم"), "سلوم".Length, "خداحافظ");
            stringRplc.Replace(referenceText.IndexOf("همیشگی ترین"), "همیشگی ترین".Length, "همیشگی‌ترین");
            stringRplc.Replace(referenceText.IndexOf("انسان"), "انسان".Length, "فرد");
            stringRplc.Replace(referenceText.IndexOf("زمین"), "زمین".Length, "ماه");

            Assert.AreEqual(finalText, stringRplc.Text);
        }

        [Test]
        public void StringReplacement_5()
        {
            const string referenceText = "سلوم به تو همیشگی ترین فرد روی زمین";
            const string finalText = "سل به تو همیشگی‌ترین فرد روی زمین";

            var stringRplc = new StringReplacement(referenceText);

            stringRplc.Replace(referenceText.IndexOf("سلوم"), "سلوم".Length, "سلامی");
            stringRplc.Replace(referenceText.IndexOf("همیشگی ترین"), "همیشگی ترین".Length, "همیشگی‌ترین");
            stringRplc.Replace(referenceText.IndexOf("سلوم"), "سلوم".Length, "سلام");
            stringRplc.Replace(referenceText.IndexOf("همیشگی ترین"), "همیشگی ترین".Length, "همیشگی‌ترین");
            stringRplc.Replace(referenceText.IndexOf("سلوم"), "سلوم".Length, "سل");

            Assert.AreEqual(finalText, stringRplc.Text);
        }
    }
}
