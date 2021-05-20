using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorBehavior : MonoBehaviour
{
    public float maxLifetime = 10;
    public float bulletSpeed = 5000;

    private float lifetime;
    //private Rigidbody destructorRB;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = maxLifetime;
        //destructorRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        } else
        {
            lifetime--;
            //destructorRB.AddRelativeForce(Vector3.left * bulletSpeed * Time.deltaTime);
            this.transform.Translate(Vector3.forward * bulletSpeed);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.collider.name);
    }
}
