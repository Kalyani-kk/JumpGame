using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField]
    float _maxSpeed;

    Rigidbody2D _rigidbody2d;

    float _jumpForce=5f;
    [SerializeField]
    Transform _groundCheck;
    bool _grounded;
    [SerializeField]
    LayerMask _whatisGround;
    bool _doubleJump=false;
    private void Start()
    {
        _rigidbody2d=gameObject.GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        _grounded = Physics2D.OverlapCircle(_groundCheck.position, 0.1f, _whatisGround);
        if(_grounded)
        {
            _doubleJump = true;
        }
    }


    public void MovePlayerRight()
    {
        _rigidbody2d.velocity = new Vector2( _maxSpeed, _rigidbody2d.velocity.y);
    }
  
   public void MovePlayerLeft()
    {
        _rigidbody2d.velocity = new Vector2( _maxSpeed*(-1), _rigidbody2d.velocity.y);
    }

    public void PlayerJump()
    {
        if(_grounded)
        {
        _rigidbody2d.AddForce(Vector2.up *_jumpForce, ForceMode2D.Impulse);
            _grounded = false;
            _doubleJump = true;
        } else if(!_grounded && _doubleJump)
        {
            _rigidbody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _doubleJump = false;
        }

      
    }

}


