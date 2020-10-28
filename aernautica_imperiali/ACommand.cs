namespace aernautica_imperiali {
    public abstract class ACommand{
        protected APlane _plane;

        protected ACommand(APlane plane) {
            _plane = plane;
        }

        public abstract void Process();

        public abstract void Undo();
    }
}