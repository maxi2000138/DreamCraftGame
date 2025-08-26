using System;
using App.Scripts.Infrastructure.DI.Registration.Container;

namespace App.Scripts.Infrastructure.DI.Scopes
{
  public interface ILifetimeScope : IDisposable
  {
    public IRegistrationContainer RegistrationContainer { get; }
  }
}