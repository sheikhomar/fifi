using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.WinUI.Properties;

namespace fifi.WinUI
{
    public enum IconType
    {
        CheckMark, QuestionMark, X, None
    }

    public class LocalOutlierFactorItem
    {
        public LocalOutlierFactorItem(int id, double localOutlierFactor, IconType icon = IconType.None)
        {
            Id = id;
            LocalOutlierFactor = localOutlierFactor;
            Icon = icon;
        }

        public IconType Icon { get; set; }
        public Image Image
        {
            get
            {
                switch (Icon)
                {
                    case IconType.None:
                        return Resources.Arrow;
                    case IconType.CheckMark:
                        return Resources.CheckMark;
                    case IconType.QuestionMark:
                        return Resources.QuestionMark;
                }
                return Resources.X;
            }
        }
        public int Id { get; set; }
        public double LocalOutlierFactor { get; set; }
        public string FormattetLocalOutlierFactor { get { return String.Format("{0,2:N5}", LocalOutlierFactor); } }

        public void UpdateIcon()
        {
            switch (Icon)
            {
                case IconType.None:
                    Icon = IconType.X;
                    break;
                case IconType.X:
                    Icon = IconType.CheckMark;
                    break;
                case IconType.CheckMark:
                    Icon = IconType.QuestionMark;
                    break;
                case IconType.QuestionMark:
                    Icon = IconType.None;
                    break;
            }
        }
    }
}
