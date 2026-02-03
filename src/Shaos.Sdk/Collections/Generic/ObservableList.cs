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

using System.Collections;

namespace Shaos.Sdk.Collections.Generic
{
    /// <summary>
    /// An observable list of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type of the elements of this <see cref="ObservableList{T}"/></typeparam>
    public class ObservableList<T> : IObservableList<T>
    {
        private readonly IList<T> _items;

        /// <summary>
        /// Create an instance of an <see cref="ObservableList{T}"/>
        /// </summary>
        public ObservableList()
        {
            _items = [];
        }

        /// <inheritdoc/>
        public event AsyncEventHandler<ListChangedEventArgs<T>>? ListChanged;

        /// <inheritdoc/>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <inheritdoc/>
        public async Task AddAsync(T item)
        {
            _items.Add(item);

            await OnListChangedAsync(new ListChangedEventArgs<T>(ListChangedAction.Add,
                                                                 [item]));
        }

        /// <inheritdoc/>
        public async Task ClearAsync()
        {
            T[] values = [.. _items];

            _items.Clear();

            await OnListChangedAsync(new ListChangedEventArgs<T>(ListChangedAction.Reset,
                                                                 values));
        }

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <inheritdoc/>
        public async Task InsertAsync(int index,
                                      T item)
        {
            _items.Insert(index, item);

            await OnListChangedAsync(new ListChangedEventArgs<T>(ListChangedAction.Add,
                                                                 [item]));
        }

        /// <inheritdoc/>
        public async Task<bool> RemoveAsync(T item)
        {
            var removed = _items.Remove(item);

            if (removed)
            {
                await OnListChangedAsync(new ListChangedEventArgs<T>(ListChangedAction.Remove,
                                                                     [item]));
            }

            return removed;
        }

        /// <inheritdoc/>
        public async Task RemoveAtAsync(int index)
        {
            var item = _items[index];

            _items.RemoveAt(index);

            if (item != null)
            {
                await OnListChangedAsync(new ListChangedEventArgs<T>(ListChangedAction.Remove,
                                                                     [item]));
            }
        }

        internal void Add(T item)
        {
            _items.Add(item);
        }

        /// <inheritdoc/>
        protected virtual async Task OnListChangedAsync(ListChangedEventArgs<T> eventArgs)
        {
            if (ListChanged != null)
            {
                await ListChanged.Invoke(this, eventArgs);
            }
        }
    }
}