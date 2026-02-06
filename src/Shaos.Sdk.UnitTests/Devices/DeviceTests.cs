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

namespace Shaos.Sdk.UnitTests.Devices
{
    public class DeviceTests
    {
        private const string Name = "name";

        private ListChangedEventArgs<IBaseParameter>? _listChangedEventArgs;

        [Fact]
        public async Task TestDeviceParameterAdded()
        {
            Device device = new Device(1,
                                       Name,
                                       []);

            try
            {
                device.Parameters.ListChanged += ParametersListChanged;

                await device.Parameters.AddAsync(CreateBoolParameter());

                Assert.NotNull(_listChangedEventArgs);
                Assert.Equal(ListChangedAction.Add,
                             _listChangedEventArgs.Action);
            }
            finally
            {
                device.Parameters.ListChanged += ParametersListChanged;
            }
        }

        [Fact]
        public async Task TestDeviceParameterRemoved()
        {
            var parameters = new List<IBaseParameter>()
            {
                CreateBoolParameter()
            };

            Device device = new Device(1,
                                       Name,
                                       parameters);

            try
            {
                device.Parameters.ListChanged += ParametersListChanged;

                await device.Parameters.RemoveAtAsync(0);

                Assert.NotNull(_listChangedEventArgs);
                Assert.Equal(ListChangedAction.Remove,
                             _listChangedEventArgs.Action);
                Assert.Empty(device.Parameters);
            }
            finally
            {
                device.Parameters.ListChanged -= ParametersListChanged;
            }
        }

        [Fact]
        public void TestDeviceProperties()
        {
            Device device = new Device(1,
                                       Name,
                                       []);

            Assert.Equal(1, device.Id);
            Assert.Equal(Name, device.Name);
        }

        private static BoolParameter CreateBoolParameter()
        {
            return new BoolParameter(1,
                                     true,
                                     Name,
                                     "units",
                                     ParameterType.Iaq);
        }

        private Task ParametersListChanged(object sender,
                                           ListChangedEventArgs<IBaseParameter> e)
        {
            _listChangedEventArgs = e;

            return Task.CompletedTask;
        }
    }
}