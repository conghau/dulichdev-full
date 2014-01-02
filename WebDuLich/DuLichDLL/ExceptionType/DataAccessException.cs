using System;
using System.Runtime.Serialization;

namespace DuLichDLL.ExceptionType
{
    public class DataAccessException : ApplicationException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public DataAccessException()
            : base()
        {
        }

        /// <summary>
        /// Initializes with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public DataAccessException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.
        /// </param>
        /// <param name="exception">The exception that is the cause of the current exception.
        /// If the innerException parameter is not a null reference, the current exception
        /// is raised in a catch block that handles the inner exception.
        /// </param>
        public DataAccessException(string message, Exception exception) :
            base(message, exception)
        {
        }

        /// <summary>
        /// Initializes with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.
        /// </param>
        protected DataAccessException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }
    }
}