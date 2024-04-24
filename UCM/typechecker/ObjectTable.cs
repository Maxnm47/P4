using UCM.typechecker;

public class ObjectTable
{
    public Dictionary<string, object> objTable = new Dictionary<string, object>();

    public void AddType(string id, TypeEnum type)
    {
        objTable.Add(id, type);
    }

    public void AddNestedObject(string id, ObjectTable nested)
    {
        objTable.Add(id, nested);
    }

    public object GetType(string id)
    {
        if (objTable.ContainsKey(id))
        {
            return objTable[id];
        }
        throw new Exception("ID not found");
    }
}