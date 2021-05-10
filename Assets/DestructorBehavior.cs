using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructorBehavior : MonoBehaviour
{
    public float maxLifetime = 10;
    public float bulletSpeed = 5000;

    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = maxLifetime;
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
            transform.Translate(Vector3.left * bulletSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.collider.name);
    }
}
