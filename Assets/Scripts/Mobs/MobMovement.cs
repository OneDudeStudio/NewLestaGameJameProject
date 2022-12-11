using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

[RequireComponent(typeof(NavMeshAgent))]
public class MobMovement : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private float _speed = 2f;
    
    private List<Transform> _targetPoints;
    private Vector3 _targetPoint;
    private int _targetPointIndex;
    private int _shiftDirection;

    private const float Distance = 1.5f;
    
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _targetPoint = transform.position;
        _navMeshAgent.updateRotation = false;
    }
    
    public void Restart()
    {
        _targetPointIndex = 0;
        _navMeshAgent.speed = _speed;
        
        // -1 or 1
        _shiftDirection = Random.Range(0, 2) * 2 - 1;
        Patrol();
    }
    
    public void Patrol()
    {
        if (_targetPoints == null || _targetPoints.Count == 0)
            return;
        StartCoroutine(PatrolCoroutine());
        MoveToPoint(_targetPoints[_targetPointIndex].position);
    }
    
    private IEnumerator PatrolCoroutine()
    {
        yield return new WaitUntil(() 
            => IsDistanceReached(transform.position,_targetPoints[_targetPointIndex].position, Distance));

        _targetPointIndex = (_targetPointIndex + _shiftDirection) % _targetPoints.Count;

        if (_targetPointIndex < 0)
            _targetPointIndex += _targetPoints.Count;
        
        Patrol();
    }
    
    private void MoveToPoint(Vector3 position)
    {
        if (_targetPoint != position)
        {
            _navMeshAgent.SetDestination(position);
            _targetPoint = position;
        }

        RotateToPoint(_navMeshAgent.hasPath ? _navMeshAgent.path.corners[1] : _targetPoint);
    }

    private void RotateToPoint(Vector3 position)
    {
        var direction = (position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * _rotationSpeed);
    }
    
    public void Stop()
    {
        _navMeshAgent.speed = 0;
        StopAllCoroutines();
    }

    private bool IsDistanceReached(Vector3 firstPoint, Vector3 secondPoint, float distance)
    {
        return Vector3.Distance(firstPoint, secondPoint) < distance;
    }

    public void SetTargetPoints(List<Transform> targetPoints)
    {
        _targetPoints = targetPoints;
    }
}