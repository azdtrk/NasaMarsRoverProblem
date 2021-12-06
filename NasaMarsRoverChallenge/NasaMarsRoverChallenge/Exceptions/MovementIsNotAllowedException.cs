using System;

namespace NasaMarsRoverChallenge.Exceptions
{
    public class MovementIsNotAllowedException : Exception
    {
        public MovementIsNotAllowedException() : base("Movement is not allowed since it will cause the rover to exceed the plateau boundaries.") { }
    }
}
