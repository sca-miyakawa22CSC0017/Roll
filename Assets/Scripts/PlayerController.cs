using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 20; //��������
    public Text scoreText; //�X�R�A��UI
    public Text winText; //���U���g��UI
    public float jumpPower;
    
    int itemcount;

    private Rigidbody rb; // Rigidbody  
    private int score; //�X�R�A
    private bool isJumping = false;

    void Start()
    {
        // Rigidbody���擾
        rb = GetComponent<Rigidbody>();

        //UI��������
        score = 0;
        SetCountText();
        winText.text = "";
        itemcount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //�J�[�\���L�[�̓��͂��擾
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //�J�[�\���L�[�̓��͂ɍ��킹�Ĉړ�������ݒ�
        var movement = new Vector3(moveHorizontal, 0, moveVertical);


        //Rigidbody�ɗ͂�^���ċʂ𓮂���
        rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space)&& !isJumping)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumping = true;
        }

        if(transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    //�����ق��̃I�u�W�F�N�g�ɂԂ������Ƃ��ɌĂяo�����    
    void OnTriggerEnter(Collider other)
    {
        //�Ԃ������I�u�W�F�N�g�ɂԂ������Ƃ��ɌĂяo�����
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //���̎��W�A�C�e�����\���ɂ��܂�
            other.gameObject.SetActive(false);

            //�X�R�A�����Z���܂�
            score = score + 1;

            //UI�̕\�����X�V���܂�
            SetCountText();
        }
       if(other.gameObject.CompareTag("Player"))
        {
            //if�����^:True�̏ꍇ�̏���

            //�ڐG��������I�u�W�F�N�g���A�N�e�B�u(��\��)
            other.gameObject.SetActive(false);

            //GET����(��\���ɂ���)�������̂��тɉ��Z
            itemcount += 1;
        }
       //�ڐG�����I�u�W�F�N�g�̃^�O��RetryBoard�����r
       else if(other.gameObject.CompareTag("RetryBoard"))
        {
            //if�����^:True�̏ꍇ�̏���

            //Scene���ēǂݍ���
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //UI�̕\�����X�V����
    void SetCountText()
    {
        //�X�R�A�̕\�����X�V
        scoreText.text = "count: " + score.ToString();

        //���ׂĂ̎��W�A�C�e�����l�������ꍇ
        if(score >=12)
        {
            //���U���g�̕\�����X�V
            winText.text = "You win!";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}

