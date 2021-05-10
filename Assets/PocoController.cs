using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocoController : MonoBehaviour
{
    public float pitchSpeed;
    public float yawSpeed;
    public float rollSpeed;
    public float accelerator = 50;
    public float deccelerator = 50;
    public float bulletOffset = 10;
    public Object bullet1;
    public GameObject bulletSpawnPoint;
    public GameObject target;

    private Rigidbody pocoRB;
    private RaycastHit hit;

    private void Start()
    {
        pocoRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float lift = Input.GetAxis("Vertical");
        float roll = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Pitch");
        float yaw = Input.GetAxis("Yaw");

        pocoRB.AddRelativeTorque(Vector3.forward * pitch * pitchSpeed * Time.deltaTime);
        pocoRB.AddRelativeTorque(Vector3.up * yaw * yawSpeed * Time.deltaTime);
        pocoRB.AddRelativeTorque(Vector3.right * roll * rollSpeed * Time.deltaTime);

        if (Input.GetButton("Accelerate"))
        {
            pocoRB.AddRelativeForce(Vector3.left * accelerator * Time.deltaTime);
        } else if (Input.GetButton("Deccelerate")) {
            pocoRB.AddForce(-pocoRB.velocity * deccelerator * Time.deltaTime);
        }

        
        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
            {
                Instantiate(target, hit.point, new Quaternion());
            }
            Instantiate(bullet1, bulletSpawnPoint.transform.position, transform.rotation);
            
        }

    }
}
