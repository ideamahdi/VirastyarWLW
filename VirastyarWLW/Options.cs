using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsLive.Writer.Api;

namespace VirastyarWLW
{
    public class Options
    {
        private readonly IProperties m_options;

        public Options(IProperties options)
        {
            m_options = options;
        }

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
    }
}
