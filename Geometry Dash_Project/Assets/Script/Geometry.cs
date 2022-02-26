using UnityEngine;
using KeyCode = UnityEngine.KeyCode;

namespace Assets
{
    public class Geometry : MonoBehaviour
    {
        private Vector3 _spawnPoint;
        private Rigidbody2D _rigedbody2D;
        private float _speed;
        private float _jumpForce;
        private float _startGravaty;
        private bool _portal;
        private static bool _gamestart;
        private bool _revers;
        private PortalToFly _portalToFly;
        private ReversGravaty _reversGravaty;

        void Start()
        {
            _reversGravaty = GetComponent<ReversGravaty>();
            _portalToFly = GetComponent<PortalToFly>();
            _rigedbody2D = GetComponent<Rigidbody2D>();
            _startGravaty = _rigedbody2D.gravityScale;
            _spawnPoint = transform.position;
            _speed = 0.089f;
            _jumpForce = 15.0f;
            _revers = false;
            _gamestart = true;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
                _gamestart = true;

            if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
                jump();

            if (_gamestart)
                transform.position = new Vector3(transform.position.x + _speed, transform.position.y, 0.0f);


        }

        public void jump()
        {
            _revers = GetReversCheck();

            if (_revers)
            {
                _rigedbody2D.velocity = Vector2.down * _jumpForce;
            }
            else
            {
                _rigedbody2D.velocity = Vector2.up * _jumpForce;
            }
        }

        public bool GetReversCheck()
        {
            return _reversGravaty.GetValue();
        }

        public void Restart()
        {
            transform.position = _spawnPoint;
            _revers = false;
            _reversGravaty.SetValue(_revers);
            _portalToFly.ResetValue();
            _gamestart = false;
            _rigedbody2D.gravityScale = _startGravaty;
        }

        public bool IsGrounded()
        {
            _portal = GetPortalCheck();

            return _portal ? _portal : transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
        }

        public bool GetPortalCheck()
        {
            return _portalToFly.GetValue();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
                Restart();
        }
    }
}
