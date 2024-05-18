namespace GameObjectsScripts
{
    public class BallController
    {
        private IReadOnlyBall _ball;
        private BallView _ballView;

        public BallController(IReadOnlyBall ball, BallView ballView)
        {
            _ball = ball;
            _ballView = ballView;
        }

        public void Initialize()
        {
            _ball.HpChange += OnHpChange;
        }

        private void OnHpChange(float value)
        {
            _ballView.UpdateHpView(value);
        }

        private void Dispose()
        {
            _ball.HpChange -= OnHpChange;
        }
    }
}