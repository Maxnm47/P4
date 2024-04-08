using Antlr4.Runtime.Misc;
using UCM.types;

namespace UCM;

public class CustomUCMVisitor : UCMBaseVisitor<object>
{
    private readonly Types types = new Types();

    public override object VisitStart([NotNull] UCMParser.StartContext context)
    {
        Console.WriteLine("Visiting Start");
        return base.VisitStart(context);
    }

    public override object VisitField([NotNull] UCMParser.FieldContext context)
    {
        TypeEnum typeAnotation = types.GetTypeEnum(context.type());
        TypeEnum valueType = types.GetTypeEnum(context.expr());
        

        return base.VisitField(context);
    }

    

    
}
