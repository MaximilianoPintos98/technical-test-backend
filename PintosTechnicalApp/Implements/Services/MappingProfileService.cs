﻿using AutoMapper;
using PintosTechnicalApp.Interfaces;
using System.Reflection;

namespace PintosTechnicalApp.Implements.Services;

public class MappingProfileService : Profile
{
    public MappingProfileService()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping") ?? type.GetInterface("IMapFrom`1").GetMethod("Mapping");
            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}