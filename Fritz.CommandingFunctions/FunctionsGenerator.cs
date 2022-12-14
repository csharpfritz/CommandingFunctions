using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Fritz.CommandingFunctions;

public class FunctionsGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        throw new NotImplementedException();
    }

    public void Initialize(GeneratorInitializationContext context)
    {
      context.RegisterForSyntaxNotifications(() => new CommandSyntaxReceiver());
    }

}

public class CommandSyntaxReceiver : ISyntaxReceiver
{
  public List<ClassDeclarationSyntax> CandidateClasses { get; } = new List<ClassDeclarationSyntax>();

  public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
  {
    // any class with at least one attribute is a candidate for property injection
    if (syntaxNode is ClassDeclarationSyntax classDeclarationSyntax &&
        classDeclarationSyntax.AttributeLists.Count > 0)
    {
      CandidateClasses.Add(classDeclarationSyntax);
    }
  }
}
