﻿using System;
using System.Collections.Generic;
using CqrsFramework.Config;
using Microsoft.Extensions.DependencyInjection;

namespace CommandProcessor
{
    public class DependencyResolver : IServiceLocator
    {
        private readonly IServiceProvider _serviceProvider;

        public DependencyResolver(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }
            try
            {
                return _serviceProvider.GetService(serviceType);
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}
