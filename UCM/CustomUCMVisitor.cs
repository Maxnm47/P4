using Antlr4.Runtime.Misc;

namespace UCM;

public class CustomUCMVisitor : UCMBaseVisitor<object>
{
    public override object VisitStart([NotNull] UCMParser.StartContext context)
    {
        Console.WriteLine("Visiting Start");
        return base.VisitStart(context);
    }
}
