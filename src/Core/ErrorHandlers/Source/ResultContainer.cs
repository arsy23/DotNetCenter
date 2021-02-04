namespace DotNetCenter.Core.ErrorHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    public class ResultContainer
    {
        public ResultContainer(bool succeeded, IEnumerable<string> errors)
        {
            Succeeded = succeeded;
            Errors = errors.ToArray();
        }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public static ResultContainer Success()
            => new ResultContainer(true, new string[] { });
        public static ResultContainer Failure(IEnumerable<string> errors)
            => new ResultContainer(false, errors);
    }
}
