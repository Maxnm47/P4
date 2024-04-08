#!/bin/sh

# Run the antlr command
java -jar /usr/local/lib/antlr-4.13.1-complete.jar -Dlanguage=CSharp -no-listener -visitor UCM.g4

# Move the generated .cs files to the UCM directory
mv *.cs UCM/

# Move the generated .interp and .tokens files to the UCM directory, excluding the .g4 file
mv UCM*.interp UCM/
mv UCM*.tokens UCM/
