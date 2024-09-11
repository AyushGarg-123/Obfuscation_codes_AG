
// using System;
// using System.Linq;
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.CSharp;
// using Microsoft.CodeAnalysis.CSharp.Syntax;

// namespace RoslynRenameFieldExample
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Path to your C# file
//             var filePath = @"/Users/ayush/Downloads/Crackle/Development/My C#/Test/field.cs";

//             // Read the source code
//             var code = System.IO.File.ReadAllText(filePath);

//             // Parse the syntax tree from the code
//             var syntaxTree = CSharpSyntaxTree.ParseText(code);
//             var root = syntaxTree.GetRoot();

//             // Define old and new field names
//             var oldFieldName = "engineType";
//             var newFieldName = "engineModel";

//             // Find all field declarations and member access expressions with the old field name
//             var newRoot = root.ReplaceNodes(
//                 root.DescendantNodes()
//                     .Where(n => 
//                         (n is VariableDeclaratorSyntax variable && variable.Identifier.Text == oldFieldName) || 
//                         (n is MemberAccessExpressionSyntax memberAccess && memberAccess.Name.Identifier.Text == oldFieldName) || 
//                         (n is IdentifierNameSyntax identifier && identifier.Identifier.Text == oldFieldName && 
//                         !(identifier.Parent is MemberAccessExpressionSyntax) // Ignore if part of an assignment 
//                         )),
//                 (originalNode, rewrittenNode) =>
//                 {
//                     // Handle field declaration renaming
//                     if (originalNode is VariableDeclaratorSyntax variableDeclarator &&
//                         variableDeclarator.Identifier.Text == oldFieldName)
//                     {
//                         return variableDeclarator.WithIdentifier(SyntaxFactory.Identifier(newFieldName));
//                     }

//                     // Handle member access expressions (e.g. carEngine.engineType)
//                     if (originalNode is MemberAccessExpressionSyntax memberAccess &&
//                         memberAccess.Name.Identifier.Text == oldFieldName)
//                     {
//                         return memberAccess.WithName(SyntaxFactory.IdentifierName(newFieldName));
//                     }

//                     // Handle identifier names (e.g. engineType accessed directly)
//                     if (originalNode is IdentifierNameSyntax identifierName &&
//                         identifierName.Identifier.Text == oldFieldName)
//                     {
//                         return SyntaxFactory.IdentifierName(newFieldName);
//                     }

//                     return rewrittenNode;
//                 });

//             // Convert the updated syntax tree back to code
//             var newCode = newRoot.ToFullString();

//             // Write the updated code back to the file
//             System.IO.File.WriteAllText(filePath, newCode);

//             Console.WriteLine($"Field '{oldFieldName}' successfully renamed to '{newFieldName}'.");
//         }
//     }
// }
