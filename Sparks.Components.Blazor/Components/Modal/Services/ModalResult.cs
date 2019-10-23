using System;

namespace Sparks.Components.Blazor.Services
{
    /// <summary>
    /// Modal result.
    /// </summary>
    public class ModalResult
    {
        /// <summary>
        /// Constructs a success modal result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ModalResult Ok() => new ModalResult(default, typeof(object), false);

        /// <summary>
        /// Constructs a success modal result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ModalResult Ok<T>(T result) => new ModalResult(result, typeof(T), false);

        /// <summary>
        /// Constructs a cancelled modal result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static ModalResult Cancel() => new ModalResult(default, typeof(object), true);

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="resultType"></param>
        /// <param name="cancelled"></param>
        protected ModalResult(object data, Type resultType, bool cancelled)
        {
            Data = data;
            DataType = resultType;
            Cancelled = cancelled;
        }

        /// <summary>
        /// Gets the modal result data.
        /// </summary>
        public object Data { get; }

        /// <summary>
        /// Gets the modal result data type.
        /// </summary>
        public Type DataType { get; }

        /// <summary>
        /// Gets wether the modal result was cancelled.
        /// </summary>
        public bool Cancelled { get; }
    }
}