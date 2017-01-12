Let's Go! GoLang IDE developed in C#

https://golang.org/

Introduction

This is a side project i've started with couple of friends with the goal to create a Go IDE for Windows and Unix operating systems. Currently it's developed for Windows only, using C# .NET. 

The project is in a very early phase, with almost no GUI work on it and very basic and barebone functionality.

Things currently implemented:

- Creating and Opening Go Projects: 
    Projects created with LetsGo IDE contain a file with .lgp extension. Projects are maintained using Go language standard. LetsGo works       under 1 workspace, storing all the projects in GOROOT/src/github.com/username/projectName. Your main command name will be the name of       your executable after compilation.

- Project exploration
    Project explorer provides break-down tree view of the current project and all of it's commands and packages.

- Code Editor
    Code editor is based on Scintilla API, very early in the development with only few keyword syntax highlighting.

- IDE Console Output
    Crude console output that provides basic information about compilation and runtime errors.

Coding Convention

The whole code is written using Camel Case C# convention. For the clarity of the code it would be good if it's kept that way, but either way works.
