#!/bin/sh

# Run the antlr command
java -jar /usr/local/lib/antlr-4.13.1-complete.jar -Dlanguage=CSharp -no-listener -visitor UCM.g4

# Create the UCM/build directory if it doesn't exist
mkdir -p UCM/build

# Move the generated .cs files to the UCM directory, overwrite if exist
mv -f UCMParser.cs UCM/build
mv -f UCMLexer.cs UCM/build

# Move the generated .interp and .tokens files to the UCM directory, excluding the .g4 file, overwrite if exist
mv -f UCM*.interp UCM/build
mv -f UCM*.tokens UCM/build

# Ensure the UCM/typechecker directory exists
mkdir -p UCM/typechecker

# Move the generated visitor files to the UCM/typechecker, overwrite if exist
mv -f UCMBaseVisitor.cs UCM/typechecker
mv -f UCMVisitor.cs UCM/typechecker
