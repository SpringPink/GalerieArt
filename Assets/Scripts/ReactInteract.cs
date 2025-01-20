using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ReactInteract : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    private float _last = -999f;
    [SerializeField] private float _cooldown = 0.5f; 

    public void React()
    {
        if (Time.time >= _last + _cooldown)
        {
            if (_text != null)
            {
                _text.enabled = !_text.enabled;
                Debug.Log("Ca va");
                _last = Time.time;
            }
        }
    }
}
