using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numobjectstest : MonoBehaviour
{

    public GameObject newCube;
    // Start is called before the first frame update
    void Start()
    {
        newCube = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(newCube);
    }
}
