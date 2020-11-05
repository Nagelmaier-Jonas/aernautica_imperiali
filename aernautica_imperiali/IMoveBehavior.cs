namespace aernautica_imperiali{
    public interface IMoveBehavior {

        void Move(Plane plane, Point destination, int speedChange);

        void Fire(Plane plane,Plane target, Weapon weapon);
    }
}