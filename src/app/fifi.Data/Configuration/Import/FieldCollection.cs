﻿using System;
using System.Collections.Generic;
using System.Configuration;

namespace fifi.Data.Configuration.Import
{
    public class FieldCollection : ConfigurationElementCollection, IFieldCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Field();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            Field field = element as Field;
            if (field == null)
                throw new ArgumentException("Parameter 'element' should be of type Field", "element");
            
            return field.Index;
        }

        public IEnumerator<IField> GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
