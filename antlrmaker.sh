#!/bin/sh

# Run the antlr command
java -jar /usr/local/lib/antlr-4.13.1-complete.jar -Dlanguage=CSharp -no-listener -visitor UCM.g4

# Move the generated files to the UCM directory
mv *.cs UCM/
mv UCM.* UCM/
mv *.interp UCM/
mv *.tokens UCM/
