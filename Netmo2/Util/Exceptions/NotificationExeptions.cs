using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Netmo2.Util.Exceptions
{
    public class NoContentException : Exception
    {
        public NoContentException() : base("No Content found in List!")
        {
        }

        /// <summary>
        /// Creates an Exception for no content
        /// </summary>
        /// <param name="end">
        /// Joined on the end of the message. Examples:
        /// "No Content found in " +
        ///                          "List of Announcements"
        ///                          "Dictionary of translationsin jp_JP"
        ///                          ...
        /// </param>
        public NoContentException(string end) : base("No Content found in " + end + "!")
        {
        }
    }
}
