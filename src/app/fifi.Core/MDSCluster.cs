﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using CDataPoint = System.Windows.Forms.DataVisualization.Charting.DataPoint;

namespace fifi.Core
{
    public class MDSCluster
    {
        public MDSCluster()
        {
            MDSDataPoints = new List<CDataPoint>();
        }

        public List<CDataPoint> MDSDataPoints;

        // MDS holdet skal indlæse alle data for et cluster i ovenstående liste.
        // Det de til sidst skal returnere er en liste af MDSClusters -- altså denne klasse.
        // I kan bruge constructoren eller lave en smart metode til at proppe jeres data ind i listen.
        // For hvert datapoint i listen skal i tilgå member'et .SetValueXY()

    }
}