/*
* MIT License
*
* Copyright (c) 2025 Derek Goslin https://github.com/DerekGn
*
* Permission is hereby granted, free of charge, to any person obtaining a copy
* of this software and associated documentation files (the "Software"), to deal
* in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
* copies of the Software, and to permit persons to whom the Software is
* furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all
* copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
* IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
* FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
* AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
* LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
* OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
* SOFTWARE.
*/

using Shaos.Sdk.Collections.Generic;

namespace Shaos.Sdk.Devices.Parameters
{
    /// <summary>
    /// A device <see cref="BaseParameter{T}"/>
    /// </summary>
    public abstract class BaseParameter<T> : BaseParameter, IBaseParameter<T>
    {
        private readonly bool _canWrite;
        private readonly Func<int, T, Task>? _writeAsync = null;
        private T _value;

        /// <summary>
        /// Create an instance of a <see cref="BaseParameter{T}"/>
        /// </summary>
        /// <param name="id">The parameter identifier</param>
        /// <param name="value">The parameter value</param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        protected BaseParameter(int id,
                                T value,
                                string name,
                                string units,
                                ParameterType? parameterType)
            : base(id, name, units, parameterType)
        {
            _value = value;
            _canWrite = false;
        }

        /// <summary>
        /// Create an instance of a <see cref="BaseParameter{T}"/>
        /// </summary>
        /// <param name="id">The parameter identifier</param>
        /// <param name="value">The parameter value</param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="writeAsync">The function for writing the parameters value</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        protected BaseParameter(int id,
                                T value,
                                string name,
                                string units,
                                Func<int, T, Task> writeAsync,
                                ParameterType? parameterType)
            : base(id, name, units, parameterType)
        {
            _value = value;
            _writeAsync = writeAsync;
            _canWrite = writeAsync != null;
        }

        /// <inheritdoc/>
        public event AsyncEventHandler<ParameterValueChangedEventArgs<T>>? ValueChanged;

        /// <inheritdoc/>
        public bool CanWrite => _canWrite;

        /// <inheritdoc/>
        public T Value
        {
            get
            {
                return _value;
            }
        }

        /// <inheritdoc/>
        public async Task NotifyValueChangedAsync(T value)
        {
            _value = value;

            await OnValueChangedAsync(new ParameterValueChangedEventArgs<T>(value));
        }

        /// <inheritdoc/>
        public async Task WriteAsync(T value)
        {
            if (_writeAsync != null)
            {
                await _writeAsync(Id,
                                  value);
            }
        }

        /// <summary>
        /// Raise the <see cref="ValueChanged"/> event
        /// </summary>
        /// <param name="eventArgs">The <see cref="ListChangedEventArgs{T}"/></param>
        protected virtual async Task OnValueChangedAsync(ParameterValueChangedEventArgs<T> eventArgs)
        {
            if (ValueChanged != null)
            {
                await ValueChanged.Invoke(this, eventArgs);
            }
        }
    }
}