using System;
using System.Linq;
using System.Reflection;

namespace DiContainerLibrary.DiContainer
{
    public static partial class DiContainerInitializor
    {
        /// <summary>
        /// Registers specific component that implements interface.
        /// </summary>
        /// <typeparam name="TInterface">The interface to register</typeparam>
        /// <returns>The registered component.</returns>
        public static TInterface Register<TInterface>()
           where TInterface : class
        {
            var containerData = Container[typeof(TInterface)];
            var instance = Activator.CreateInstance(containerData.dataType);
            if (containerData.IsStatic)
            {
                if (containerData.actualValue == null)
                {
                    containerData.actualValue = instance;
                }
                return (TInterface)containerData.actualValue;
            }

            var result = Activator.CreateInstance(containerData.dataType);
            return (TInterface)result;
        }

        /// <summary>
        /// Registers whole object (every property with <see cref="InjectDiContainter"/>.
        /// </summary>
        /// <param name="objectToinitialize">The object that wll be registered.</param>
        public static void RegisterObject(object objectToinitialize)
        {
            var properties = objectToinitialize.GetType()
                .GetProperties(
                BindingFlags.NonPublic | BindingFlags.Public 
                | BindingFlags.Static | BindingFlags.Instance)
                .Where(prop => prop.IsDefined(typeof(InjectDiContainter), false)).ToList();

            foreach (var property in properties)
            {
                var getType = property.PropertyType;
                property.SetValue(objectToinitialize, getType.Register(), null);
            }
        }

        /// <summary>
        /// Register specific interface type.
        /// </summary>
        /// <param name="type">The type data.</param>
        /// <returns>Registered object.</returns>
        private static object Register(this Type type)
        {
            var containerData = Container[type];
            var instance = Activator.CreateInstance(containerData.dataType);
            if (containerData.IsStatic)
            {
                if (containerData.actualValue == null)
                {
                    containerData.actualValue = instance;
                }
                return containerData.actualValue;
            }

            var result = Activator.CreateInstance(containerData.dataType);
            return result;
        }
    }
}
