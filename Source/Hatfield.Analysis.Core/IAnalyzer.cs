using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Analysis.Core
{
    public interface IAnalyzer
    {
        IAnalysisResult Analyze(IAnalysisParameters analysisParameters);
    }
}
