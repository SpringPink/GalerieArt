using UnityEngine;
using UnityEngine.Rendering;

public class AutoScalePaint : MonoBehaviour
{
    [SerializeField] private Transform _paint;
    [SerializeField] private Texture2D _paintTexture;
    private float _width;
    private float _height;
    [SerializeField] private float _diviseur;
    private Vector3 _scale;

    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();

        _width = _paintTexture.width;
        _height = _paintTexture.height;
        _scale = new Vector3(_width, _height, 10.0f);
        _paint.transform.localScale = _scale / _diviseur;
        rend.material.mainTexture = _paintTexture;
    }
}