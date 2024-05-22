
using UCM.typeEnum;

namespace UCM.tables;

public class FTableEntry
{
    public string paramId;
    public string body; //måske fjern
    public TypeEnum paramtype;
    public TypeEnum returntype;
    public FTableEntry(string paramId, string body, TypeEnum paramtype, TypeEnum returntype)
    {
        this.body = body; //måske fjern
        this.paramId = paramId;
        this.paramtype = paramtype;
        this.returntype = returntype;
    }
}
public class FTable
{
    public Dictionary<string, FTableEntry[]> Functions { get; } = new Dictionary<string, FTableEntry[]>();
    public void AddFunction(string name, FTableEntry[] entry)
    {
        Functions[name] = entry;
    }
    public bool Contains(string key)
    {
        return Functions.ContainsKey(key);
    }
    public FTableEntry[] Find(string key) // Modified return type to FTableEntry[]
    {
        return Functions[key];
    }
}