// using System;
// using System.Linq;
// using Microsoft.CodeAnalysis;
// using Microsoft.CodeAnalysis.CSharp;
// using Microsoft.CodeAnalysis.CSharp.Syntax;

// namespace RoslynRenameMethodExample
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             // Path to your C# file
//             var filePath = @"/Users/ayush/Downloads/Crackle/Development/My C#/Test/test.cs";

//             // Read the source code
//             var code = System.IO.File.ReadAllText(filePath);

//             // Parse the syntax tree from the code
//             var syntaxTree = CSharpSyntaxTree.ParseText(code);
//             var root = syntaxTree.GetRoot();

//             // Define old and new method names
//             var oldMethodName = "StartCar";
//             var newMethodName = "IgniteCar";

//             // Find all method declarations and invocations with the old method name
//             var newRoot = root.ReplaceNodes(
//                 root.DescendantNodes()
//                     .Where(n => n is MethodDeclarationSyntax || n is InvocationExpressionSyntax)
//                     .Select(n => n),
//                 (originalNode, rewrittenNode) =>
//                 {
//                     // Handle method declaration renaming
//                     if (originalNode is MethodDeclarationSyntax methodDeclaration &&
//                         methodDeclaration.Identifier.Text == oldMethodName)
//                     {
//                         return methodDeclaration.WithIdentifier(SyntaxFactory.Identifier(newMethodName));
//                     }

//                     // Handle method invocations when invoked directly (e.g. StartCar())
//                     if (originalNode is InvocationExpressionSyntax invocation)
//                     {
//                         if (invocation.Expression is IdentifierNameSyntax identifierName &&
//                             identifierName.Identifier.Text == oldMethodName)
//                         {
//                             return invocation.WithExpression(
//                                 SyntaxFactory.IdentifierName(newMethodName)
//                             );
//                         }

//                         // Handle method invocations when invoked on an object (e.g. ownedCar.StartCar())
//                         if (invocation.Expression is MemberAccessExpressionSyntax memberAccess &&
//                             memberAccess.Name.Identifier.Text == oldMethodName)
//                         {
//                             var newMemberAccess = memberAccess.WithName(
//                                 SyntaxFactory.IdentifierName(newMethodName)
//                             );
//                             return invocation.WithExpression(newMemberAccess);
//                         }
//                     }

//                     return rewrittenNode;
//                 });

//             // Convert the updated syntax tree back to code
//             var newCode = newRoot.ToFullString();

//             // Write the updated code back to the file
//             System.IO.File.WriteAllText(filePath, newCode);

//             Console.WriteLine($"Method '{oldMethodName}' successfully renamed to '{newMethodName}'.");
//         }
//     }
// }
