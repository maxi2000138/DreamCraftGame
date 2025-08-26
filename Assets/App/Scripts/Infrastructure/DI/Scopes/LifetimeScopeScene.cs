using App.Scripts.Infrastructure.DI.Kernel;
using App.Scripts.Infrastructure.DI.Registration.Container;
using UnityEngine;
namespace App.Scripts.Infrastructure.DI.Scopes
{
    [DefaultExecutionOrder(-5000)]
    public abstract class LifetimeScopeScene : LifetimeScope
    {
        protected override void BeforeInitialize(IRegistrationContainer container)
        {
            base.BeforeInitialize(container);
            KernelMyContainer.Instance.TryInitProjectScope();
        }
    }
}