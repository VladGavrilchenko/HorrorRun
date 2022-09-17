using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 5;
    private Animator _animator;
    private Transform _playerTransformVector;
    private ICrash _iCrash;
    private NavMeshAgent _agent;
    private bool _isCanth;
    private float _distanceToPlayer;
    private bool _canMove;

    private void Start()
    {
        _canMove = true;
        _animator = GetComponentInChildren<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _playerTransformVector = FindObjectOfType<PlayerMove>().transform;
        _iCrash = FindObjectOfType<CollisionHandler>().GetComponent<ICrash>();
    }

    private void Update()
    {
        CheckeDistanceToPlayer();
        MoveToPlayer();
    }

    private void CheckeDistanceToPlayer()
    {
        _distanceToPlayer = Vector3.Distance(_playerTransformVector.position, transform.position);

        if (_distanceToPlayer <= _agent.stoppingDistance)
        {
            CanthPlayer();
        }
    }

    private void CanthPlayer()
    {
        if(_isCanth == false)
        {
            _isCanth = true;
            _animator.SetTrigger("Attack");
            _iCrash.Crash();
        }
    }


    private void MoveToPlayer()
    {
        if (_canMove)
        {
            _agent.SetDestination(_playerTransformVector.position);
            FaceTarget(_playerTransformVector.position);
        }

    }

    public void StopeMove()
    {
        _canMove = false;
        _animator.SetTrigger("Idel");
    }

    private void FaceTarget(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * _turnSpeed);
    }

    
}
