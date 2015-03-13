using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Analysis.Core
{
    public interface IAnalysisChainExecutor
    {
        IEnumerable<IAnalysisResult> Execute(IAnalysisChain analysisChain);
    }
}
