using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;
using Moq;

using Hatfield.Analysis.Core;

namespace Hatfield.Analysis.Core.Test
{
    [TestFixture]
    public class AnalyzeResultBaseTest
    {
        [Test]
        public void AnalyzeResultTest()
        {
            var mockLocation = new Mock<ISourceLocation>();

            var testResult = new TestAnalyzeResult(true, mockLocation.Object, AnalysisResultLevel.INFO);

            Assert.True(testResult.IsPass);

            Assert.AreEqual(AnalysisResultLevel.INFO, testResult.ResultLevel);
        }
    }

    public class TestAnalyzeResult : AnalysisResultBase
    {
        public TestAnalyzeResult(bool isPass, ISourceLocation location, AnalysisResultLevel resultLevel)
            : base(isPass, location, resultLevel)
        { 
        }
    }
}
