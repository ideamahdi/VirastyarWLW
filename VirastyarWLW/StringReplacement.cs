using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace VirastyarWLW
{
    /// <summary>
    /// This class tracks and reflect changes to a string.
    /// </summary>
    [DebuggerDisplay("{Text}")]
    public class StringReplacement
    {
        #region Private Members

        private readonly List<TextRun> m_runs = new List<TextRun>();

        #endregion

        #region Ctors

        /// <summary>
        /// Initializes a new instance of the <see cref="StringReplacement"/> class.
        /// </summary>
        /// <param name="text">The original text.</param>
        public StringReplacement(string text)
        {
            OriginalText = text;
            m_runs.Add(new TextRun(text));
        }

        #endregion

        #region Public Properties

        public string Text
        {
            get 
            {
                return m_runs.Text();
            }
        }

        public string OriginalText
        {
            get;
            private set;
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Replaces a substring of this instance with the <paramref name="replacement"/>
        /// </summary>
        /// <param name="index">The start index of substring.</param>
        /// <param name="length">The length of the substring.</param>
        /// <param name="replacement">The replacement string.</param>
        public void Replace(int index, int length, string replacement)
        {
            var lengthSoFar = 0;
            int targetTextRunIndex = -1;
            TextRun targetTextRun = null;
            for (int i = 0; i < m_runs.Count; i++)
            {
                var textRun = m_runs[i];
                if (index < lengthSoFar + textRun.OriginalLength)
                {
                    targetTextRun = textRun;
                    targetTextRunIndex = i;
                    break;
                }
                lengthSoFar += textRun.OriginalLength;
            }

            if (targetTextRun == null)
                throw new ArgumentException();

            var newRuns = targetTextRun.Replace(index - lengthSoFar, length, replacement);
            m_runs.RemoveAt(targetTextRunIndex);
            m_runs.InsertRange(targetTextRunIndex, newRuns);
        }

        /// <summary>
        /// Replaces all the occurences of <paramref name="oldValue"/> with the <paramref name="newValue"/>
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
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

        #endregion
    }

    /// <summary>
    /// This class helps tracking string replacements and length's of the original strings.
    /// </summary>
    [DebuggerDisplay("{Text}")]
    public class TextRun
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextRun"/> class.
        /// </summary>
        /// <param name="text">The original text.</param>
        public TextRun(string text)
        {
            Text = text;
            OriginalLength = Length;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TextRun"/> class.
        /// </summary>
        /// <param name="text">The original text.</param>
        /// <param name="originalLength">Length of the original text.</param>
        public TextRun(string text, int originalLength)
        {
            Text = text;
            OriginalLength = originalLength;
        }

        #region Public Properties

        /// <summary>
        /// Gets the current value of this instance
        /// </summary>
        public string Text
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the length of the original text
        /// </summary>
        /// <value>
        /// The length of the original text.
        /// </value>
        public int OriginalLength
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the length of the current value of this instance
        /// </summary>
        public int Length
        {
            get
            {
                return Text.Length;
            }
        }

        #endregion

        /// <summary>
        /// Replaces a substring of this instance with the <paramref name="replacement"/>
        /// </summary>
        /// <param name="index">The start index of substring.</param>
        /// <param name="length">The length of the substring.</param>
        /// <param name="replacement">The replacement string.</param>
        /// <returns></returns>
        public IEnumerable<TextRun> Replace(int index, int length, string replacement)
        {
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

        /// <summary>
        /// Replaces all the occurences of <paramref name="oldValue"/> with the <paramref name="newValue"/>
        /// </summary>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of <paramref name="oldValue"/>.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Text;
        }
    }

    public static class Extensions
    {
        /// <summary>
        /// Appends all the Text's properties of the given <paramref name="list"/> and returns it.
        /// </summary>
        /// <param name="list">The list of <see cref="TextRun"/> instances.</param>
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