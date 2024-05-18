namespace GameObjectsScripts
{
    public class BallController
    {
        private Ball _ball;
        private BallView _ballView;

        public BallController(Ball ball, BallView ballView)
        {
            _ball = ball;
            _ballView = ballView;
        }
    }
}