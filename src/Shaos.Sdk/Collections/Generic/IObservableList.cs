namespace Shaos.Sdk.Collections.Generic
{
    /// <summary>
    /// An observable list of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type of the elements of this <see cref="ObservableList{T}"/></typeparam>
    public interface IObservableList<T> : IEnumerable<T>
    {
        /// <summary>
        /// Create an instance of an <see cref="ObservableList{T}"/>
        /// </summary>
        event AsyncEventHandler<ListChangedEventArgs<T>>? ListChanged;

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ObservableList{T}"/>
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Adds an item to the <see cref="ObservableList{T}"/>
        /// </summary>
        /// <param name="item">The object to add to the <see cref="ObservableList{T}"/></param>
        Task AddAsync(T item);

        /// <summary>
        /// Removes all items from the <see cref="ObservableList{T}"/>
        /// </summary>
        Task ClearAsync();

        /// <summary>
        /// Insert an instance of <typeparamref name="T"/> into the <see cref="ObservableList{T}"/>
        /// </summary>
        /// <param name="index">The insert index</param>
        /// <param name="item">The item of <typeparamref name="T"/> to insert</param>
        Task InsertAsync(int index,
                         T item);

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="ObservableList{T}"/>
        /// </summary>
        /// <param name="item">The object to remove from the <see cref="ObservableList{T}"/></param>
        /// <returns> true if item was successfully removed from the <see cref="ObservableList{T}"/> otherwise, false.
        /// This method also returns false if item is not found in the original <see cref="ObservableList{T}"/>
        /// </returns>
        Task<bool> RemoveAsync(T item);

        /// <summary>
        /// Removes the <see cref="ObservableList{T}"/> item at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the item to remove.</param>
        Task RemoveAtAsync(int index);
    }
}