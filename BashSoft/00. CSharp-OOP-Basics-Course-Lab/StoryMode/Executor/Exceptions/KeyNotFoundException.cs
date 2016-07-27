using System;

namespace Executor.Exceptions
{
    public class KeyNotFoundException : Exception
    {
        private const string StudentNotEnrolledInGivenCourse = "Student must be enrolled in a course before you set his mark.";

        public KeyNotFoundException()
            : base(StudentNotEnrolledInGivenCourse)
        {
        }

        public KeyNotFoundException(string message)
            : base(message)
        {
        }
    }
}
