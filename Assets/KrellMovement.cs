using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KrellMovement : MonoBehaviour
{
    public float pitchSpeed;
    public float yawSpeed;
    public float rollSpeed;
    public float accelerator = 1000;
    public float deccelerator = 50;
    public float bulletOffset = 10;

    private Rigidbody krellRB;
    private RaycastHit hit;

    // Start is called before the first frame update
    private void Start()
    {
        krellRB = GetComponent<Rigidbody>();
    }



    // Update is called once per frame
    void Update()
    {
        krellRB.AddRelativeForce(Vector3.back * accelerator * Time.deltaTime);
    }
}
