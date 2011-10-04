using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirastyarWLW
{
    public class StringReplacement
    {
        private string m_text;

        private readonly List<TextRun> m_runs = new List<TextRun>();

        public StringReplacement(string text)
        {
            m_text = text;
            m_runs.Add(new TextRun(text));
        }

        public string Text
        {
            get 
            {
                return m_runs.Text();
            }
        }

        public void Replace(int index, int length, string newValue)
        {
            var lengthSoFar = 0;
            int targetTextRunIndex = -1;
            TextRun targetTextRun = null;
            for (int i = 0; i < m_runs.Count; i++)
            {
                var textRun = m_runs[i];
                if (index <= lengthSoFar + textRun.OriginalLength)
                {
                    targetTextRun = textRun;
                    targetTextRunIndex = i;
                    break;
                }
                //int diff = textRun.Length - textRun.OriginalLength;
                lengthSoFar += textRun.OriginalLength;
            }

            if (targetTextRun == null)
                throw new ArgumentException();

            var newRuns = targetTextRun.Replace(index - lengthSoFar, length, newValue);
            m_runs.RemoveAt(targetTextRunIndex);
            m_runs.InsertRange(targetTextRunIndex, newRuns);
        }

        public void Replace(string oldValue, string newValue)
        {
            var newRuns = new List<TextRun>();
            foreach (var textRun in m_runs)
            {
                newRuns.AddRange(textRun.Replace(oldValue, newValue));
            }

            m_runs.Clear();
            m_runs.AddRange(newRuns);
        }
    }

    public class TextRun
    {
        public TextRun(string text)
        {
            Text = text;
            OriginalLength = Length;
        }

        public TextRun(string text, int originalLength)
        {
            Text = text;
            OriginalLength = originalLength;
        }

        public string Text
        {
            get;
            private set;
        }

        public int OriginalLength
        {
            get;
            private set;
        }
        
        public int Length
        {
            get
            {
                return Text.Length;
            }
        }

        public IEnumerable<TextRun> Replace(int index, int length, string replacement)
        {
            if (index + length > Length)
                throw new ArgumentException();

            if (index > 0)
            {
                var firstRun = new TextRun(Text.Substring(0, index));
                yield return firstRun;
            }

            var replacedRun = new TextRun(replacement, length);
            yield return replacedRun;

            if (index + length < Length - 1)
            {
                var thirdRun = new TextRun(Text.Substring(index + length, Length - (index + length)));
                yield return thirdRun;
            }
        }

        public IEnumerable<TextRun> Replace(string oldValue, string newValue)
        {
            int indexSoFar = -1;
            int lastIndexOfRun = 0;
            while (true)
            {
                indexSoFar = Text.IndexOf(oldValue, indexSoFar + 1);
                if (indexSoFar - lastIndexOfRun > 0)
                    yield return new TextRun(Text.Substring(lastIndexOfRun, indexSoFar - lastIndexOfRun));

                if (indexSoFar < 0)
                    break;

                lastIndexOfRun = indexSoFar + oldValue.Length;
                yield return new TextRun(newValue, oldValue.Length);    
            }

            if (lastIndexOfRun < Text.Length - 1)
                yield return new TextRun(Text.Substring(lastIndexOfRun, Text.Length - lastIndexOfRun));
        }
    }

    public static class Extensions
    {
        public static string Text(this List<TextRun> list)
        {
            var sb = new StringBuilder();
            foreach (var textRun in list)
            {
                sb.Append(textRun.Text);
            }
            return sb.ToString();
        }
    }
}