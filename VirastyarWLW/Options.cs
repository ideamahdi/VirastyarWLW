using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsLive.Writer.Api;

namespace VirastyarWLW
{
    /// <summary>
    /// A handy wrapper over an instance of <see cref="IProperties"/> class.
    /// </summary>
    public class Options
    {
        #region Private Fields

        private readonly IProperties m_options;

        #endregion

        #region Ctors

        public Options(IProperties options)
        {
            m_options = options;
        }

        #endregion

        #region Properties

        public bool DoSpellCheck
        {
            get
            {
                return m_options.GetBoolean("DoSpellCheck", true);
            }
            set
            {
                m_options.SetBoolean("DoSpellCheck", value);
            }
        }

        public bool DoPreSpellCheck
        {
            get
            {
                return m_options.GetBoolean("DoPreSpellCheck", true);
            }
            set
            {
                m_options.SetBoolean("DoPreSpellCheck", value);
            }
        }

        public bool DoCharRefinement
        {
            get
            {
                return m_options.GetBoolean("DoCharRefinement", true);
            }
            set
            {
                m_options.SetBoolean("DoCharRefinement", value);
            }
        }

        public bool ConvertLongHeYeToShort
        {
            get
            {
                return m_options.GetBoolean("ConvertLongHeYeToShort", true);
            }
            set
            {
                m_options.SetBoolean("ConvertLongHeYeToShort", value);
            }
        }

        public bool ConvertShortHeYeToLong
        {
            get
            {
                return m_options.GetBoolean("ConvertShortHeYeToLong", false);
            }
            set
            {
                m_options.SetBoolean("ConvertShortHeYeToLong", value);
            }
        }

        #endregion
    }
}
