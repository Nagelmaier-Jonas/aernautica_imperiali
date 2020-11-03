namespace aernautica_imperiali{
    public class DefaultMoveBehavior : IMoveBehavior{
        public void Move(Plane plane, Point destination) {
            if(plane.IsMoveLegal(destination))
                plane.X += destination.X;
                plane.Y += destination.Y;
                plane.Z += destination.Z;
        }
    }
}