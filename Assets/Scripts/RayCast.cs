using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Windows;

public class RayCast : MonoBehaviour
{
    private float _input;
    private Ray _rayon;
    private bool _hitObject;
    private RaycastHit _hit;
    private ReactInteract _reactInstance;
    [SerializeField] GameObject _paint;

    void Update()
    {
        Ray _rayon = new Ray(transform.position, transform.forward);
        bool _hitObject = Physics.Raycast(_rayon, out _hit) && _hit.collider.CompareTag("Paint");
        Debug.DrawRay(transform.position, transform.forward);
        if (_input > 0.5 && _hitObject)
        {
            _reactInstance = _hit.collider.GetComponent<ReactInteract>();

            if (_reactInstance != null)
            {
                _reactInstance.React();
            }
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<float>();
    }
}

