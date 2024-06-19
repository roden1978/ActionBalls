using System.Collections.Generic;
using Zenject;

namespace GameObjectsScripts
{
    public class BucketController : IInitializable
    {
        private readonly BucketView _bucketView;
        private readonly Bucket _bucket;

        public BucketController(Bucket bucket, BucketView bucketView)
        {
            _bucket = bucket;
            _bucketView = bucketView;
        }

        public void Initialize()
        {
            _bucket.Initialize();
            _bucketView.UpdateGrid(_bucket.Grid);
            _bucket.BucketChanged += OnBucketChanged;
            _bucketView.Dispose += Dispose;
        }

        private void OnBucketChanged(IEnumerable<Row> grid)
        {
            _bucketView.UpdateGrid(grid);
        }

        private void Dispose()
        {
            _bucket.BucketChanged -= OnBucketChanged;
            _bucketView.Dispose -= Dispose;
        }
    }
}