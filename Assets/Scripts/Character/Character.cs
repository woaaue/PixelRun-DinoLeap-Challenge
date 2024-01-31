using UnityEngine;

public sealed class Character : MonoBehaviour, IJumpable
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _jumpForce;
    private bool _isJump;

    private void CharacterJump()
    {
        if (!_isJump)
        {
            _isJump = true;
            _animator.SetBool("isJump", _isJump);
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, _jumpForce), ForceMode2D.Force);
        }
    }

    void IJumpable.Jump()
    {
        CharacterJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_layerGround & (1 << collision.gameObject.layer)) != 0)
        {
            _isJump = false;
            _animator.SetBool("isJump", _isJump);
        }

    }
}
