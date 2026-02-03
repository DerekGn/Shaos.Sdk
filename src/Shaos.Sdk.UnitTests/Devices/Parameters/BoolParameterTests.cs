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

using Shaos.Sdk.Devices.Parameters;

namespace Shaos.Sdk.UnitTests.Devices.Parameters
{
    public class BoolParameterTests : BaseParameterTests
    {
        private readonly BoolParameter _parameter;
        private ParameterValueChangedEventArgs<bool>? _eventArgs;
        private bool _updatedValue;

        public BoolParameterTests()
        {
            _parameter = new BoolParameter(false,
                                           nameof(BoolParameter),
                                           Units,
                                           WriteCallbackAsync,
                                           ParameterType.Level);

            _parameter.ValueChanged += ParameterValueChanged;
        }

        [Fact]
        public void TestParameterProperties()
        {
            _parameter.SetId(10);

            Assert.NotNull(_parameter);
            Assert.Equal(10,
                         _parameter.Id);
            Assert.Equal(nameof(BoolParameter),
                         _parameter.Name);
            Assert.Equal(ParameterType.Level,
                         _parameter.ParameterType);
            Assert.Equal(Units,
                         _parameter.Units);
        }

        [Fact]
        public async Task TestValueChangedAsync()
        {
            await _parameter.NotifyValueChangedAsync(true);

            Assert.NotNull(_eventArgs);
            Assert.True(_eventArgs.Value);
            Assert.True(_parameter.Value);
            Assert.Equal(DateTime.UtcNow,
                         _eventArgs.TimeStamp,
                         TimeSpan.FromSeconds(1));
        }

        [Fact]
        public async Task TestWriteValue()
        {
            await _parameter.WriteAsync(true);

            Assert.True(_parameter.CanWrite);
            Assert.True(_updatedValue);
        }

        private async Task ParameterValueChanged(object sender,
                                                 ParameterValueChangedEventArgs<bool> e)
        {
            _eventArgs = e;

            await Task.CompletedTask;
        }

        private async Task WriteCallbackAsync(int id,
                                              bool value)
        {
            _updatedValue = value;

            await Task.CompletedTask;
        }
    }
}