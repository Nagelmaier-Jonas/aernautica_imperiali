namespace aernautica_imperiali {
    public interface ICommand {
        public abstract void Process();

        public abstract void Undo();
    }
}