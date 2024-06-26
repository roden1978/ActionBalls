using Data;
using StaticData;

namespace GameObjectsScripts
{
    public class CellData
    {
        public string BallType => _ball.BallType;
        private readonly BallData _ball;

        public CellData(BallData ball)
        {
            _ball = ball;
        }
    }
}