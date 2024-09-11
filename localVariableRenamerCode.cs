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
//         // Load the content of the C# class from a file (replace with your file path)
//         var filePath = @"/Users/ayush/Downloads/Crackle/Development/My C#/Practice2.1/myCalculator.cs";
//         var code = File.ReadAllText(filePath);

//         // Parse the code into a syntax tree
//         var syntaxTree = CSharpSyntaxTree.ParseText(code);
//         var root = syntaxTree.GetRoot();

//         // Create a syntax rewriter to rename local variables
//         var rewriter = new LocalVariableRenamer();

//         // Rewrite the syntax tree with renamed variables
//         var newRoot = rewriter.Visit(root);

//         // Output the transformed code
//         Console.WriteLine(newRoot.ToFullString());
//     }
// }
// class LocalVariableRenamer : CSharpSyntaxRewriter
//     {
//         // Dictionary to store old names and their new random names within the scope of each method
//         private Dictionary<string, string> _variableRenameMap = new Dictionary<string, string>();
//         private static readonly Random random = new Random();

//         public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
//         {
//             // Clear the rename map for each method to avoid cross-method renaming
//             _variableRenameMap.Clear();

//             // Visit all local variables in the method body
//             var newMethod = (MethodDeclarationSyntax)base.VisitMethodDeclaration(node);

//             return newMethod;
//         }

//         public override SyntaxNode VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
//         {
//             // Generate a random three-letter name for each local variable
//             var newVariables = node.Declaration.Variables.Select(variable =>
//             {
//                 var oldName = variable.Identifier.Text;
//                 var newName = GenerateRandomThreeLetterName();

//                 // Map the old variable name to the new name
//                 _variableRenameMap[oldName] = newName;

//                 // Rename the variable identifier
//                 return variable.WithIdentifier(SyntaxFactory.Identifier(newName));
//             });

//             // Replace the old declaration with the new one (containing renamed variables)
//             var newDeclaration = node.Declaration.WithVariables(SyntaxFactory.SeparatedList(newVariables));
//             return node.WithDeclaration(newDeclaration);
//         }

//         public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
//         {
//             // Check if the identifier corresponds to a local variable and rename it
//             var identifier = node.Identifier.Text;

//             if (_variableRenameMap.ContainsKey(identifier))
//             {
//                 var newName = _variableRenameMap[identifier];
//                 return SyntaxFactory.IdentifierName(newName).WithTriviaFrom(node);
//             }

//             return base.VisitIdentifierName(node);
//         }

//         // Helper method to generate a random three-letter name
//         private string GenerateRandomThreeLetterName()
//         {
//             const string chars = "abcdefghijklmnopqrstuvwxyz";
//             return new string(Enumerable.Repeat(chars, 3)
//                                         .Select(s => s[random.Next(s.Length)]).ToArray());
//         }
//     }
