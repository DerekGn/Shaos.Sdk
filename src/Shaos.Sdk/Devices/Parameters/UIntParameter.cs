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
    /// Represents a <see cref="uint"/> parameter
    /// </summary>
    /// <remarks>
    /// Create an instance of a <see cref="UIntParameter"/>
    /// </remarks>
    public class UIntParameter : BaseParameter<uint>
    {
        /// <summary>
        /// The maximum value for the <see cref="UIntParameter"/>
        /// </summary>
        public uint Max { get; }

        /// <summary>
        /// The minimum value for the <see cref="UIntParameter"/>
        /// </summary>
        public uint Min { get; }

        /// <param name="id">The parameter identifier</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="min">The minimum value for the <see cref="UIntParameter"/></param>
        /// <param name="max">The maximum value for the <see cref="UIntParameter"/></param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        public UIntParameter(int id,
                             uint value,
                             uint min,
                             uint max,
                             string name,
                             string units,
                             ParameterType? parameterType = default) : base(id, value, name, units, parameterType)
        {
            Max = max;
            Min = min;
        }

        /// <param name="id">The parameter identifier</param>
        /// <param name="value">The value of the parameter</param>
        /// <param name="min">The minimum value for the <see cref="UIntParameter"/></param>
        /// <param name="max">The maximum value for the <see cref="UIntParameter"/></param>
        /// <param name="name">The name of the parameter</param>
        /// <param name="units">The units of this parameter</param>
        /// <param name="writeAsync">The function for writing the parameters value</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of this parameter</param>
        public UIntParameter(int id,
                             uint value,
                             uint min,
                             uint max,
                             string name,
                             string units,
                             Func<int, uint, Task> writeAsync,
                             ParameterType? parameterType = default) : base(id, value, name, units, writeAsync, parameterType)
        {
            Max = max;
            Min = min;
        }
    }
}