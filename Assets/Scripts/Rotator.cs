using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Rotator : MonoBehaviour
{
    private int _direction;
    [SerializeField] protected float _rotSpeed;
    [SerializeField] protected Transform _body;
    private bool _canRotate = true;

    void Start()
    {
        int num = Random.Range(0, 2);
        _rotSpeed += Random.Range(-0.5f, 0.5f);
        _direction = num == 0 ? 1 : -1;
    }

    private void FixedUpdate()
    {
        if (!_canRotate)
            return;
        _body.RotateAround(_body.position, Vector3.up, _rotSpeed*_direction);
    }

    public void StopRotation() => _canRotate = false;
}
