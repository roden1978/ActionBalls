namespace GameObjectsScripts
{
    public class CueballController
    {
        private Cueball _cueball;
        private CueballView _cueballView;

        public CueballController(Cueball cueball, CueballView cueballView)
        {
            _cueball = cueball;
            _cueballView = cueballView;
        }
    }
}