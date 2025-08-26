using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using App.Scripts.Infrastructure.DI.Exception;
using App.Scripts.Infrastructure.DI.Registration.Container;

namespace App.Scripts.Infrastructure.DI.Instantiator
{
    public class ContainerInstantiator
    {
        private readonly List<object> _bufferArguments = new();
    
        private readonly RegistrationContainer _registrationContainer;

        public ContainerInstantiator(RegistrationContainer registrationContainer)
        {
            _registrationContainer = registrationContainer;
        }
    
        public object CreateInstance(Type buildType ,object[] arguments = null)
        {
            return BuildConstructorArguments(buildType, arguments);
        }
    
        private object BuildConstructorArguments(Type type, object[] arguments)
        {
            var constructors = type.GetConstructors();

            foreach (ConstructorInfo constructorInfo in constructors)
            {
                var parameters = constructorInfo.GetParameters();

                var resolvedParams = GetResolvedParameters(parameters, arguments, type);

                if (resolvedParams is null)
                {
                    throw new MyContainerException($"Cant resolve params for type {type.FullName} for constructor {constructorInfo}");
                }

                return constructorInfo.Invoke(resolvedParams.ToArray());
            }

            throw new MyContainerException($"Cant resolve params for type {type.FullName}");
        }

    
        private List<object> GetResolvedParameters(ParameterInfo[] parameterInfos, object[] arguments, Type buildType)
        {
            var result = new List<object>();

            _bufferArguments.Clear();
            if (arguments != null)
            {
                _bufferArguments.AddRange(arguments);
            }
            
            foreach (ParameterInfo parameterInfo in parameterInfos)
            {
                var argument = FindFromArgument(parameterInfo, _bufferArguments);

                if (argument != null)
                {
                    result.Add(argument);
                    continue;
                }
                
                var resolveParam = ResolveForType(parameterInfo.ParameterType);

                if (resolveParam is null)
                {
                    throw new MyContainerException($"Cant resolve type {parameterInfo.ParameterType} for {buildType}");
                }
                
                result.Add(resolveParam);
                
            }

            return result;
        }
    
        private object FindFromArgument(ParameterInfo parameterInfo, List<object> bufferArguments)
        {
            for (int i = 0; i < bufferArguments.Count; i++)
            {
                var argument = bufferArguments[i];
                
                if (parameterInfo.ParameterType.IsInstanceOfType(argument))
                {
                    bufferArguments.RemoveAt(i);
                    return argument;
                }
            }

            return null;
        }
    
        private object ResolveForType(Type resolveType)
        {
            var selectType = resolveType;

            var enumerableType = typeof(IEnumerable<>);
            
            var genericType = selectType
                .GetInterfaces()
                .Where(x => x.IsGenericType && x.GetGenericTypeDefinition() == enumerableType)
                .Select(x => x.GetGenericArguments()[0]).FirstOrDefault();

            if (genericType != null)
            {
                return ResolveEnumerable(genericType);
            }
                
            return Resolve(resolveType);
        }

        private object Resolve(Type resolveType)
        {
            foreach (var registrationData in _registrationContainer.RegistrationsData)
            {
                foreach (var registration in registrationData.Registrations)
                {
                    if (resolveType.IsAssignableFrom(registration.Key) )
                    {
                        return registration.Value.Resolve(this);
                    }
                }
            }

            return null;
        }
    
        private IEnumerable<object> ResolveEnumerable(Type genericType)
        {
            foreach (var registrationData in _registrationContainer.RegistrationsData)
            {
                foreach (var registration in registrationData.Registrations)
                {
                    if (genericType.IsAssignableFrom(registration.Key) )
                    {
                        return registration.Value.ResolveMany(this);
                    }
                }
            }

            return null;
        }
    }
}
