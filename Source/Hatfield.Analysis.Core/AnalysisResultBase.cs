using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hatfield.Analysis.Core
{
    public abstract class AnalysisResultBase : IAnalysisResult
    {
        protected bool _isPass;
        protected ISourceLocation _sourceLocation;
        protected AnalysisResultLevel _resultLevel;

        public AnalysisResultBase(bool isPass, ISourceLocation location, AnalysisResultLevel level)
        {
            _isPass = isPass;
            _sourceLocation = location;
            _resultLevel = level;
        }

        public virtual bool IsPass {
            get {
                return _isPass;
            }
        }

        public ISourceLocation SourceLocation
        {
            get {
                return _sourceLocation;
            }
        }

        public AnalysisResultLevel ResultLevel
        {
            get {
                return _resultLevel;
            }
        }
    }
}
