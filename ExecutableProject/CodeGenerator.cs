using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace ExecutableProject
{
    public static class CodeGenerator
    {
        public static MonogameLib.Classes.ConstructorGame CompileFromFile(string pathGameCode)
        {
            //Parse code from pathGameCode
            string codeToCompile = GameLangParser.GameLangParser.ParseGameProgram(pathGameCode);
            try
            {
                var pathToGenericFile = "E:/Docs/УНИК/Диплом/MonoGameDSL/ExecutableProject/Generic.txt";
                using (StreamWriter sw = new StreamWriter(pathToGenericFile, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(codeToCompile);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            codeToCompile = codeToCompile.Replace("\r", "");
            
            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(codeToCompile);
            string assemblyName = Path.GetRandomFileName();
            var references = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(a => !a.IsDynamic)
                .Select(a => a.Location)
                .Where(s => !string.IsNullOrEmpty(s))
                .Where(s => !s.Contains("xunit"))
                .Select(s => MetadataReference.CreateFromFile(s))
                .ToList()
                ;

            CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
                syntaxTrees: new[] { syntaxTree },
                references: references,
                options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            using (var ms = new MemoryStream())
            {
                EmitResult emitResult = compilation.Emit(ms);
                if (!emitResult.Success)
                {
                    // some errors
                    foreach (var error in emitResult.Diagnostics)
                    {
                        throw new DSL_Error(error.ToString());
                    }
                    
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                    var type = assembly.GetType("TestProject.GameTest");
                    var instance = assembly.CreateInstance("TestProject.GameTest");

                    return (MonogameLib.Classes.ConstructorGame)instance;
                }
            }
            return null;
        }
    }

    class DSL_Error: Exception
    {
        public DSL_Error(string message) : base(message)
        { }
    }
}
