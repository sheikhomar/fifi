using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.Core;
using System.Drawing;
using fifi.WinUI.Properties;
using fifi.WinUI;

namespace fifi.WinUI
{
    class DataPointInfo
    {
        public DataPointInfo()
        {
            Similarity = Similarity.None;
        }

        public Similarity Similarity { get; set; }

        public string Field { get; set; }

        public string Value { get; set; }

        public double Percent { get; set; }

        public string FormatedPercent { get { return string.Format("{0,2:N0}", Percent); } }

        public Image Color
        {
            get
            {
                switch (Similarity)
                {
                    case Similarity.None:
                        return Resources.CircleBlue;
                    case Similarity.Same:
                        return Resources.CircleGreen;
                    case Similarity.Different:
                        return Resources.CircleRed;
                    case Similarity.Similar:
                        return Resources.CircleYellow;
                    default:
                        throw new ArgumentException(String.Format("Unknown Icon type: {0}", Similarity));
                }
            }
        }
    }
}
