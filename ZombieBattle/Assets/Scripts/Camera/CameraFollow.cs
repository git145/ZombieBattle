using UnityEngine;

namespace ZombieBattle.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform _target;

        public float _speed = 10f;

        private Vector3 _offsetFromTarget;

        void Start ()
        {
            CalculateInitialOffsetFromTarget();
        }

        void FixedUpdate ()
        {
            MoveCameraToNextPosition();
        }

        private void CalculateInitialOffsetFromTarget()
        {
            _offsetFromTarget = transform.position - _target.position;
        }

        private void MoveCameraToNextPosition()
        {
            transform.position = Vector3.Lerp(transform.position, GetNextCameraPosition(), _speed * Time.deltaTime);
        }

        private Vector3 GetNextCameraPosition()
        {
            return _target.position + _offsetFromTarget;
        }
    }
}