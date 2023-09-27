using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rig;
    [SerializeField] private float _sppedFly;
    [SerializeField] private float _minimumAngle;
    [SerializeField] private float _maximumAngle;
    [SerializeField] private Transform _mainCamera;
    [SerializeField] private Transform _cameraTarget;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _rig = GetComponent<Rigidbody>();
        _mainCamera = Camera.main.transform;
        _rig.useGravity = false;
    }
      
    private void Update()
    {
        FlyEagle();
    }

    private void FlyEagle()
    {
        float aimX = Input.GetAxis("Mouse X");
        float aimY = Input.GetAxis("Mouse Y");

        _cameraTarget.rotation *= Quaternion.AngleAxis(aimX * 2, Vector3.up);
        _cameraTarget.rotation *= Quaternion.AngleAxis(-aimX * 2, Vector3.right);

        var angleX = _cameraTarget.localEulerAngles.x;
        Debug.Log(angleX);

        if (angleX > 100 && angleX < _maximumAngle)
        {
            angleX = _maximumAngle;
        }

        else if (angleX > 100 && angleX > _minimumAngle)
        {
            angleX = _minimumAngle;
        }

        _cameraTarget.localEulerAngles = new Vector3(angleX, _cameraTarget.localEulerAngles.y, 0);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _rig.velocity = Vector3.Lerp(_rig.velocity, _mainCamera.forward * _sppedFly, Time.deltaTime * 10);
        }

        else
        {
            _rig.velocity = Vector3.Lerp(_rig.velocity, Vector3.zero, Time.deltaTime * 10);
        }

        _rig.angularVelocity = Vector3.zero;
    }
}