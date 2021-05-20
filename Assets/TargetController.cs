using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.collider.name);
        if (other.collider.name == "ParticleBullet(Clone)")
        {
            GetComponent<Renderer>().material = hitMaterial;
        }
    }

    public Material hitMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
