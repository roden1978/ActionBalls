using System;
using StaticData;

namespace GameObjectsScripts
{
    public class Cell : ICell
    {
        public event Action<int> IndexChanged; 
        public int Index { get; private set; }
        public bool isEmpty => _ball == null;
        
        private readonly Ball _ball;
        public Cell(int id, Ball ball = null)
        {
            Index = id;
            _ball = ball;
        }

        public void UpdateIndex(int newIndex)
        {
            Index = newIndex;
            IndexChanged?.Invoke(newIndex);
        }

        public IReadOnlyBall ReadOnlyBall => _ball;
    }
}