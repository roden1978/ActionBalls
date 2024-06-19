using System;
using System.Collections.Generic;
using Common;
using Infrastructure.Services;

namespace GameObjectsScripts
{
    public class Bucket
    {
        private const int RowLenght = 5;
        public IEnumerable<Row> Grid => _repository.GetAll();
        public event Action<IEnumerable<Row>> BucketChanged; 
        private Repository<Row> _repository = new();
        private readonly DeviceInfo _deviceInfo;
        public Bucket(DeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

        public Row GetRow(int id)
        {
            return _repository.Get(id);
        }

        public void AddRow(Row row)
        {
            _repository.Add(row);
        }

        private void UpdateRowIndex(int newIndex)
        {
            
        }

        public void Initialize()
        {
            var width = _deviceInfo.DeviceData.ScreenWidth;
            var height = _deviceInfo.DeviceData.ScreenHeight - 200;
            
            GenerateGrid(width, height);
        }

        private void GenerateGrid(int width, int height)
        {
            
        }
    }
}