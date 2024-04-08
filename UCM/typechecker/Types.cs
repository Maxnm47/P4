using System.Dynamic;

namespace UCM.types;

    public enum TypeEnum
    {
        INT,
        FLOAT,
        STRING,
        BOOL,
        VOID,
        OBJECT,
        ARRAY,
        // TEMPLATE, Maybe add in later
    }

class Types
{
    public TypeEnum GetTypeEnum(UCMParser.TypeContext context)
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

    public TypeEnum GetTypeEnum(UCMParser.ExprContext context)
    {
        Console.WriteLine(context.value());

        return TypeEnum.INT;
    }
}
