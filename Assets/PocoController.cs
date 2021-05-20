using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocoController : MonoBehaviour
{
    public float pitchSpeed = 200;
    public float yawSpeed = 200;
    public float rollSpeed = 200;
    public float liftSpeed;
    public float accelerator = 2500;
    public float deccelerator = 500;
    public Object bullet1;
    public GameObject bulletSpawnPoint;
    public GameObject target;

    public GameObject[] ThrottleMeter;
    private short ThrottleMeterAmt = 0;
    public ParticleSystem ThrottleParticles;
    private ParticleSystem.ShapeModule ThrottleShape;
    private ParticleSystem.EmissionModule ThrottleEmmission;

    private Rigidbody pocoRB;
    private RaycastHit hit;

    private void Start()
    {
        pocoRB = GetComponent<Rigidbody>();
        ThrottleShape = ThrottleParticles.shape;
        ThrottleEmmission = ThrottleParticles.emission;
    }

    // Update is called once per frame
    void Update()
    {
        
        float lift = Input.GetAxis("Vertical");
        float roll = Input.GetAxis("Horizontal");
        float pitch = Input.GetAxis("Pitch");
        float yaw = Input.GetAxis("Yaw");

        pocoRB.AddRelativeTorque(Vector3.right * pitch * pitchSpeed * Time.deltaTime);
        pocoRB.AddRelativeTorque(Vector3.up * yaw * yawSpeed * Time.deltaTime);
        pocoRB.AddRelativeTorque(Vector3.back * roll * rollSpeed * Time.deltaTime);
        pocoRB.AddRelativeForce(Vector3.up * lift * liftSpeed * Time.deltaTime);

        /*
        if (Input.GetButton("Accelerate"))
        {
            pocoRB.AddRelativeForce(Vector3.forward * accelerator * Time.deltaTime);
        } else if (Input.GetButton("Deccelerate")) {
            pocoRB.AddForce(-pocoRB.velocity * deccelerator * Time.deltaTime);
        }
        */

        if (Input.GetButtonDown("Accelerate") && ThrottleMeterAmt < 6)
        {
            ThrottleMeter[ThrottleMeterAmt].SetActive(true);
            ThrottleMeterAmt++;
            ThrottleShape.angle = 3 + ThrottleMeterAmt;
            ThrottleEmmission.rateOverTime = 100 * ThrottleMeterAmt;
        }
        if (Input.GetButtonDown("Deccelerate") && ThrottleMeterAmt > 0)
        {
            
            ThrottleMeterAmt--;
            ThrottleMeter[ThrottleMeterAmt].SetActive(false);
            ThrottleShape.angle = 3 + ThrottleMeterAmt;
            ThrottleEmmission.rateOverTime = 100 * ThrottleMeterAmt;

        }
/*        if (Input.GetButtonDown("CutEngine"))
        {
            ThrottleMeterAmt = 0;
            ThrottleShape.angle = 3 + ThrottleMeterAmt;
            ThrottleEmmission.rateOverTime = 100 * ThrottleMeterAmt;
        }*/
        pocoRB.AddRelativeForce(Vector3.forward * accelerator * ThrottleMeterAmt * Time.deltaTime);



        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, Mathf.Infinity))
            {
                //Instantiate(target, hit.point, new Quaternion());
            }
            Instantiate(bullet1, bulletSpawnPoint.transform.position, transform.rotation);
            
        }

    }
}
