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


namespace Shaos.Sdk.Devices.Parameters
{
    /// <summary>
    /// Represents a typed base parameter
    /// </summary>
    /// <typeparam name="T">The parameter type</typeparam>
    public interface IBaseParameter<T> : IBaseParameter
    {
        /// <summary>
        /// The <see cref="BaseParameter{T}"/> current value
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Raised when the value of the parameter changes
        /// </summary>
        event AsyncEventHandler<ParameterValueChangedEventArgs<T>>? ValueChanged;

        /// <summary>
        /// Notify <see cref="IBaseParameter{T}"/> value
        /// </summary>
        /// <param name="value">The value to assign to <see cref="Value"/></param>
        Task NotifyValueChangedAsync(T value);
    }
}