!/bin/sh

# Run the antlr command
java -jar /usr/local/lib/antlr-4.13.1-complete.jar -Dlanguage=CSharp -no-listener -visitor UCM.g4

mkdir UCM/build

# Move the generated .cs files to the UCM directory
mv UCMParser.cs UCM/build
mv UCMLexer.cs UCM/build


# Move the generated .interp and .tokens files to the UCM directory, excluding the .g4 file
mv UCM*.interp UCM/build
mv UCM*.tokens UCM/build

mv UCMBaseVisitor.cs UCM/typechecker
mv UCMVisitor.cs UCM/typechecker
