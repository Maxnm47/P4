# Unified Computational Modeling Language
Unified Computational Modeling Language (UCM) is a language designed to produce serialized languages such as JSON or YAML, ensuring type safety of the fields.
## Prerequisites

- `dotnet` v8+
- `antlr4`

On **Unix-like systems**, the parser files are **automatically generated** before building as part of the build process.

On **Windows**, the parser code must be **generated manually**:

```sh
cd P4 
Run the antlrmaker.sh
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
