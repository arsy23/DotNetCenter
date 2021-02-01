namespace DotNetCenter.Core
{
    /// <summary>
    /// Common Object States
    /// </summary>
    public enum CommonObjectStates
    {
        /// <summary>
        /// The Object is Unchanged
        /// </summary>
        Unchanged = 0,
        /// <summary>
        /// The Object is in Constructed state
        /// </summary>
        Constructed = 1
        /// <summary>
        /// The Object is Initialized
        /// </summary>
        Initialized = 2,
        /// <summary>
        /// The Object is Created
        /// </summary>
        Created   = 3,
        /// <summary>
        /// The Object is Modified
        /// </summary>
        Modified =  4,
        /// <summary>
        /// The Object is Attached to something
        /// </summary>
        Attached = 5,
        /// <summary>
        /// The Object is Detached from something
        /// </summary>
        Detached = 6,
        /// <summary>
        /// The Object is in Destructed state
        /// </summary>
        Destructed = 7,
        /// <summary>
        /// The Object is Deleted
        /// </summary>
        Deleted = 8
    }
}