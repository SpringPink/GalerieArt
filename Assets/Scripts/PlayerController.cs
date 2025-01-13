using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 _input;
    private Vector3 _direction;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _speed;
    private CharacterController _characterController;
    private Camera _camera;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _camera = Camera.main;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    private void Movement()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);
    }

    private void Rotation()
    {
        if (_input.sqrMagnitude ==0 ) return; // Si aucune input est entrée renvoie rien.

        _direction = Quaternion.Euler(0.0f, _camera.transform.eulerAngles.y, 0.0f) * new Vector3(_input.x, 0.0f, _input.y);
        var targetRotation = Quaternion.LookRotation(_direction, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed + Time.deltaTime);
    }

    private void Update()
    {
        Rotation();
        Movement();
    }
}
