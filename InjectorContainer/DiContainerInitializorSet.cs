using System;
using System.Collections.Generic;

namespace DiContainerLibrary.DiContainer
{
    public static partial class DiContainerInitializor
    {
        /// <summary>
        /// Binds interface to object.
        /// </summary>
        /// <typeparam name="TInterface">The interfacec that contains definition.</typeparam>
        /// <typeparam name="TClass">The class that interface needs to be bind to.</typeparam>
        /// <param name="container">The container data.</param>
        /// <returns></returns>
        public static KeyValuePair<Type, ContainerData> BindInstance<TInterface, TClass>(this Dictionary<Type, ContainerData> container)
            where TClass : TInterface , new()
        {
            var result = new ContainerData()
            {
                dataType = typeof(TClass),
                IsStatic = false,
            };

            var keyValuePair = new KeyValuePair<Type, ContainerData>(typeof(TInterface), result);
            container.Add(keyValuePair.Key, keyValuePair.Value);

            return keyValuePair;
        }

        /// <summary>
        /// Only one instance of object will be present at any time.
        /// </summary>
        /// <param name="container">The key value pair where instance is located.</param>
        public static void AsSingle(this KeyValuePair<Type, ContainerData> container)
        {
            container.Value.IsStatic = true;
        }

        /// <summary>
        /// For every request of object new instance will be created.
        /// </summary>
        /// <param name="container">The key value pair where instance is located.</param>
        public static void AsTransient(this KeyValuePair<Type, ContainerData> container)
        {
            container.Value.IsStatic = false;
        }

        /// <summary>
        /// The container.
        /// </summary>
        public static Dictionary<Type, ContainerData> Container = new Dictionary<Type, ContainerData>();
    }
}
