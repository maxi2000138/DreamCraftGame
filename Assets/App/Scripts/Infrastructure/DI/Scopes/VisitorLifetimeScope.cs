namespace App.Scripts.Infrastructure.DI.Scopes
{
    public abstract class VisitorLifetimeScopeBase
    {
        public abstract void Visit(LifetimeScopeProject visitor);
        public abstract void Visit(LifetimeScopeScene visitor);
        public void Visit(LifetimeScope visitor) => Visit((dynamic)visitor);
    }
}