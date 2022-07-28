using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roket : MonoBehaviour
{
    public float speed = 300;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 vector3 = new Vector3(0, 0, speed);
        GetComponent<Rigidbody>().AddForce(vector3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
