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
    /// Represents the <see cref="BaseParameter"/> type
    /// </summary>
    public enum ParameterType
    {
        AbsoluteActiveEnergy,
        /// <summary>
        /// The absolute reactive energy
        /// </summary>
        AbsoluteReactiveEnergy,
        /// <summary>
        /// The absolute active energy
        /// </summary>
        ActivePower,
        /// <summary>
        /// The apparent power of a phase
        /// </summary>
        ApparentPower,
        /// <summary>
        /// The current of a phase
        /// </summary>
        Current,
        /// <summary>
        /// The estimated carbon dioxide level
        /// </summary>
        eCo2,
        /// <summary>
        /// The equivalent ethanol level
        /// </summary>
        EtOH,
        /// <summary>
        /// The flow rate of a liquid or gas
        /// </summary>
        FlowRate,
        /// <summary>
        /// The forward active energy
        /// </summary>
        ForwardActiveEnergy,
        /// <summary>
        /// The forward reactive energy
        /// </summary>
        ForwardReactiveEnergy,
        /// <summary>
        /// The frequency of a signal
        /// </summary>
        Frequency,
        /// <summary>
        /// The Indoor air quality
        /// </summary>
        Iaq,
        /// <summary>
        /// The level
        /// </summary>
        Level,
        /// <summary>
        /// The phase angle
        /// </summary>
        PhaseAngle,
        /// <summary>
        /// The power factor
        /// </summary>
        PowerFactor,
        /// <summary>
        /// The pressure of a liquid or a gas
        /// </summary>
        Pressure,
        /// <summary>
        /// The Reactive power
        /// </summary>
        ReactivePower,
        /// <summary>
        /// The real power
        /// </summary>
        RealPower,
        /// <summary>
        /// The relative humidity
        /// </summary>
        RelativeHumidity,
        /// <summary>
        /// The reverse active energy
        /// </summary>
        ReverseActiveEnergy,
        /// <summary>
        /// The reverse reactive energy
        /// </summary>
        ReverseReactiveEnergy,
        /// <summary>
        /// The rotation speed
        /// </summary>
        RotationSpeed,
        /// <summary>
        /// The Received Signal Strength Indicator
        /// </summary>
        Rssi,
        /// <summary>
        /// The temperature
        /// </summary>
        Temperature,
        /// <summary>
        /// The total volatile organic compounds
        /// </summary>
        TVOC,
        /// <summary>
        /// The voltage level
        /// </summary>
        Voltage,
        /// <summary>
        /// The volume of a gas or liquid
        /// </summary>
        Volume
    }
}