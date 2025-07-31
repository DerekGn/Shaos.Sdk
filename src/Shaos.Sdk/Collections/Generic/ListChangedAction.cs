namespace Shaos.Sdk.Collections.Generic
{
    /// <summary>
    /// The change that occurred in the <see cref="ObservableList{T}"/>
    /// </summary>
    public enum ListChangedAction
    {
        /// <summary>
        /// An item was added
        /// </summary>
        Add,
        /// <summary>
        /// The list was reset
        /// </summary>
        Reset,
        /// <summary>
        /// An item was removed
        /// </summary>
        Remove
    }
}