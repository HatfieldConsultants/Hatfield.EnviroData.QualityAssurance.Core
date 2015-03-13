using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Analysis.Core
{
    public interface IAnalysisResult
    {
        bool IsPass { get; }
        ISourceLocation SourceLocation { get; }
        AnalysisResultLevel ResultLevel { get; }   
    }
}
