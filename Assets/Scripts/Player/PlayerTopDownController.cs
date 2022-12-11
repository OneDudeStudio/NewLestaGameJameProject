using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerTopDownController : MonoBehaviour
{
    public enum CameraDirection { x, z }
    
    [Header("Настройки камеры")]
    [SerializeField]
    private CameraDirection _cameraDirection = CameraDirection.x;
    [SerializeField]
    private float _cameraHeight = 20f;
    [SerializeField]
    private float _cameraDistance = 7f;
    [SerializeField]
    private Camera _playerCamera;
    [SerializeField]
    private Transform head;
    [SerializeField]
    private Transform body;
    
    [Space]
    [SerializeField]
    private GameObject _targetIndicatorPrefab;
    
    [Header("Настройки для передвижения игрока")]
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _gravity = 14.0f;
    [SerializeField]
    private float _maxVelocityChange = 10.0f;
    [SerializeField]
    private Rigidbody _rigidbody;
    
    private GameObject _targetObject;
    private Vector2 _playerPosOnScreen;
    private Vector2 _cursorPosition;
    private Vector2 _offsetVector;
    private Plane _surfacePlane = new Plane();
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
        _rigidbody.useGravity = false;
        
        InitializeTarget();
    }
    
    void FixedUpdate()
    {
        Vector3 cameraOffset = Vector3.zero;
        
        if (_cameraDirection == CameraDirection.x)
        {
            cameraOffset = new Vector3(_cameraDistance, _cameraHeight, 0);
        }
        
        else if (_cameraDirection == CameraDirection.z)
        {
            cameraOffset = new Vector3(0, _cameraHeight, _cameraDistance);
        }
        
        Vector3 targetVelocity = Vector3.zero;
        
        if (_cameraDirection == CameraDirection.x)
        {
            targetVelocity = new Vector3(Input.GetAxis("Vertical") * (_cameraDistance >= 0 ? -1 : 1), 0, Input.GetAxis("Horizontal") * (_cameraDistance >= 0 ? 1 : -1));
        }
        
        else if (_cameraDirection == CameraDirection.z)
        {
            targetVelocity = new Vector3(Input.GetAxis("Horizontal") * (_cameraDistance >= 0 ? -1 : 1), 0, Input.GetAxis("Vertical") * (_cameraDistance >= 0 ? -1 : 1));
        }
        
        targetVelocity *= _speed;
        
        Move(targetVelocity);
        ApplyGravity();
        CameraFollow(cameraOffset);
        AimRotation();
        RotateHead();
        RotateBody();
    }

    private void Move(Vector3 targetVelocity)
    {
        Vector3 velocity = _rigidbody.velocity;
        Vector3 velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -_maxVelocityChange, _maxVelocityChange);
        velocityChange.y = 0;
        _rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void ApplyGravity()
    {
        _rigidbody.AddForce(new Vector3(0, -_gravity * _rigidbody.mass, 0));
    }

    private void CameraFollow(Vector3 cameraOffset)
    {
        _playerPosOnScreen = _playerCamera.WorldToViewportPoint(transform.position);
        _cursorPosition = _playerCamera.ScreenToViewportPoint(Input.mousePosition);
        _offsetVector = _cursorPosition - _playerPosOnScreen;
        _playerCamera.transform.position = Vector3.Lerp(_playerCamera.transform.position, transform.position + cameraOffset, Time.deltaTime * 7.4f);
        _playerCamera.transform.LookAt(transform.position + new Vector3(-_offsetVector.y * 2, 0, _offsetVector.x * 2));
    }

    private void AimRotation()
    {
        _targetObject.transform.position = GetAimTargetPos();
        _targetObject.transform.LookAt(new Vector3(transform.position.x, _targetObject.transform.position.y, transform.position.z));
    }

    private void RotateHead()
    {
        head.LookAt(new Vector3(_targetObject.transform.position.x, head.position.y, _targetObject.transform.position.z));
        
        if (Vector3.Angle(head.forward,body.forward)<70)
        {
            
           // Debug.Log(head.rotation.eulerAngles.y);
        }
        
        //head.localRotation = Quaternion.Euler(head.rotation.x ,Mathf.Clamp(head.rotation.y,-50,50),head.rotation.z);
       // head.localRotation = Quaternion.Euler(head.localRotation.x,
       //     Mathf.Clamp(head.localRotation.y, -45f, 45f) ,
       //     head.localRotation.z);
    }

    private void RotateBody()
    {
        //body.forward =_rigidbody.velocity.normalized;
        Vector3 targetVector = _rigidbody.velocity.normalized;
        Vector3 targetVectorXZ = new Vector3(targetVector.x, 0, targetVector.z);
        
        body.forward =Vector3.Lerp(body.forward,targetVectorXZ,0.1f);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position,_rigidbody.velocity);
        Gizmos.DrawRay(body.position,body.forward);
    }
    
    private void InitializeTarget()
    {
        if (_targetIndicatorPrefab)
        {
            _targetObject = Instantiate(_targetIndicatorPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }
        //Cursor.visible = false;
    }

    Vector3 GetAimTargetPos()
    {
        _surfacePlane.SetNormalAndPosition(Vector3.up, transform.position);
        Ray ray = _playerCamera.ScreenPointToRay(Input.mousePosition);
        float enter = 0.0f;

        if (_surfacePlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            return hitPoint;
        }
        
        return new Vector3(-5000, -5000, -5000);
    }
    
}