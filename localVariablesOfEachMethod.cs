// // using System;
// // namespace practice
// // {
// //     class Program{
// //         static void Main(string[] args){
// //             //myCalculatorTester.test();
// //             myCalculator2Tester.test();
// //             //Generics.test();
// //             //Multithreading.test();
// //         }
// //     }
// // }
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.CSharp;
// using Microsoft.CodeAnalysis.CSharp.Syntax;
// using practice;
// using System;
// using System.IO;
// using System.Linq;

// class Program
// {
//     private String abc;
//     String def;
//     internal String ghi;
//     public string kjl;


//     static void Main(string[] args)
//     {
//         // Load the content of the C# class from a file (you can replace the file path or directly use a string)
//         var filePath = @"/Users/ayush/Downloads/Crackle/Development/My C#/Practice2.1/myCalculator.cs";
//         var code = File.ReadAllText(filePath);
        
//         // Parse the code into a syntax tree
//         var syntaxTree = CSharpSyntaxTree.ParseText(code);
//         var root = syntaxTree.GetRoot();
        
//         // Traverse the syntax tree to find all method declarations
//         var methodDeclarations = root.DescendantNodes()
//                                      .OfType<MethodDeclarationSyntax>();

//         // Loop through each method
//         foreach (var method in methodDeclarations)
//         {
//             Console.WriteLine($"Method: {method.Identifier.Text}");

//             // Find all local variable declarations within the method
//             var localVariables = method.Body.DescendantNodes()
//                 .OfType<LocalDeclarationStatementSyntax>();

//             // Print the local variables that are declared in this method
//             foreach (var localVar in localVariables)
//             {
//                 // Local variables can be multiple, e.g., int a = 1, b = 2;
//                 foreach (var variable in localVar.Declaration.Variables)
//                 {
//                     Console.WriteLine($"Local variable: {variable.Identifier.Text}, Type: {localVar.Declaration.Type}");
//                 }
//             }
//             Console.WriteLine();
//         }
//     }
// }
