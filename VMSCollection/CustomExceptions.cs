using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMSCollection {
    class CustomExceptions {
        public class MissingCriticalFieldException : Exception {
            public MissingCriticalFieldException() { }
            public MissingCriticalFieldException(string message)
                : base(message) { }
            public MissingCriticalFieldException(string message, Exception inner)
                : base(message, inner) { }
        }

        public class WrongPasswordException : Exception {
            public WrongPasswordException() { }
            public WrongPasswordException(string message)
                : base(message) { }
            public WrongPasswordException(string message, Exception inner)
                : base(message, inner) { }
        }

        public class UserNotFoundException : Exception {
            public UserNotFoundException() { }
            public UserNotFoundException(string message)
                : base(message) { }
            public UserNotFoundException(string message, Exception inner)
                : base(message, inner) { }
        }

        public class DuplicateUserException : Exception {
            public DuplicateUserException() { }
            public DuplicateUserException(string message)
                : base(message) { }
            public DuplicateUserException(string message, Exception inner)
                : base(message, inner) { }
        }
    }
}
