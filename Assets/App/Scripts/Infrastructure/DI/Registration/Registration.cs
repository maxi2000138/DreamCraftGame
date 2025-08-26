using System.Collections.Generic;
using System.Linq;
using App.Scripts.Infrastructure.DI.Instantiator;

namespace App.Scripts.Infrastructure.DI.Registration
{
    public class Registration
    {
        private readonly List<object> _implementations = new();
        private readonly List<RegistrationBuilder> _registrationBuilders = new();

        public void AddBuilder(RegistrationBuilder builder)
        {
            _registrationBuilders.Add(builder);
        }
    
        public T Resolve<T>(ContainerInstantiator instantiator) where T : class
        {
            TryBuildRegistration(instantiator);

            return _implementations.FirstOrDefault() as T;
        }

        public IEnumerable<T> ResolveMany<T>(ContainerInstantiator instantiator) where T : class
        {
            TryBuildRegistration(instantiator);
        
            foreach (object implementation in _implementations)
            {
                if (implementation is T typedImplementation)
                {
                    yield return typedImplementation;
                }
            }   
        }

        public object Resolve(ContainerInstantiator instantiator)
        {
            TryBuildRegistration(instantiator);

            return _implementations.FirstOrDefault();
        }

        public IEnumerable<object> ResolveMany(ContainerInstantiator instantiator)
        {
            TryBuildRegistration(instantiator);

            return _implementations;
        }
    
        private void TryBuildRegistration(ContainerInstantiator instantiator)
        {
            if (_registrationBuilders.Count <= 0) 
                return;
        
            foreach (var registrationBuilder in _registrationBuilders)
            {
                if (registrationBuilder.Instance != null)
                    _implementations.Add(registrationBuilder.Instance);
                else
                    _implementations.Add(instantiator.CreateInstance(registrationBuilder.ImplementationType, registrationBuilder.Arguments));
            }
        
            _registrationBuilders.Clear();
        }
    }
}