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
using Shaos.Sdk.Devices;
using Shaos.Sdk.Devices.Parameters;
using System.Collections.Specialized;

namespace Shaos.Sdk.UnitTests.Devices
{
    public class DeviceTests
    {
        private ListChangedEventArgs<BaseParameter> _listChangedEventArgs;

        [Fact]
        public void TestDeviceBatteryLevelChanged()
        {
            DeviceChangedEventArgs? eventArgs = null;

            Device device = new Device("name", [], 100, 0);

            EventHandler<DeviceChangedEventArgs> eventHandler = (s, e) =>
            {
                eventArgs = e;
            };

            try
            {
                device.DeviceChanged += eventHandler;

                device.BatteryLevel!.Level = 1;

                Assert.NotNull(eventArgs);
                Assert.Equal((uint)1, eventArgs.BatteryLevel!.Value);
            }
            finally
            {
                device.DeviceChanged -= eventHandler;
            }
        }

        [Fact]
        public async Task TestDeviceParameterAdded()
        {
            Device device = new Device("name", [], 100, 0);

            try
            {
                device.Parameters.ListChanged += ParametersListChanged;

                await device.Parameters.AddAsync(CreateBoolParameter());

                Assert.NotNull(_listChangedEventArgs);
                Assert.Equal(ListChangedAction.Add, _listChangedEventArgs.Action);
            }
            finally
            {
                device.Parameters.ListChanged += ParametersListChanged;
            }
        }

        [Fact]
        public async Task TestDeviceParameterRemoved()
        {
            var parameters = new List<BaseParameter>()
            {
                CreateBoolParameter()
            };

            Device device = new Device("name", parameters, 100, 0);

            try
            {
                device.Parameters.ListChanged += ParametersListChanged;

                await device.Parameters.RemoveAtAsync(0);

                Assert.NotNull(_listChangedEventArgs);
                Assert.Equal(ListChangedAction.Remove, _listChangedEventArgs.Action);
                Assert.Empty(device.Parameters);
            }
            finally
            {
                device.Parameters.ListChanged -= ParametersListChanged;
            }
        }

        [Fact]
        public void TestDeviceSignalLevelChanged()
        {
            DeviceChangedEventArgs? eventArgs = null;

            Device device = new Device("name", [], 100, 0);

            EventHandler<DeviceChangedEventArgs> eventHandler = (s, e) =>
            {
                eventArgs = e;
            };

            try
            {
                device.DeviceChanged += eventHandler;

                device.SignalLevel!.Level = -10;

                Assert.NotNull(eventArgs);
                Assert.Equal(-10, eventArgs.SignalLevel!.Value);
            }
            finally
            {
                device.DeviceChanged -= eventHandler;
            }
        }

        private static BoolParameter CreateBoolParameter()
        {
            return new BoolParameter(true, "name", "units", ParameterType.Iaq);
        }

        private Task ParametersListChanged(object sender, ListChangedEventArgs<BaseParameter> e)
        {
            _listChangedEventArgs = e;

            return Task.CompletedTask;
        }
    }
}