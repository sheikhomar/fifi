using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.WinUI
{
    public enum IconType
    {
        Flag, Question, None
    }

    public class LocalOutlierFactorItem
    {
        public IconType Icon { get; set; }
        public int Id { get; set; }
        public double LocalOutlierFactor { get; set; }
        public string FormattetLocalOutlierFactor { get {return LocalOutlierFactor.ToString("2:N5");} }
    }
}
