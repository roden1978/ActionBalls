using Data;
using GameObjectsScripts;
using StaticData;
using Zenject;

namespace Infrastructure.Factories
{
    public class BallFactory
    {
        private readonly DiContainer _diContainer;
        public BallFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }
        public IReadOnlyBall CreateBall(BallStaticData ballStaticData, BallView ballView)
        {
            return new Ball(new BallData(ballStaticData));
        }
    }
}