using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField, Range(0.1f, 9f)] private float _sensitivity = 2f;

    [Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation hoes above 90°.")]
    [SerializeField, Range(0f, 90f)] private float _yRotationLimit = 88f;

    private Vector2 _rotation;

    private void OnEnable()
    {
        _rotation = Vector2.zero;
    }

    private void Update()
    {
        _rotation.x += Input.GetAxis(AxisNames.MouseHorizontal) * _sensitivity;

        _rotation.y += Input.GetAxis(AxisNames.MouseVertical) * _sensitivity;
        _rotation.y = Mathf.Clamp(_rotation.y, -_yRotationLimit, _yRotationLimit);

        var xQuaternion = Quaternion.AngleAxis(_rotation.x, Vector2.up);
        var yQuaternion = Quaternion.AngleAxis(_rotation.y, Vector3.left);

        _camera.transform.localRotation = yQuaternion;
        transform.localRotation = xQuaternion;
    }
}
