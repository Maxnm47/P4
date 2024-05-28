using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCM.typeEnum;

namespace UCM.astVisitor
{
    public struct SymbolInfo
    {
        string referenceId;
        List<String> scope;
    }
}