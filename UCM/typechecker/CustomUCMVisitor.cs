using Antlr4.Runtime.Misc;
using UCM.typechecker;

namespace UCM;

public class CustomUCMVisitor : UCMBaseVisitor<object>
{

    public override object VisitStart([NotNull] UCMParser.StartContext context)
    {
        Console.WriteLine("Visiting Start");
        return base.VisitStart(context);
    }

    public override object VisitField([NotNull] UCMParser.FieldContext context)
    {
        TypeEnum typeAnotation = (TypeEnum) VisitType(context.type());
        TypeEnum valueType = (TypeEnum) VisitExpr(context.expr());
        
        if (typeAnotation != valueType)
        {
            throw new Exception($"Type mismatch: {typeAnotation} != {valueType}");
        }

        return typeAnotation;
    }



    public override object VisitInt([NotNull] UCMParser.IntContext context)
    {
        return TypeEnum.INT;
    }

    public override object VisitFloat([NotNull] UCMParser.FloatContext context)
    {
        return TypeEnum.FLOAT;
    }

    public override object VisitType([NotNull] UCMParser.TypeContext context)
     {
        
        string type = context.GetText();
        Console.WriteLine(type);
        if (type == "int")
        {
            return TypeEnum.INT;
        }
        else if (type == "float")
        {
            return TypeEnum.FLOAT;
        }
        else if (type == "string")
        {
            return TypeEnum.STRING;
        }
        else if (type == "bool")
        {
            return TypeEnum.BOOL;
        }
        else if (type == "void")
        {
            return TypeEnum.VOID;
        }
        else if (type == "object")
        {
            return TypeEnum.OBJECT;
        }

        // else if (type == "[]") TODO: IMPLEMENT
        // {
        //     return TypeEnum.ARRAY;
        // }

        // else if (type == "template"){ TODO: IMPLEMENT
        //     return TypeEnum.TEMPLATE;
        // }

        else
        {
            throw new Exception("Unknown type");
        }   
    }

}
