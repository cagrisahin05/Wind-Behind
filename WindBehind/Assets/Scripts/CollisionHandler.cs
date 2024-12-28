using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;

    private void OnTriggerEnter(Collider other)
    {
        if (destroyVFX != null)
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("destroyVFX nesnesi atanmadı!");
        }
        Destroy(this.gameObject);
    }
}

