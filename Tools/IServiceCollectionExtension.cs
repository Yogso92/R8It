using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Tools
{
    public static class IServiceCollectionExtension
    {
        public static IEnumerable<Type> ScanTypesFrom(this IServiceCollection serviceProvider, Assembly assembly)
        {
            return assembly.GetExportedTypes()
                .Select(t => t.GetTypeInfo())
                .Where(t => !t.IsAbstract)
                .Where(t => t.DeclaredConstructors.Any(c => !c.IsStatic && c.IsPublic))
                .Select(t => t.AsType());
        }

        public static IEnumerable<ServiceTypeAndImplementationTypePair> AsInterfaces(this IEnumerable<Type> types)
            => types.Select(t => new ServiceTypeAndImplementationTypePair(t.GetInterfaces().ToList(), t));

        public static IEnumerable<ServiceTypeAndImplementationTypePair> AsInterfaces(
            this IEnumerable<Type> types,
            params Type[] interfaces)
        {
            return
                types.Select(
                    t =>
                        new ServiceTypeAndImplementationTypePair(
                            t.GetInterfaces().Where(iface => interfaces.Contains(iface)).ToList(),
                            t));
        }

        public static IServiceCollection RegisterAsScoped(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs, IServiceCollection services)
        {
            foreach (var pair in pairs)
            {
                foreach (var serviceType in pair.ServiceTypes)
                {
                    services.AddScoped(serviceType, pair.ImplementationType);
                }
            }
            return services;
        }

        public static IServiceCollection RegisterAsTransient(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs, IServiceCollection services)
        {
            foreach (var pair in pairs)
            {
                foreach (var serviceType in pair.ServiceTypes)
                {
                    services.AddTransient(serviceType, pair.ImplementationType);
                }
            }
            return services;
        }

        public static IServiceCollection RegisterAsSingleton(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs, IServiceCollection services)
        {
            foreach (var pair in pairs)
            {
                foreach (var serviceType in pair.ServiceTypes)
                {
                    services.AddSingleton(serviceType, pair.ImplementationType);
                }
            }
            return services;
        }
    }

    public class ServiceTypeAndImplementationTypePair
    {
        public ServiceTypeAndImplementationTypePair(List<Type> serviceTypes, Type implementationType)
        {
            ImplementationType = implementationType;
            ServiceTypes = serviceTypes;
        }

        public Type ImplementationType { get; }

        public List<Type> ServiceTypes { get; }
    }
}

