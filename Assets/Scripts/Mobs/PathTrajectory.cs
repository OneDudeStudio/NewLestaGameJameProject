using System.Collections.Generic;
using UnityEngine;

public class PathTrajectory : MonoBehaviour
{
    [SerializeField] private List<Transform> _targetPoints;

    public List<Transform> GetTargetPoints() => _targetPoints;
}