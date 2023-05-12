using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float upForce = 100f;
    [SerializeField] GameObject parentObj;


 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        parentObj = GameObject.Find("GameObject");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            rb.AddForce(new Vector3(0,upForce,0));
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.name == "Floor")
            transform.SetParent(parentObj.transform);
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == "Floor")
            transform.SetParent(null);
    }
}

