using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sequence.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence.Library.Tests
{
    [TestClass()]
    public class SequenceLibraryTests
    {
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
       "Negative indices are not supported")]
        public void GetPartTest_NegativeIndices_ArgumentException()
        {
            Library.SequenceLibrary.GetPart(-1, -3);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
        "Upper boundary should be greater than lower")]
        public void GetPartTest_LowerIsGreaterThanUpper_ArgumentException()
        {
             Library.SequenceLibrary.GetPart(3, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
        "Lower boundary can't be equal to upper because of the initial conditions")]
        public void GetPartTest_LowerEqualsUpper_ArgumentException()
        {
            Library.SequenceLibrary.GetPart(1, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException),
        "Arithmetic operation resulted in an overflow.")]
        public void GetPartTest_BigNumbers_OverfloxException()
        {
            Library.SequenceLibrary.GetPart(22222, 2222546);
        }

        [TestMethod()]
        public void GetPartTest_LessThanThreeLegalIndices_AssertTrue()
        {
            Assert.IsTrue(Library.SequenceLibrary.GetPart(4, 5).SequenceEqual(new int[2] { 3, 5 }));
        }

        [TestMethod()]
        public void GetPartTest_MoreThanThreeLegalIndices_AssertTrue()
        {
            Assert.IsTrue(Library.SequenceLibrary.GetPart(1, 5).SequenceEqual(new int[5] { 1, 1, 1, 3, 5 }));
        }
    }
}