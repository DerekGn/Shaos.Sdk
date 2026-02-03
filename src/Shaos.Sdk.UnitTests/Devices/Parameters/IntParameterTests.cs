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
    public class IntParameterTests : BaseParameterTests
    {
        private readonly IntParameter _parameter;
        private ParameterValueChangedEventArgs<int>? _eventArgs;
        private int _updatedValue;

        public IntParameterTests()
        {
            _parameter = new IntParameter(1,
                                          -1,
                                          10,
                                          nameof(IntParameter),
                                          "Units",
                                          WriteCallbackAsync,
                                          ParameterType.Level);

            _parameter.ValueChanged += ParameterValueChanged;
        }

        [Fact]
        public void TestParameterProperties()
        {
            _parameter.SetId(10);

            Assert.NotNull(_parameter);
            Assert.Equal(10, _parameter.Id);
            Assert.Equal(10, _parameter.Max);
            Assert.Equal(-1, _parameter.Min);
            Assert.Equal(nameof(IntParameter), _parameter.Name);
            Assert.Equal(ParameterType.Level, _parameter.ParameterType);
            Assert.Equal(Units, _parameter.Units);
        }

        [Fact]
        public async Task TestValueChangedAsync()
        {
            await _parameter.NotifyValueChangedAsync(10);

            Assert.NotNull(_eventArgs);
            Assert.Equal(10, _eventArgs.Value);
            Assert.Equal(10, _parameter.Value);
            Assert.Equal(DateTime.UtcNow,
                         _eventArgs.TimeStamp,
                         TimeSpan.FromSeconds(1));
        }

        [Fact]
        public async Task TestWriteValue()
        {
            await _parameter.WriteAsync(1);

            Assert.True(_parameter.CanWrite);
            Assert.Equal(1.0, _updatedValue);
        }

        private async Task ParameterValueChanged(object sender,
                                                 ParameterValueChangedEventArgs<int> e)
        {
            _eventArgs = e;

            await Task.CompletedTask;
        }

        private async Task WriteCallbackAsync(int id,
                                              int value)
        {
            _updatedValue = value;

            await Task.CompletedTask;
        }
    }
}