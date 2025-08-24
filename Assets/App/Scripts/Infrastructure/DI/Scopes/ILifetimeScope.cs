using System;
using MyContainer.Container;

namespace Scopes
{
  public interface ILifetimeScope : IDisposable
  {
    public IRegistrationContainer RegistrationContainer { get; }
  }
}