using UnityEngine;

namespace ZombieBattle.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float _movementSpeed = 30f;

        public float _turnSpeed = 100f;

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
            _rigidBody.MovePosition(GetMovementVector());
        }

        private Vector3 GetMovementVector()
        {
            return transform.position + GetMovementWalk() + GetMovementStrafe();
        }

        private Vector3 GetMovementWalk()
        {
            return transform.forward * Input.GetAxis("Walk") * _movementSpeed * Time.deltaTime;
        }

        private Vector3 GetMovementStrafe()
        {
            return transform.right * Input.GetAxis("Strafe") * _movementSpeed * Time.deltaTime;
        }

        void Turn()
        {
            _rigidBody.MoveRotation(transform.rotation * GetTurningQuaternion());
        }

        private Quaternion GetTurningQuaternion()
        {
            return Quaternion.Euler(new Vector3(0, Input.GetAxis("Turn") * _turnSpeed * Time.deltaTime, 0));
        }
    }
}