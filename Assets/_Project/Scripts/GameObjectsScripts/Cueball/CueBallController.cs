namespace GameObjectsScripts
{
    public class CueBallController
    {
        private CueBall _cueBall;
        private CueBallView _cueBallView;

        public CueBallController(CueBall cueBall, CueBallView cueBallView)
        {
            _cueBall = cueBall;
            _cueBallView = cueBallView;
        }
    }
}