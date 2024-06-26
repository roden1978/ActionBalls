using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Infrastructure.Factories;
using Infrastructure.Services;
using StaticData;
using UnityEngine;
using Zenject;

namespace GameObjectsScripts
{
    public class Bucket : IInitializable
    {
        public IEnumerable<Row> Grid => _repository.GetAll();
        public event Action BucketChanged;
        private Repository<Row> _repository;
        private readonly DeviceInfo _deviceInfo;
        private readonly LevelsController _levelsController;
        private readonly BallFactory _ballFactory;

        public Bucket(DeviceInfo deviceInfo, LevelsController levelsController, BallFactory ballFactory)
        {
            _deviceInfo = deviceInfo;
            _levelsController = levelsController;
            _ballFactory = ballFactory;
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
            _repository = new(CalculateBucketCapacity());
            //FillBucket();

            Debug.Log("Initialize bucket");
        }
        
        /*private async void FillBucket()
        {
            int initRowsCount = _levelsController.CurrentLevelData.RowsData.Any()
                ? _levelsController.CurrentLevelData.RowsData.Count()
                : 0;
            int startIndex;
            if (initRowsCount == 0)
                startIndex = CalculateBucketCapacity() - 1;
            else
                startIndex = CalculateBucketCapacity() - initRowsCount;

            for (int i = 0; i < startIndex; i++)
            {
                var row = new Row(i, _levelsController.CurrentLevelData.Capacity);
                for (int j = 0; j < row.Capacity; j++)
                {
                    row.AddCell(new Cell(j));
                }

                AddRow(row);
                Debug.Log(row.ToString());
            }

            for (int i = startIndex; i < CalculateBucketCapacity(); i++)
            {
                var balls = _levelsController.CurrentLevelData.RowsData.ElementAt(i - startIndex).ToArray();

                var row = new Row(i, _levelsController.CurrentLevelData.Capacity);

                for (int j = 0; j < balls.Length; j++)
                {
                    if (balls[j] == BallType.None)
                        row.AddCell(new Cell(i));
                    else
                    {
                        var newBall = await _ballFactory.CreateBall(balls.ElementAt(j));
                        row.AddCell(new Cell(i, newBall));
                    }
                }

                AddRow(row);
            }
        }*/
        private int CalculateBucketCapacity()
        {
            var width = _deviceInfo.DeviceData.ScreenWidth;
            var height = _deviceInfo.DeviceData.ScreenHeight - _deviceInfo.DeviceData.PlayerAreaHeight;

            return height / (width / _levelsController.CurrentLevelData.Capacity) + 1;
        }

        private void GenerateGrid(int width, int height)
        {
            BucketChanged?.Invoke();
        }

        public override string ToString()
        {
            return String.Join("\n", _repository.GetAll().ToString());
        }
    }
}