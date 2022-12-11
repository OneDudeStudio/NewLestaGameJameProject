using UnityEngine;

public class PathTrajectory : MonoBehaviour
{
    [SerializeField] private Transform[] _targetPoints;

    public Transform[] GetTargetPoints() => _targetPoints;
}
