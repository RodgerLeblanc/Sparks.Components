using System;
using System.Collections.Generic;
using System.Text;

namespace Sparks.Components.Blazor
{
    /// <summary>
    /// Modal parameters.
    /// </summary>
    public class ModalParameters
    {
        /// <summary>
        /// Private cache.
        /// </summary>
        private readonly Dictionary<string, object> _parameters;

        /// <summary>
        /// Constructor.
        /// </summary>
        public ModalParameters()
        {
            _parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// Adds a parameter.
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="value"></param>
        public void Add(string parameterName, object value)
        {
            _parameters[parameterName] = value;
        }

        /// <summary>
        /// Gets a parameter by its name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public T Get<T>(string parameterName)
        {
            if (!_parameters.ContainsKey(parameterName))
            {
                throw new KeyNotFoundException($"{parameterName} does not exist in modal parameters");
            }

            return (T)_parameters[parameterName];
        }
    }
}
