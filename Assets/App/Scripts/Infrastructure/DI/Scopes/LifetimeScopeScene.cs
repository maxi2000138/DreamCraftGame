using MyContainer.Container;
using UnityEngine;

[DefaultExecutionOrder(-5000)]
public abstract class LifetimeScopeScene : LifetimeScope
{
    protected override void BeforeInitialize(IRegistrationContainer container)
    {
        base.BeforeInitialize(container);
        KernelMyContainer.Instance.TryInitProjectScope();
    }
}