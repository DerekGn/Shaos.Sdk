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
    public class FloatParameterTests : BaseParameterTests
    {
        private const int Id = 10;
        private readonly FloatParameter _parameter;
        private ParameterValueChangedEventArgs<float>? _eventArgs;
        private float _updatedValue;

        public FloatParameterTests()
        {
            _parameter = new FloatParameter(1.0f,
                                            0f,
                                            1.0f,
                                            0.1f,
                                            nameof(FloatParameter),
                                            "Units",
                                            "reference",
                                            ParameterType.Level,
                                            WriteCallbackAsync);

            _parameter.ValueChanged += ParameterValueChanged;
        }

        [Fact]
        public void TestParameterProperties()
        {
            _parameter.AssignId(Id);

            Assert.NotNull(_parameter);
            Assert.Equal(Id, _parameter.Id);
            Assert.Equal(0, _parameter.Min);
            Assert.Equal(0.1f, _parameter.Step);
            Assert.Equal(1, _parameter.Max);
            Assert.Equal(nameof(FloatParameter), _parameter.Name);
            Assert.Equal(ParameterType.Level, _parameter.ParameterType);
            Assert.Equal(Units, _parameter.Units);
        }

        [Fact]
        public async Task TestValueChangedAsync()
        {
            await _parameter.NotifyValueChangedAsync(10.0f);

            Assert.NotNull(_eventArgs);
            Assert.Equal(10.0f, _eventArgs.Value);
            Assert.Equal(10.0f, _parameter.Value);
            Assert.Equal(10.0f, _updatedValue);
            Assert.Equal(DateTime.UtcNow,
                         _eventArgs.TimeStamp,
                         TimeSpan.FromSeconds(1));
        }

        [Fact]
        public async Task TestWriteValue()
        {
            _parameter.AssignId(Id);

            await _parameter.WriteAsync(1.0f);

            Assert.True(_parameter.CanWrite);
            Assert.Equal(1.0f, _updatedValue);
        }

        private async Task ParameterValueChanged(object sender,
                                                 ParameterValueChangedEventArgs<float> e)
        {
            _updatedValue = e.Value;
            _eventArgs = e;

            await Task.CompletedTask;
        }

        private async Task WriteCallbackAsync(int id,
                                              float value)
        {
            _updatedValue = value;

            await Task.CompletedTask;
        }
    }
}