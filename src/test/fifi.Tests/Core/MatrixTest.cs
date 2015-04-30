using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using fifi.Core;

namespace fifi.Tests.Core
{
    [TestFixture]
    public class MatrixTest
    {


        [SetUp]
        public void SetUp()
        {
            ;
        }


        [Test]
        public void MatrixNoItemsException()
        {
            Assert.Throws<ArgumentException>(() => {new Matrix(0, 0);} );
        }
    }
}