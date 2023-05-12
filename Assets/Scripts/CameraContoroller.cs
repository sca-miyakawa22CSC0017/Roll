using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour
{ 

    public GameObject player; //玉のオブジェクト

    private Vector3 offset; //玉からカメラまでの距離

    void Start()
    {
        offset = transform.position - player.transform.position;
    }   

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
