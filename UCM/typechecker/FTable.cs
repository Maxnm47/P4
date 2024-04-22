namespace UCM.tables;
public class FTable
{
    public Dictionary<string, string[][]> Functions = new Dictionary<string, string[][]>();
    public void AddFunction(string name, string[][] value)
    {
        Functions[name] = value;
    }
    public bool FtableContains(string key)
    {
        return Functions.ContainsKey(key);
    }
    public string[][] FtableFind(string key)
    {
        return Functions[key];
    }

}
