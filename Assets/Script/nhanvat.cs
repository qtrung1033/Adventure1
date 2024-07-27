using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class nhanvat : MonoBehaviour
{
    public float tocdo;
    public float movemnentX;
    private Rigidbody2D rigid;
    public bool quaydau = true;
    bool isPause = false;
    private Animator anim;
    private bool grounded;
    private bool napdan;
    public GameObject danban;
    public int maxdan = 10;// Số lượng đạn tối đa ban đầu
    private int currentBullets;
    public TMP_Text txtDan;
    public GameObject DanTo; // Số lượng đạn lớn tối đa
    public AudioSource nhay;
    public AudioSource thucan;
    public AudioSource buocdi;
    public AudioSource bandan;
    public AudioSource chet;
    public GameObject melon;
    public GameObject thungvang;
    public GameObject thungbac;
    public GameObject panel;
    private int socham = 0;



    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentBullets = maxdan;
        txtDan.text = "Dan: " + maxdan;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            isPause = !isPause;
            Time.timeScale = isPause ? 0 : 1;
        }

        if (Input.GetKeyDown(KeyCode.Q) && maxdan > 0)
        {
            if (maxdan > 0)
            {
                Vector3 playerPostion = transform.position;
                playerPostion.x += 0.5f;
                playerPostion.y += -1.5f;
                Instantiate(danban, playerPostion, Quaternion.identity);
                maxdan--;
                txtDan.text = "Dan: " + maxdan;
            }
        }

        if (Input.GetKeyDown(KeyCode.E) && maxdan > 0)
        {
            if (maxdan > 0)
            {
                Vector3 playerPostion = transform.position;
                playerPostion.x += 0.5f;
                playerPostion.y += -1.5f;
                Instantiate(DanTo, playerPostion, Quaternion.identity);
                maxdan--;
                txtDan.text = "Dan: " + maxdan;
            }
        }




        /*movemnentX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movemnentX, 0f, 0f) * tocdo * Time.deltaTime;

        if (quaydau == true && movemnentX == -1)
        {
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);
            quaydau = false;
        }
        if (quaydau == false && movemnentX == 1)
        {
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            quaydau = true;
        }*/
        dichuyen();
    }
    private void dichuyen()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(horizontalInput * tocdo, rigid.velocity.y);

        if (horizontalInput != 0)
        {
            /*buocdi.Play();*/
        }
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;

        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

    }


    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, tocdo);
        anim.SetTrigger("jump");
        grounded = false;
        nhay.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded" || collision.gameObject.tag == "thungvang" || collision.gameObject.tag == "quaduong")
            grounded = true;

        if(collision.gameObject.tag == "thungvang")
        {
            if(socham == 0)
            {
                Instantiate(melon,thungvang.transform.position, Quaternion.identity); 
                Destroy(thungvang.gameObject); 
                Instantiate(thungbac, thungvang.transform.position, Quaternion.identity); 
            }

        
        }
        if(collision.gameObject.tag == "head")
        {
            
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "napdan")
        {
            maxdan += 5;
            txtDan.text = "Dan: " + maxdan;
            thucan.Play();
        }
    }

    public void Replay()
    {
        //ten man choi hien tai
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);//nap lai man hien tai 
        Time.timeScale = 1; // kich hoat lai thoi gian
    }
}


