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
    /// Represents a <see cref="int"/> parameter
    /// </summary>
    /// <remarks>
    /// Create an instance of a <see cref="IntParameter"/>
    /// </remarks>
    /// <param name="value">The value of the parameter</param>
    /// <param name="min">The minimum value for the <see cref="IntParameter"/></param>
    /// <param name="max">The maximum value for the <see cref="IntParameter"/></param>
    /// <param name="name">The name of the parameter</param>
    /// <param name="units">The units of this parameter</param>
    /// <param name="canWrite">Indicates if the parameter can be written</param>
    /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
    public class IntParameter(int value,
                              int min,
                              int max,
                              string name,
                              string units,
                              bool canWrite = false,
                              ParameterType? parameterType = default) 
        : BaseParameter<int>(value, name, units, canWrite, parameterType)
    {
        /// <summary>
        /// The maximum value for the <see cref="IntParameter"/>
        /// </summary>
        public int Max { get; } = max;

        /// <summary>
        /// The minimum value for the <see cref="IntParameter"/>
        /// </summary>
        public int Min { get; } = min;
    }
}