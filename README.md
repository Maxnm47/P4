# Unified Computational Modeling Language
Unified Computational Modeling Language (UCM) is a language designed to produce serialized languages such as JSON or YAML, ensuring type safety of the fields.
## Prerequisites

- `dotnet` v8+
- `antlr4`
The two main projects are found in the folders UCM and UCM.Tests.

`UCM`: The compiler

`UCM.tests`: The testing suite for the compiler

On **Unix-like systems**, the parser files are **automatically generated** before building as part of the build process.

On **Windows**, the parser code must be **generated manually**:

```sh
cd P4 
Run the antlrmaker.sh
or
run these commands:
antlr4 -Dlanguage=CSharp -no-listener -visitor UCM.g4

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
mv -f UCMBaseVisitor.cs UCM/build
mv -f UCMVisitor.cs UCM/build
```

## Dotnet commands

To run tests:

```sh
cd UCM.Tests
dotnet test
```

To run the project:

```sh
dotnet run path/to/yourfile.ucm 
```

To output the file to JSON
```sh
dotnet run path/to/yourfile.ucm -json
```

To output the file to YAML
```sh
dotnet run path/to/yourfile.ucm -yaml
```
