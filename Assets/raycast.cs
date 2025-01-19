using UnityEngine;

public class raycast : MonoBehaviour
{
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        bool hitObject = Physics.Raycast(ray);
        Debug.DrawRay(transform.position, transform.forward);
        if (hitObject)
        {
            Debug.Log("Objet !!!!");
        }
    }
}

