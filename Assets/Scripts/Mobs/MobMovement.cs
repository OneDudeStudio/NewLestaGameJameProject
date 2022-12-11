using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MobMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;
    
    [SerializeField] private float _rotationSpeed;

    private float _speed = 2f;
    private const float Distance = 1.5f;
    
    private NavMeshAgent _navMeshAgent;

    private Vector3 _targetPoint;
    private int _targetPointIndex;

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
        Patrol();
    }
    
    public void Patrol()
    {
        if (_targetPoints.Count <= 0)
            return;
        StartCoroutine(PatrolCoroutine());
        MoveToPoint(_targetPoints[_targetPointIndex].position);
    }
    
    private IEnumerator PatrolCoroutine()
    {
        yield return new WaitUntil(() 
            => IsDistanceReached(transform.position,_targetPoints[_targetPointIndex].position, Distance));
        
        if (_targetPointIndex + 1 != _targetPoints.Count)
        {
            _targetPointIndex++;
            Patrol();
        }
        else
            Stop();
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
}
