using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Analysis.Core
{
    public abstract class AnalyzerBase : IAnalyzer
    {
        public abstract IAnalysisResult Analyze(IAnalysisParameters analysisParameters);
    }
}
