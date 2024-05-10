using Antlr4.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UCM.ErrorListener;
using UCM.Exceptions;
using UCM;

[TestClass]
public class ParserTests
{
    [TestMethod]
    public void FieldTest()
    {
        string input1 = "int a = 10;";
        string input2 = "float a = 10.0;";
        string input3 = "bool a = true;";
        string input4 = "string a = \"hello\";";

        AssertTrue(input1);
        AssertTrue(input2);
        AssertTrue(input3);
        AssertTrue(input4);

        string input5 = "float a  10;";
        string input6 = "bool a = 10";
        string input7 = "string a  10;\"";

        AssertFalse(input5);
        AssertFalse(input6);
        AssertFalse(input7);

        string input10 = "object a = {int a = 10; float b = 10.0;bool c = true;string d = \"hello\";};";
        AssertTrue(input10);
        string input11 = "object a = {int a\"hello\";};";
        AssertFalse(input11);

        string input12 = """
        int a = 1+1;
        int b = 1-1;
        int c = a + b;
        """;
        AssertTrue(input12);
    }

    [TestMethod]
    public void TemplateTest()
    {
        string input1 = """ 
                template A{
                    int a;
                }

                A aA = {
                    int a = 10; 
                };
            """;
        AssertTrue(input1);
        string input2 = """ 
                template B{
                    int a;
                }

                template A{
                    B b;
                }
            """;
        AssertTrue(input2);
        //no template inside template
        string input3 = """ 
                template A{
                    template B{
                        int a;
                    }
                }
            """;
        AssertFalse(input3);
    }


    [TestMethod]
    public void ObjectFieldAcessTest()
    {
        string input1 = "object a ={object b ={int c =10;};};intd=a.b.c;";
        AssertTrue(input1);
    }

    [TestMethod]
    public void AdaptingTest()
    {
        string input1 = """
        template A{
            int a;
        }

        A a = {
            int a = 10;
        };

        b = a {
            int a = 10;
            int b = 10;
        };
        """;
        AssertTrue(input1);
    }

    [TestMethod]
    public void DynamicKeyTest()
    {
        string input1 = """
            hidden string fieldName = "fieldName";

            template A{
                string a;
            }

            A a = {
                (fieldName) = "This is a dynamic string name";
            };
        """;
        AssertTrue(input1);
    }

    [TestMethod]
    public void ObjectArrayTest()
    {
        string input1 = """
            object[] a = 
            [
            {
            int a = 10;
            },
            {
            int a = 11;
            },
            {
            int a = 12;
            }
            ];

            """;
        AssertTrue(input1);
    }

    

    private void AssertFalse(string program)
    {
        UCMLexer lexer = new UCMLexer(CharStreams.fromString(program));
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        UCMParser parser = new UCMParser(tokenStream)!;
        parser.ErrorHandler = new ErrorStrategy();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());
        var _ = Assert.ThrowsException<ParserException>(() => parser.root().ToStringTree());
    }
    private void AssertTrue(string program)
    {
        UCMLexer lexer = new UCMLexer(CharStreams.fromString(program));
        lexer.RemoveErrorListeners();
        lexer.AddErrorListener(new ErrorListener());
        CommonTokenStream tokenStream = new CommonTokenStream(lexer);
        UCMParser parser = new UCMParser(tokenStream)!;
        parser.ErrorHandler = new ErrorStrategy();
        parser.RemoveErrorListeners();
        parser.AddErrorListener(new ErrorListener());
        Exception caughtException = null!;
        string errormessage = "";
        try
        {
            var _ = Assert.ThrowsException<ParserException>(() => parser.root());
            errormessage = _.Message;
        }
        catch (Exception e)
        {
            caughtException = e;
        }

        Assert.IsNotNull(caughtException, errormessage);
    }
}