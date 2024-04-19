using Common;

namespace GameObjectsScripts
{
    public class Bucket  
    {
        private Repository<Row> _repository = new();

        public Row GetRow(int id)
        {
            return _repository.Get(id);
        }

        public void AddRow(Row row)
        {
            _repository.Add(row);
        }
    }
}