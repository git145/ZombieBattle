using UnityEngine;

namespace ZombieBattle.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float _movementSpeed = 30f;

        public float _turnSpeed = 100f;

        private Vector3 _movementDirection;

        private Quaternion _turningDirection;

        private Rigidbody _rigidBody;

        void Awake ()
        {
            _rigidBody = GetComponent<Rigidbody>();
        }

        void FixedUpdate ()
        {
            Move();

            Turn();
        }


        void Move()
        {
            SetMovementDirection();

            UpdatePosition();
        }

        private void SetMovementDirection()
        {
            _movementDirection = transform.forward * Input.GetAxis("Vertical") * _movementSpeed * Time.deltaTime;
        }

        private void UpdatePosition() {
            _rigidBody.MovePosition(transform.position + _movementDirection);
        }

        void Turn()
        {
            SetTurningDirection();

            UpdateRotation();
        }

        private void SetTurningDirection()
        {
            _turningDirection = Quaternion.Euler(new Vector3(0, Input.GetAxis("Horizontal") * _turnSpeed * Time.deltaTime, 0));
        }

        private void UpdateRotation()
        {
            _rigidBody.MoveRotation(transform.rotation * _turningDirection);
        }
    }
}