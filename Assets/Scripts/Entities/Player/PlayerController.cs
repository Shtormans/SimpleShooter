using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    public InventorySystem Inventory { get; private set; }
    public Vector3 HeadPosition => _camera.transform.position + _camera.transform.forward;
    public Quaternion HeadRotation => _camera.transform.rotation;

    private void Awake()
    {
        Inventory = GetComponent<InventorySystem>();
    }
}
