﻿using System;
using System.Collections.Generic;

namespace fifi.Core
{
    public class IdentifiableDataPoint : DataPoint
    {
        public IdentifiableDataPoint(int id, int dimensions) : base(dimensions)
        {
            Id = id;
            Attributes = new List<string>();
            OriginalValues = new List<string>();
        }

        public int Id { get; private set; }
        public List<string> Attributes { get; private set; }
        public List<string> OriginalValues { get; private set; }
        public double this[string attributeName]
        {
            get
            {
                int index = Attributes.IndexOf(attributeName);
                if (index < 0)
                {
                    string msg = string.Format("Attribute with the name '{0}' does not exists.", attributeName);
                    throw new ArgumentException(msg, "attributeName");
                }

                return this[index];
            }
        }

        public void AddAttribute(string attribute, double value, string originalValue = "")
        {
            if (Dimensions <= Attributes.Count)
                throw new NumberOfDimensionsExceededException("Cannot add more attributes since the original allowed dimension size has been reached.");

            this[Attributes.Count] = value;
            Attributes.Add(attribute);
            OriginalValues.Add(originalValue);
        }
    }
}
