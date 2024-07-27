using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaivat : MonoBehaviour
{
    public float start, end, speed;
    private bool isLeft = false;
    private bool nguoichoi;
    public GameObject melon;
    public GameObject panel;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var quaivatX = transform.position.x;

        if (quaivatX <= start)
        {
            isLeft = false;
        }

        else if (quaivatX >= end)
        {
            isLeft = true;
        }

        Vector3 scale = transform.localScale;

        if (isLeft)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            scale.x = 1;

        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            scale.x = -1;
        }
        transform.localScale = scale;

      /* // var nguoichoi = player.transform.position.x;
        if(nguoichoi >= start && nguoichoi <= end)
        {
            isLeft = true;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "head")
        {
            isLeft = !isLeft;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "dan")
        {
            Destroy(gameObject);
            
            for(int i= 0; i< 2; i++)
            {
                Instantiate(melon, transform.position, Quaternion.identity);
            }
        }
   }
}