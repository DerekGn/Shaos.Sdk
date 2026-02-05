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
        /// <param name="features">The device features <see cref="DeviceFeatures"/></param>
        /// <param name="parameters">The set of <see cref="BaseParameter"/> instances for this <see cref="Device"/></param>
        public Device(int id,
                      string name,
                      DeviceFeatures features,
                      IList<IBaseParameter> parameters)
        {
            Id = id;
            Name = name;
            Features = features;

            if ((features & DeviceFeatures.BatteryPowered) == DeviceFeatures.BatteryPowered)
            {
                BatteryLevel = new BatteryLevel(this, 0);
            }

            if ((features & DeviceFeatures.Wireless) == DeviceFeatures.Wireless)
            {
                SignalLevel = new SignalLevel(this, -100);
            }

            var childList = new ChildObservableList<IDevice, IBaseParameter>(this);

            Parameters = childList;

            foreach (var parameter in parameters)
            {
                childList.Add(parameter);
            }
        }

        /// <inheritdoc/>
        public event AsyncEventHandler<BatteryLevelChangedEventArgs>? BatteryLevelChanged;

        /// <inheritdoc/>
        public event AsyncEventHandler<SignalLevelChangedEventArgs>? SignalLevelChanged;

        /// <inheritdoc/>
        public BatteryLevel? BatteryLevel { get; }

        /// <inheritdoc/>
        public DeviceFeatures Features { get; }

        /// <inheritdoc/>
        public int Id { get; internal set; }

        /// <inheritdoc/>
        public string Name { get; }

        /// <inheritdoc/>
        public IChildObservableList<IDevice, IBaseParameter> Parameters { get; }

        /// <inheritdoc/>
        public SignalLevel? SignalLevel { get; }

        internal void RaiseBatteryLevelChanged(uint level)
        {
            OnBatteryLevelChanged(new BatteryLevelChangedEventArgs() { BatteryLevel = level });
        }

        internal void RaiseSignalLevelChanged(int level)
        {
            OnSignalLevelChanged(new SignalLevelChangedEventArgs() { SignalLevel = level });
        }

        /// <summary>
        /// Raise the <see cref="BatteryLevelChanged"/>
        /// </summary>
        /// <param name="e">The <see cref="BatteryLevelChangedEventArgs"/></param>
        protected virtual void OnBatteryLevelChanged(BatteryLevelChangedEventArgs e)
        {
            BatteryLevelChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Raise the <see cref="SignalLevelChanged"/>
        /// </summary>
        /// <param name="e">The <see cref="SignalLevelChangedEventArgs"/></param>
        protected virtual void OnSignalLevelChanged(SignalLevelChangedEventArgs e)
        {
            SignalLevelChanged?.Invoke(this, e);
        }
    }
}