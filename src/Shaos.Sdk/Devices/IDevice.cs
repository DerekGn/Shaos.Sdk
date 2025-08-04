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
    /// Represents a device
    /// </summary>
    public interface IDevice
    {
        /// <summary>
        /// Raised when the <see cref="Device"/> changes
        /// </summary>
        event EventHandler<DeviceChangedEventArgs>? DeviceChanged;

        /// <summary>
        /// The <see cref="BatteryLevel"/> for this device
        /// </summary>
        /// <remarks>
        /// A <see cref="Device"/> optional battery level
        /// </remarks>
        BatteryLevel? BatteryLevel { get; }

        /// <summary>
        /// The device identifier
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The device name
        /// </summary>
        /// <remarks>
        /// An optional <see cref="Device"/> name
        /// </remarks>
        string Name { get; }

        /// <summary>
        /// The set of <see cref="Device"/> <see cref="BaseParameter"/>
        /// </summary>
        IChildObservableList<IBaseParameter, IDevice> Parameters { get; }

        /// <summary>
        /// The <see cref="SignalLevel"/> for this device
        /// </summary>
        /// <remarks>
        /// A <see cref="Device"/> optional signal level
        /// </remarks>
        SignalLevel? SignalLevel { get; }

        /// <summary>
        /// Set the identifier of the <see cref="IDevice"/>
        /// </summary>
        /// <param name="id">The identifier to set</param>
        public void SetId(int id);
    }
}