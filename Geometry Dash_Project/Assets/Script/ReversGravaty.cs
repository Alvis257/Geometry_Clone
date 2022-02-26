using UnityEngine;

public class ReversGravaty : MonoBehaviour
{
    private bool _revers;
    private float _reversGravity = -3f;
    private float _normalGravaty = 4f;
    private Rigidbody2D _gravatyRigidBody2D;

    private void Start()
    {
        _gravatyRigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collis)
    {
        if (collis.gameObject.CompareTag("ReversWorld"))
        {
            _gravatyRigidBody2D.gravityScale = _reversGravity;
            _revers = true;
        }
        else if (collis.gameObject.CompareTag("NormalWorld"))
        {
            _gravatyRigidBody2D.gravityScale = _normalGravaty;
            _revers = false;
        }
    }

    public void SetValue(bool reset)
    {
        _revers = reset;
    }

    public bool GetValue()
    {
        return _revers;
    }
}