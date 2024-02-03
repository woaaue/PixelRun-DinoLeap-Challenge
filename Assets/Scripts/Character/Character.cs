using System;
using UnityEngine;

public sealed class Character : MonoBehaviour, IJumpable
{
    public event Action<bool> DiedCharacterEvent;

    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    [SerializeField] private Sound _soundEffects;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private Rigidbody2D _rigidbody;

    private bool _isJump;

    private void CharacterJump()
    {
        if (!_isJump)
        {
            _isJump = true;
            _soundEffects.PlaySound(0);
            _animator.SetBool("isJump", _isJump);
            _rigidbody.velocity = Vector2.up * _jumpForce;
        }
    }

    private void CharacterDeath()
    {
        _animator.SetTrigger("isDeath");
        _soundEffects.PlaySound(1);
        DiedCharacterEvent?.Invoke(true);
        Time.timeScale = 0f;
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
        else
        {
            CharacterDeath();
        }
    }
}
