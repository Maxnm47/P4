using UCM.tables;

namespace UCM.scope;
public class Scope
{
    public VTable vTable = new VTable();
    public FTable fTable = new FTable();

    public void AddVariable(string name, VTableEntry value)
    {
        if(vTable.Contains(name))
        {
            throw new Exception($"Variable {name} already exists in scope");
        }
        vTable.AddVariable(name, value); 
    }

    public bool VTableContains(string key)
    {
        return vTable.Contains(key);
    }

    public VTableEntry Find(string key)
    {
        return vTable.Find(key);
    }

    public void AddFunction(string name, FTableEntry value)
    {
        if(fTable.Contains(name))
        {
            throw new Exception($"Function {name} already exists in scope");
        }
        fTable.AddFunction(name, new FTableEntry[] { value }); 
    }

    public bool FTableContains(string key)
    {
        return fTable.Contains(key);
    }

    public FTableEntry[] FindFunction(string key)
    {
        return fTable.Find(key);
    }


    public void CopyFrom(Scope other)
    {
        foreach (var variable in other.vTable.Variables)
        {
            AddVariable(variable.Key, variable.Value);
        }
        foreach (var function in other.fTable.Functions)
        {
            foreach (var entry in function.Value)
            {
                AddFunction(function.Key, entry);
            }
        }
    }
}





////////////////////////// scope stack //////////////////////////
///    private Stack<Scope> ScopeStack { get; } = new Stack<Scope>();
// private void EnterScope(Scope scope) 
// {
//     if (ScopeStack.Count() != 0) 
//     {
//         scope.CopyFrom(GetCurrentScope()); 
//     }
//     ScopeStack.Push(scope);
// }

// private void ExitScope()
// {
//     _ = ScopeStack.Pop();
// }
// private Scope GetCurrentScope()
// {
//     return ScopeStack.Peek();
// }