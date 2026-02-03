
namespace Shaos.Sdk.Collections.Generic
{
    /// <summary>
    /// An <see cref="EventArgs"/> event type that is raised when a <see cref="ObservableList{T}"/> changes
    /// </summary>
    /// <typeparam name="T">The item type</typeparam>
    public class ListChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Create an instance of a <see cref="ListChangedEventArgs{T}"/>
        /// </summary>
        /// <param name="action"></param>
        /// <param name="items"></param>
        public ListChangedEventArgs(ListChangedAction action,
                                    IList<T> items)
        {
            Action = action;
            Items = items;
        }

        /// <summary>
        /// The <see cref="ListChangedEventArgs{T}"/> <see cref="ListChangedAction"/>
        /// </summary>
        public ListChangedAction Action { get; }

        /// <summary>
        /// The <see cref="IList{T}"/> of items that have modified
        /// </summary>
        public IList<T> Items { get; }
    }
}
