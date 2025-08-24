using MyContainer.Container;
using Scopes;
using UnityEngine;

public abstract class LifetimeScope : MonoBehaviour, IInstaller, ILifetimeScope
{
    private IRegistrationContainer _registrationContainer;
    IRegistrationContainer ILifetimeScope.RegistrationContainer => _registrationContainer;
    
    private bool _isInitialized = false;
    
    private void Awake()
    {
        TryInitialize();
    }
    
    public void TryInitialize()
    {
        if (_isInitialized)
            return;
        
        BeforeInitialize(_registrationContainer);

        KernelMyContainer.Instance.SetupNewScope(this);
        _registrationContainer = new RegistrationContainer(KernelMyContainer.Instance.GetRegistrationsData(this));
        Configure(_registrationContainer);
        _registrationContainer.BuildContainer();

        _isInitialized = true;
        
        AfterInitialize(_registrationContainer);
    }
    
    protected virtual void AfterInitialize(IRegistrationContainer container) { }
    protected virtual void BeforeInitialize(IRegistrationContainer container) { }
    
    public abstract void Configure(IRegistrationContainer container);

    public void Dispose()
    {
        
    }
}
