using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

namespace Hatfield.Analysis.Core.Test
{
    [TestFixture]
    public class AnalysisResultLevelHelperTest
    {
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.FATAL, true)]

        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.DEBUG, false)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.FATAL, true)]

        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.DEBUG, false)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.INFO, false)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.FATAL, true)]

        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.DEBUG, false)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.INFO, false)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.WARN, false)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.FATAL, true)]

        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.DEBUG, false)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.INFO, false)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.WARN, false)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.ERROR, false)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.FATAL, true)]
        public void ShouldSendNotificationTest(
            AnalysisResultLevel threshold, 
            AnalysisResultLevel actualLevel, 
            bool expectShouldSendNotification)
        {
            var actualShouldSendNotification = AnalysisResultLevelHelper.ShouldSendNotification(threshold, actualLevel);
            Assert.AreEqual(expectShouldSendNotification, actualShouldSendNotification);
        }

        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.INFO, false)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.WARN, false)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.ERROR, false)]
        [TestCase(AnalysisResultLevel.DEBUG, AnalysisResultLevel.FATAL, false)]

        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.WARN, false)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.ERROR, false)]
        [TestCase(AnalysisResultLevel.INFO, AnalysisResultLevel.FATAL, false)]

        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.ERROR, false)]
        [TestCase(AnalysisResultLevel.WARN, AnalysisResultLevel.FATAL, false)]

        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.ERROR, AnalysisResultLevel.FATAL, false)]

        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.DEBUG, true)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.INFO, true)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.WARN, true)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.ERROR, true)]
        [TestCase(AnalysisResultLevel.FATAL, AnalysisResultLevel.FATAL, true)]
        public void ShouldContinueTest(
            AnalysisResultLevel threshold,
            AnalysisResultLevel actualLevel,
            bool expectShouldContinue)
        {
            var actualShouldContinue = AnalysisResultLevelHelper.ShouldContinue(threshold, actualLevel);
            Assert.AreEqual(expectShouldContinue, actualShouldContinue);
        }
    }
}
