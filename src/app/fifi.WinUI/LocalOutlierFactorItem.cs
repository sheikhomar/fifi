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
        Mark, Question, None
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
                    case IconType.Mark:
                        return Resources.Mark;
                    case IconType.Question:
                        return Resources.Question;
                }
                return Resources.Empty;
            }
        }
        public int Id { get; set; }
        public double LocalOutlierFactor { get; set; }
        public string FormattetLocalOutlierFactor { get { return LocalOutlierFactor.ToString("2:N5"); } }

        public void UpdateIcon()
        {
            switch (Icon)
            {
                case IconType.None:
                    Icon = IconType.Mark;
                    break;
                case IconType.Mark:
                    Icon = IconType.Question;
                    break;
                case IconType.Question:
                    Icon = IconType.None;
                    break;
            }
        }
    }
}
