using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask _platformLayerMask;
    public bool isGrounded = true;
    private BoxCollider2D _boxCollider2D;
    private float Hight = 1f;

    private void Start()
    {
        _boxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void OnTriggerStay2D()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider2D.bounds.center,
            _boxCollider2D.bounds.size, 0f,
            Vector2.down, Hight, _platformLayerMask);
        isGrounded = raycastHit.collider != null;
    }

    public void OnTriggerExit2D()
    {
        isGrounded = false;
    }
}
