using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * The Service namespace is a collection of classes that utilises Inversion of Control (IOC) principle,
 * which allows you to decouple classes and makes it easier to write unit tests.
 * 
 * In a typical WPF app you will want to show various dialogs such as the open file dialog and print dialog.
 * You need a way to decouple your View-Model class from the Microsoft.Win32.OpenFileDialog class otherwise 
 * when you come to unit tests, open file dialogs will suddenly appear. The Service classes make it easier 
 * to obtain typical application dialogs and still be decoupled from their actual implementation.
 * 
 */
namespace MpdBaileyTechnology.Shared.WPF.Service
{
    /// <summary>
    /// Very basic implementation of an Inversion of Control (IOC) container 
    /// For a more fully featured IOC container see The Castle Windsor project at:
    /// http://www.castleproject.org/
    /// 
    /// Add your services to the container and then pass the container to the application.
    /// For unit testing, add mock services instead to the container.
    /// 
    /// </summary>
    public class ServiceContainer
    {
        private readonly Dictionary<Type, Func<object>> _TypeToCreator = new Dictionary<Type, Func<object>>();

        /// <summary>
        /// Add a service by passing a delegate function that creates an instance of your service
        /// </summary>
        /// <typeparam name="T">The interface that specifies the service</typeparam>
        /// <param name="creator">The function that performs the work of instantiating the service object</param>
        public void Register<T>(Func<object> creator)
        {
            _TypeToCreator.Add(typeof(T), creator);
        }
        /// <summary>
        /// Creates and returns the instance of a service
        /// </summary>
        /// <typeparam name="T">Specify the service you wish to create as a generic type</typeparam>
        /// <returns>An instance of the service</returns>
        public T Create<T>()
        {
            return (T)_TypeToCreator[typeof(T)]();
        }
    }
}
