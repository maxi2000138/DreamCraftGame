using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;

namespace MyContainer.Container
{
    public class RegistrationContainer : IRegistrationContainer
    {
        public readonly List<RegistrationData> RegistrationsData;
        
        private readonly ContainerInstantiator _containerInstantiator;

        public RegistrationContainer(IEnumerable<RegistrationData> registrationsData)
        {
            _containerInstantiator = new ContainerInstantiator(this);
            RegistrationsData = registrationsData.ToList();
        }

        public void BuildContainer()
        {
            CurrentRegistrationData.Build();
        }

        public T Register<T>(T registrationBuilder) where T : RegistrationBuilder
        {
            CurrentRegistrationData.AddRegistrationBuilder(registrationBuilder);
            return registrationBuilder; 
        }

        public T Resolve<T>() where T : class
        {
            Registration registration = GetRegistration<T>();
            return registration.Resolve<T>(_containerInstantiator);
        }
        
        public T Create<T>() where T : class
        {
            Registration registration = new Registration();
            registration.AddBuilder(new RegistrationBuilder(typeof(T)));
            return registration.Resolve<T>(_containerInstantiator);
        }
        
        private Registration GetRegistration<T>()
        {
            foreach (var registrationData in RegistrationsData)
            {
                if(registrationData.Registrations.ContainsKey(typeof(T)))
                    return registrationData.Registrations[typeof(T)];
            }
            
            throw new MyContainerException($"Registration {typeof(T)} not found in container!");
        }

        public RegistrationData CurrentRegistrationData
        {
            get
            {
                if(RegistrationsData.IsNullOrEmpty())
                    throw new MyContainerException("Registrations is empty");
            
                return RegistrationsData[0];
                
            }
        }
    }
}