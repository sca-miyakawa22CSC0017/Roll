using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoroller : MonoBehaviour
{ 

    public GameObject player; //�ʂ̃I�u�W�F�N�g

    private Vector3 offset; //�ʂ���J�����܂ł̋���

    void Start()
    {
        offset = transform.position - player.transform.position;
    }   

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
