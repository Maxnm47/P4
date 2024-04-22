namespace UCM.tables;

public class VTable
{
     public Dictionary<string, string> Variables { get; } = new Dictionary<string, string>();

     public void AddVariable(string name, string type)
     {
         Variables[name] = type;
     }

     public bool VtableContains(string key)
    {
        return Variables.ContainsKey(key);
    }
    public string VtableFind(string key)
    {
        return Variables[key];
    }
    
}
