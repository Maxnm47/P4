using Antlr4.Runtime;
using UCM.Exceptions;
using System;

namespace UCM.ErrorListeners
{
    public class ErrorStrategy : DefaultErrorStrategy
    {
        public override void ReportError(Parser recognizer, RecognitionException e)
        {
            NotifyErrorListeners(recognizer, "error", e);
            Console.WriteLine("Parser error: " + e.Message);
        }
    }

    public class ErrorListener : BaseErrorListener, IAntlrErrorListener<int>
    {
        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Console.WriteLine("Syntax error: " + msg + " in line " + line + " position " + charPositionInLine);
        }
        public void SyntaxError(TextWriter output, IRecognizer recognizer, int offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            Console.WriteLine("Syntax error: " + msg + " in line " + line + " position " + charPositionInLine);
        }
    }
}
