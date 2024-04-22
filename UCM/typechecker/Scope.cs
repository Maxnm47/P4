namespace UCM.scope;

using UCM.tabels;
using UCM.tables;

public class Scope
{

    public VTable vTable = new VTable();
    public FTable fTable = new FTable();

    public bool VtableContains(string key)
    {
        return vTable.VtableContains(key);
    }

    public string VtableFind(string key)
    {
        return vTable.VtableFind(key);
    }

    public void AddVariable(string name, string type)
    {
        vTable.AddVariable(name, type);
    }

    public bool FtableContains(string key)
    {
        return fTable.FtableContains(key);
    }

    public string[][] FtableFind(string key)
    {
        return fTable.FtableFind(key);
    }

    public void AddFunction(string name, string[][] value)
    {
        fTable.AddFunction(name, value);
    }
//helper functions for scope stack to be put in visitor        
    // private void EnterScope(Scope scope) 
    // {
    //     if (ScopeStack.Count() != 0)
    //     {
    //         foreach (var variable in GetCurrentScope().vTable.Variables) 
    //         {
    //             scope.AddVariable(variable.Key, variable.Value);
    //         }
    //         foreach (var function in GetCurrentScope().fTable.Functions) 
    //         {
    //             scope.AddFunction(function.Key, function.Value);
    //         }
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
}



