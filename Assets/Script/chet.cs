using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class chet : MonoBehaviour
{
    private Animator amin;
    private Rigidbody2D rb;
    public GameObject panel;
    
    private void Start()
    {
        amin = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chet"))
        {
            Die();
            panel.SetActive(true);
        }
    }
    private void Die()
    {
        amin.SetTrigger("chet");
    }

    public void Replay()
    {
        //ten man choi hien tai
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);//nap lai man hien tai 
        Time.timeScale = 1; // kich hoat lai thoi gian
    }
}
