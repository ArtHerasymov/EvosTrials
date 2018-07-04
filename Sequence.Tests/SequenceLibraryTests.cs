using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Sequence.Library;

namespace Sequence.Tests
{
    [TestFixture]
    public class SequenceLibraryTests
    {
        [Test]
        public void GetPartTest_NegativeIndices_ArgumentException()
        {
            Assert.That(() => Library.SequenceLibrary.GetPart(-2, -3),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetPartTest_LowerIsGreaterThanUpper_ArgumentException()
        {
            Assert.That(() => Library.SequenceLibrary.GetPart(3, 1),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetPartTest_LowerEqualsUpper_ArgumentException()
        {
            Assert.That(() => Library.SequenceLibrary.GetPart(1, 1),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void GetPartTest_BigNumbers_OverfloxException()
        {
            Assert.That(() => Library.SequenceLibrary.GetPart(22222, 2222546),
                Throws.TypeOf<OverflowException>());
        }

        [Test]
        public void GetPartTest_LessThanThreeLegalIndices_AssertTrue()
        {
            Assert.IsTrue(Library.SequenceLibrary.GetPart(4, 5).SequenceEqual(new int[2] { 3, 5 }));
        }

        [Test]
        public void GetPartTest_MoreThanThreeLegalIndices_AssertTrue()
        {
            Assert.IsTrue(Library.SequenceLibrary.GetPart(1, 5).SequenceEqual(new int[5] { 1, 1, 1, 3, 5 }));
        }
    }
}
