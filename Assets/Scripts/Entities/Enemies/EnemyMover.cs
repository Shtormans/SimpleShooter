using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _movementSpeed = 5f;
    [SerializeField, Range(0f, 100f)] private float _movingUpSpeed = 10f;
    [SerializeField] private Transform _target;

    private Rigidbody _rigidbody;

    [SerializeField] public Transform Target { set => _target = value; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * Mathf.Abs(_target.position.x - transform.position.x), Color.white);

        if (CanSeeTarget())
        {
            Debug.DrawLine(transform.position, _target.position, Color.green);
            MoveToTarget();
        }
        else if (SeeObstacleForward())
        {
            Debug.DrawLine(transform.position, _target.position, Color.red);
            AvoidObstacle();
        }
        else
        {
            Debug.DrawLine(transform.position, _target.position, Color.black);
            MoveForward();
        }

        RotateTowardsTarget();
    }

    private bool CanSeeTarget()
    {
        return Physics.Linecast(transform.position, _target.position, out RaycastHit hit)
            && hit.collider.gameObject != transform.gameObject;
    }

    private bool SeeObstacleForward()
    {
        return Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, Mathf.Abs(_target.position.x - transform.position.x));
    }

    private void MoveToTarget()
    {
        var newPosition = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _movementSpeed);
        
        _rigidbody.MovePosition(newPosition);
    }

    private void AvoidObstacle()
    {
        var newPosition = transform.position + transform.up * _movingUpSpeed * Time.deltaTime;

        _rigidbody.MovePosition(newPosition);
    }

    private void MoveForward()
    {
        var newPosition = transform.position + transform.forward * _movementSpeed * Time.deltaTime;

        _rigidbody.MovePosition(newPosition);
    }

    private void RotateTowardsTarget()
    {
        Vector3 enemyLookAt = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
        Quaternion rotation = Quaternion.LookRotation(enemyLookAt - transform.position);

        transform.rotation = rotation;
    }
}
