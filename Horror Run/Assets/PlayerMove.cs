using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanMove
{
    void SetCantMove();
}

public class PlayerMove : MonoBehaviour , ICanMove
{
    [SerializeField] private float _speed;
    private Animator _animator;
    private FloatingJoystick _floatingJoystick;
    private Rigidbody _rigidbody;
    private bool _isCanMove;
    private CharacterController _characterController;
    private Vector3 moveVector;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _isCanMove = true;
        _floatingJoystick = FindObjectOfType<FloatingJoystick>();
      
        _animator = GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        Move();
    }

    private void Move()
    {

        if (_characterController.isGrounded == false)
        {
            moveVector.y += -15 * Time.deltaTime;
        }

        if (_isCanMove)
        {
            moveVector = new Vector3(_floatingJoystick.Horizontal * _speed, 0, _floatingJoystick.Vertical * _speed);

           

            _characterController.Move(moveVector * Time.deltaTime);
            if (_floatingJoystick.Horizontal !=0 || _floatingJoystick.Vertical !=0)
            {
                transform.rotation = Quaternion.LookRotation(moveVector * Time.deltaTime);
                _animator.SetBool("IsMove", true);
            }
            else
            {
                _animator.SetBool("IsMove", false);
            }

            

        }

    }

    public void SetCantMove()
    {
        _isCanMove = false;
        _animator.SetTrigger("Fall");
    }
}
