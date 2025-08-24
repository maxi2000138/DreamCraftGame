using Scopes;
public class ProjectScopeRegistry : IScopeRegistry
{
    public ILifetimeScope Scope { get; private set; }

    public void Add(LifetimeScopeProject scope)
    {
        if (Scope != null)
        {
            throw new MyContainerException("Can't add project scope because it already exists in the registry");
        }
        
        Scope = scope;
    }
    public void Dispose()
    {
        if (Scope != null)
        {
            Scope.Dispose();
            Scope = null;
        }
    }
} 
