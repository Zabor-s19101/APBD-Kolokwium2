using System;

namespace Kolokwium2.Exceptions {
    public class SomethingNotExists : Exception {
        public SomethingNotExists(string? message) : base(message) {
        }
    }
}