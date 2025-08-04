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

namespace Shaos.Sdk.UnitTests.Collections.Generic
{
    public class ObservableListTests
    {
        private readonly ObservableList<int> _observableList;
        private ListChangedEventArgs<int>? _eventArgs = null;

        public ObservableListTests()
        {
            _observableList = new ObservableList<int>();

            _observableList.ListChanged += ObservableListChanged;
        }

        [Fact]
        public async Task TestAddAsync()
        {
            await _observableList.AddAsync(1);

            Assert.NotNull(_eventArgs);
            Assert.Equal(ListChangedAction.Add, _eventArgs.Action);
            Assert.Single(_eventArgs.Items);
            Assert.Equal(1, _observableList.Count);
        }

        [Fact]
        public async Task TestClearAsync()
        {
            await _observableList.AddAsync(10);

            await _observableList.ClearAsync();

            Assert.NotNull(_eventArgs);
            Assert.Equal(ListChangedAction.Reset, _eventArgs.Action);
            Assert.Single(_eventArgs.Items);
            Assert.Equal(10, _eventArgs.Items[0]);
        }

        [Fact]
        public async Task TestInsertAsync()
        {
            await _observableList.InsertAsync(0, 1);

            Assert.NotNull(_eventArgs);
            Assert.Equal(ListChangedAction.Add, _eventArgs.Action);
            Assert.Single(_eventArgs.Items);
            Assert.Equal(1, _eventArgs.Items[0]);
        }

        [Fact]
        public async Task TestRemoveAsync()
        {
            await _observableList.AddAsync(10);

            await _observableList.RemoveAsync(10);

            Assert.NotNull(_eventArgs);
            Assert.Equal(ListChangedAction.Remove, _eventArgs.Action);
            Assert.Single(_eventArgs.Items);
            Assert.Equal(10, _eventArgs.Items[0]);
        }

        [Fact]
        public async Task TestRemoveAtAsync()
        {
            await _observableList.AddAsync(10);
            await _observableList.RemoveAtAsync(0);

            Assert.NotNull(_eventArgs);
            Assert.Equal(ListChangedAction.Remove, _eventArgs.Action);
            Assert.Single(_eventArgs.Items);
            Assert.Equal(10, _eventArgs.Items[0]);
        }

        private Task ObservableListChanged(object sender, ListChangedEventArgs<int> e)
        {
            _eventArgs = e;

            return Task.CompletedTask;
        }
    }
}