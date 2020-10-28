using System.Collections.Generic;

namespace aernautica_imperiali {
    public class RemoteContol {
        private APlane _plane;
        private Stack<ACommand> _commands;
        private Stack<ACommand> _history;

        public RemoteContol(APlane plane) {
            _plane = plane;
            _commands = new Stack<ACommand>();
            _history = new Stack<ACommand>();
        }

       

        public bool Do() {
            if (_history.Count > 0) {
                _history.Peek().Process();
                _commands.Push(_history.Peek());
                _history.Pop();
                return true;
            }
            
            return false;
        }

        public bool Undo() {
            if (_commands.Count > 0) {
                _commands.Peek().Undo();
                _history.Push(_commands.Peek());
                _commands.Pop();
                return true;
            }
            return false;
        }
    }
}