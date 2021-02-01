namespace DotNetCenter.Core
{
    /// <summary>
    /// Interface for Include State of object
    /// </summary>
    public interface ObjectState
    {
        /// <summary>
        /// Get State of The Object
        /// </summary>
        CommonObjectStates State { get; }
        /// <summary>
        /// Change current state of The Object
        /// </summary>
        /// <param name="state">The New State</param>
        /// <returns></returns>
        bool ChangeObjectState(CommonObjectStates state);
    }
}