namespace aernautica_imperiali {
    public interface ICommand {
        void Process();
        void Undo();
    }
}