using Zenject;

namespace GameObjectsScripts
{
    public class CueBallController : IInitializable
    {
        private readonly IReadOnlyCueBall _cueBall;
        private readonly CueBallView _cueBallView;

        public CueBallController(IReadOnlyCueBall cueBall, CueBallView cueBallView)
        {
            _cueBall = cueBall;
            _cueBallView = cueBallView;
        }

        public void Initialize()
        {
            _cueBall.HpChanged += OnHpChanged;
            _cueBallView.DestroyCueBall += Dispose;
        }

        private void OnHpChanged(float value)
        {
            _cueBallView.UpdateHpView(value);
        }
        
        private void Dispose()
        {
            _cueBall.HpChanged -= OnHpChanged;
            _cueBallView.DestroyCueBall -= Dispose;
        }
    }
}