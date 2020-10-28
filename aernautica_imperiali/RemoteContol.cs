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

        public bool MoveUp() {
            if (Map.GetInstance().IsMoveLegal(_plane, EOrientation.NORTH)) {
                MoveUpCommand up = new MoveUpCommand(_plane);
                _commands.Push(up);
                _commands.Peek().Process();
                _history.Clear();
                return true;
            }

            return false;
        }

        public bool MoveDown() {
            if (Map.GetInstance().IsMoveLegal(_plane, EOrientation.SOUTH)) {
                MoveDownCommand down = new MoveDownCommand(_plane);
                _commands.Push(down);
                _commands.Peek().Process();
                _history.Clear();
                return true;
            }

            return false;
        }

        public bool MoveLeft() {
            if (Map.GetInstance().IsMoveLegal(_plane, EOrientation.WEST)) {
                MoveLeftCommand left = new MoveLeftCommand(_plane);
                _commands.Push(left);
                _commands.Peek().Process();
                _history.Clear();
                return true;
            }

            return false;
        }

        public bool MoveRight() {
            if (Map.GetInstance().IsMoveLegal(_plane, EOrientation.EAST)) {
                MoveRightCommand right = new MoveRightCommand(_plane);
                _commands.Push(right);
                _commands.Peek().Process();
                _history.Clear();
                return true;
            }

            return false;
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