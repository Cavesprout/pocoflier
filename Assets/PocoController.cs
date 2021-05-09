using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocoController : MonoBehaviour
{
    public float pitchSpeed = 100;
    public float yawSpeed = 100;
    public float rollSpeed = 100;
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        
        float lift = Input.GetAxis("Vertical");
        float roll = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Pitch");
        float yaw = Input.GetAxis("Yaw");

        transform.Rotate(Vector3.forward * pitch * pitchSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * yaw * yawSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right * roll * rollSpeed * Time.deltaTime);
        

        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}
