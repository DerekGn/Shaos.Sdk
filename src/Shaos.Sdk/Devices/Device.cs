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
using Shaos.Sdk.Devices.Parameters;

namespace Shaos.Sdk.Devices
{
    /// <summary>
    /// An implementation of an <see cref="IDevice"/>
    /// </summary>
    public class Device : IDevice
    {
        /// <summary>
        /// Create an instance of a <see cref="Device"/>
        /// </summary>
        /// <param name="id">The device identifier</param>
        /// <param name="name">The device name</param>
        /// <param name="parameters">The set of <see cref="BaseParameter"/> instances for this <see cref="Device"/></param>
        public Device(int id,
                      string name,
                      IList<IBaseParameter> parameters)
        {
            Id = id;
            Name = name;

            var childList = new ChildObservableList<IDevice, IBaseParameter>(this);

            Parameters = childList;

            foreach (var parameter in parameters)
            {
                childList.Add(parameter);
            }
        }

        /// <inheritdoc/>
        public int Id { get; internal set; }

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IChildObservableList<IDevice, IBaseParameter> Parameters { get; }
    }
}