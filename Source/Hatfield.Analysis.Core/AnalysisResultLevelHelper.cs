using System.Collections.Generic;
using System.Linq;

namespace Hatfield.Analysis.Core
{
    public class AnalysisResultLevelHelper
    {
        private static Dictionary<AnalysisResultLevel, AnalysisResultLevel[]> levelDictionary = new Dictionary<AnalysisResultLevel, AnalysisResultLevel[]>{
            {
                AnalysisResultLevel.DEBUG, new AnalysisResultLevel[] {
                                                                    AnalysisResultLevel.INFO,
                                                                    AnalysisResultLevel.WARN,
                                                                    AnalysisResultLevel.ERROR,
                                                                    AnalysisResultLevel.FATAL
                                                                    }
            },
            {
                AnalysisResultLevel.INFO, new AnalysisResultLevel[] {
                                                                    AnalysisResultLevel.WARN,
                                                                    AnalysisResultLevel.ERROR,
                                                                    AnalysisResultLevel.FATAL
                                                                    }
            },
            {
                AnalysisResultLevel.WARN, new AnalysisResultLevel[] {
                                                                    AnalysisResultLevel.ERROR,
                                                                    AnalysisResultLevel.FATAL
                                                                    }
            },
            {
                AnalysisResultLevel.ERROR, new AnalysisResultLevel[] {
                                                                    AnalysisResultLevel.FATAL
                                                                    }
            },
            {
                AnalysisResultLevel.FATAL, new AnalysisResultLevel[] {}
            },
        };

        private static bool LevelIsHigherThanThreshold(AnalysisResultLevel threshold, AnalysisResultLevel actualLevel)
        {
            if (levelDictionary.ContainsKey(threshold))
            {
                return levelDictionary[threshold].Contains(actualLevel);
            }
            else
            {
                throw new KeyNotFoundException(threshold.ToString() + " is not a supported Analysis result level");
            }
        }

        public static bool ShouldSendNotification(AnalysisResultLevel threshold, AnalysisResultLevel actualLevel)
        {
            return (threshold == actualLevel) || LevelIsHigherThanThreshold(threshold, actualLevel);
        }

        public static bool ShouldContinue(AnalysisResultLevel threshold, AnalysisResultLevel actualLevel)
        {
            return (threshold == actualLevel) || !LevelIsHigherThanThreshold(threshold, actualLevel);
        }
    }
}