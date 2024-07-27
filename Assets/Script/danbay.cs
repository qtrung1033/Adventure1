using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danbay : MonoBehaviour
{
    
    private int currentBullets;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 6f * Time.deltaTime);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head")
        {
            Destroy(gameObject);
        }

    }
}
