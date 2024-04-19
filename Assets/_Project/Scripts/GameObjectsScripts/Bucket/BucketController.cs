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
    }
}