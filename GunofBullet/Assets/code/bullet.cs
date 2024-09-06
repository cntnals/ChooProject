using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class buller : MonoBehaviour
{
    public float bulletSpeed = 10000.0f;
    private Transform thisTransform;
    private int bullet = 6;
    //private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        GetComponent<Rigidbody>().AddForce(thisTransform.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {

            //GetComponent<Rigidbody>().AddForce(thisTransform.forward * bulletSpeed);

    }
}
