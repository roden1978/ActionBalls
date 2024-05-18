using Data;
using StaticData;

namespace GameObjectsScripts
{
    public class CellData
    {
        public BallType BallType => _ball.BallStaticData.BallType;
        private readonly BallData _ball;

        public CellData(BallData ball)
        {
            _ball = ball;
        }
    }
}