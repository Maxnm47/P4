using UCM.TypeEnum;

namespace UCM.tables;

public class VTableEntry
{
    public string id;
    public TypeEnum.TypeEnum type;
    public VTableEntry(string id, TypeEnum.TypeEnum type)
    {
        this.id = id;
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

