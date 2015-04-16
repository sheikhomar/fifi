using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifi.Core
{
    class Jaccard
    {
        int posistive_both = 0, positive_negative = 0, negative_positive = 0, negative_both;
        public Jaccard(int []var_a, int []var_b)
        {
            for (int i = 0; i < var_a.Length; i = i++)
            {
                if (var_a[i] == 1 && var_b[i] == 1)
                    posistive_both++;
                else if (var_a[i] == 1 && var_b[i] == 0)
                    positive_negative++;
                else if (var_a[i] == 0 && var_b[i] == 1)
                    negative_positive++;
                else if (var_a[i] == 0 && var_b[i] == 0)
                    negative_both++;
                else
                    Console.WriteLine("Ups, can not compare, ERROR, ERROR");
            }
        }

        public decimal Distance {
            get
            {
                return (positive_negative + negative_positive) / (posistive_both + positive_negative + negative_positive);
            }
        }
    }
}
