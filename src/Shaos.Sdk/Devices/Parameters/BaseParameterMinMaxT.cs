namespace Shaos.Sdk.Devices.Parameters
{
    /// <summary>
    /// Represents a parameter with a min max and step value of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type parameter</typeparam>
    public abstract class BaseParameterMinMax<T> : BaseParameter<T>
    {
        /// <summary>
        /// Create an instance of a <see cref="BaseParameterMinMax{T}"/>
        /// </summary>
        /// <param name="instanceId">The parameter instance identifier</param>
        /// <param name="value">The value of the <see cref="BaseParameterMinMax{T}"/>></param>
        /// <param name="min">The minimum value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="max">The maximum value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="step">The step value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        protected BaseParameterMinMax(string instanceId,
                                      T value,
                                      T min,
                                      T max,
                                      T step,
                                      string name,
                                      string units,
                                      ParameterType? parameterType) : base(instanceId,
                                                                           value,
                                                                           name,
                                                                           units,
                                                                           parameterType)
        {
            Max = max;
            Min = min;
            Step = step;
        }

        /// <summary>
        /// Create an instance of a <see cref="BaseParameterMinMax{T}"/>
        /// </summary>
        /// <param name="instanceId">The parameter instance identifier</param>
        /// <param name="value">The value of the <see cref="BaseParameterMinMax{T}"/>></param>
        /// <param name="min">The minimum value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="max">The maximum value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="step">The step value for the <see cref="BaseParameterMinMax{T}"/></param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="writeAsync">The function for writing the parameters value</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        protected BaseParameterMinMax(string instanceId,
                                      T value,
                                      T min,
                                      T max,
                                      T step,
                                      string name,
                                      string units,
                                      Func<string, T, Task> writeAsync,
                                      ParameterType? parameterType) : base(instanceId,
                                                                           value,
                                                                           name,
                                                                           units,
                                                                           writeAsync,
                                                                           parameterType)
        {
            Max = max;
            Min = min;
            Step = step;
        }

        /// <summary>
        /// The maximum value
        /// </summary>
        public T Max { get; }

        /// <summary>
        /// The minimum value
        /// </summary>
        public T Min { get; }

        /// <summary>
        /// The step value
        /// </summary>
        public T Step { get; }
    }
}