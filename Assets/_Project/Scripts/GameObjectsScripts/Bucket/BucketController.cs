using UnityEngine;
using Zenject;

namespace GameObjectsScripts
{
    public class BucketController
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
            _bucketView.UpdateGrid(_bucket.Grid);
            _bucket.BucketChanged += OnBucketChanged;
            _bucketView.Dispose += Dispose;
            Debug.Log(_bucket.ToString());
        }
        private void OnBucketChanged()
        {
            _bucketView.UpdateGrid(_bucket.Grid);
        }

        private void Dispose()
        {
            _bucket.BucketChanged -= OnBucketChanged;
            _bucketView.Dispose -= Dispose;
        }
    }
}