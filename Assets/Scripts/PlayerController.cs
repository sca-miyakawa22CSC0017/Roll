using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    public float speed = 20; //動く速さ
    public Text scoreText; //スコアのUI
    public Text winText; //リザルトのUI
    public float jumpPower;
    
    int itemcount;

    private Rigidbody rb; // Rigidbody  
    private int score; //スコア
    private bool isJumping = false;

    void Start()
    {
        // Rigidbodyを取得
        rb = GetComponent<Rigidbody>();

        //UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";
        itemcount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);


        //Rigidbodyに力を与えて玉を動かす
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

    //球がほかのオブジェクトにぶつかったときに呼び出される    
    void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトにぶつかったときに呼び出される
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //スコアを加算します
            score = score + 1;

            //UIの表示を更新します
            SetCountText();
        }
       if(other.gameObject.CompareTag("Player"))
        {
            //if文も真:Trueの場合の処理

            //接触した相手オブジェクトを非アクティブ(非表示)
            other.gameObject.SetActive(false);

            //GETした(非表示にした)個数をそのたびに加算
            itemcount += 1;
        }
       //接触したオブジェクトのタグがRetryBoardかを比較
       else if(other.gameObject.CompareTag("RetryBoard"))
        {
            //if文が真:Trueの場合の処理

            //Sceneを再読み込み
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //UIの表示を更新する
    void SetCountText()
    {
        //スコアの表示を更新
        scoreText.text = "count: " + score.ToString();

        //すべての収集アイテムを獲得した場合
        if(score >=12)
        {
            //リザルトの表示を更新
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

