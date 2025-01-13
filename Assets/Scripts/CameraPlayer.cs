using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private float _distancePlayer;
    private Vector2 _input;
    [SerializeField] private MouseSensi _mouseSensi;
    private CameraRota _cameraRota;
    [SerializeField] private CameraAngle _cameraAngle;

    private void Awake()
    {
        _distancePlayer = Vector3.Distance(transform.position, _player.position);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
    }

    private void Update()
    {
        _cameraRota.yaw += _input.x * _mouseSensi.horizontal * Time.deltaTime;
        _cameraRota.pitch += _input.y * -_mouseSensi.vertical * Time.deltaTime;
        _cameraRota.pitch = Mathf.Clamp(_cameraRota.pitch, _cameraAngle.min, _cameraAngle.max);
    }

    private void LateUpdate()
    {
        transform.eulerAngles = new Vector3(_cameraRota.pitch, _cameraRota.yaw, 0.0f);
        transform.position = _player.position - transform.forward * _distancePlayer;
    }
}

[Serializable]
public struct MouseSensi
{
    public float horizontal;
    public float vertical;
}

public struct CameraRota
{
    public float pitch;
    public float yaw;
}

[Serializable]
public struct CameraAngle
{
    public float min;
    public float max;
}