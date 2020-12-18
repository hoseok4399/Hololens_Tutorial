
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

namespace Hoseok{
    public class TargetManager : Singleton<TargetManager> {
        [SerializeField]
        public ObjectPool markerPool;

        [SerializeField]
        public LayerMask layerMask;

        [Min(0.0f)]
        [SerializeField]
        public float MinSpawnThreshold = 0.5f;
        [SerializeField]
        public float MaxSpawnThreshold = 2.0f;
        [SerializeField]
        public float MinDistanceSpace = 0.5f;

        private const float MIN_RAYCAST_DISTANCE = 0.3f;
        private const float MAX_RAYCAST_DISTANCE = 10.0f;
        private const float HIT_OFFSET = 0.05f;

        private float markerTimer;
        private float markerTimeLimit;

        private float minDistanceSpaceSqr;

        // Prevent Non-singleton construction
        protected TargetManager() { }

        private void Awake() {
            Debug.Assert(MinSpawnThreshold < MaxSpawnThreshold, "MinSpawnThreshold is not less than MaxSpawnThreshold");

            markerTimeLimit = Random.Range(MinSpawnThreshold, MaxSpawnThreshold);

            minDistanceSpaceSqr = MinDistanceSpace * MinDistanceSpace;
        }

        private void Update() {
            markerTimer += Time.deltaTime;

            if (markerTimer > markerTimeLimit) {
                markerTimer = 0.0f;
                //PlaceMarker();
            }
        }

        private bool IsValidPlacement(Vector3 pos) {
            foreach (var target in markerPool.ActiveObjects) {
                if (WithinDistance(target.GetGameObject().transform.position, pos, minDistanceSpaceSqr)) {
                    return false;
                }
            }

            return true;
        }

        private static bool WithinDistance(Vector3 p1, Vector3 p2, float sqrDistance) {
            return (p1 - p2).sqrMagnitude < sqrDistance;
        }

        private static Vector3 GenerateRandomDirection(Transform transform) {
            var topDownForward = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
            var topDownRight = new Vector3(transform.right.x, 0.0f, transform.right.z);

            // Generate random raycast in 180 degree FOV of camera
            var raycastDir = Vector3.Lerp(topDownForward - topDownRight, topDownForward + topDownRight, Random.Range(0.0f, 1.0f));
            raycastDir = Vector3.Lerp(raycastDir - Vector3.up, raycastDir + Vector3.up, Random.Range(0.0f, 1.0f));

            return raycastDir;
        }

        private void PlaceTarget(IObjectPoolItem item, Vector3 placementPoint, Quaternion rotation) {
            var targetObj = item.GetGameObject();
            targetObj.transform.position = placementPoint;
            targetObj.transform.rotation = rotation;

            var target = targetObj.GetComponentInChildren<Target>(true);
            if (target != null) {
                target.Lock();
            }
        }
    }
}