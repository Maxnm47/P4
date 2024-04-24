using UCM.ast;
using UCM.typechecker;

namespace UCM.tables;

public class VTableEntry{
    public ExpressionNode expr;
    public TypeEnum type;

    public VTableEntry(TypeEnum type, ExpressionNode expressionNode){
        this.expr = expressionNode;
        this.type = type;
    }
}
public class VTable
{   
    public Dictionary<string, VTableEntry> Variables { get; } = new Dictionary<string, VTableEntry>();
    public void AddVariable(string name, VTableEntry value)
    {
        Variables[name] = value;
    }
    public bool Contains(string key)
    {
        return Variables.ContainsKey(key);
    }
    public VTableEntry Find(string key)
    {
        return Variables[key];
    }
}

