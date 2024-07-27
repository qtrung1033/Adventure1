using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanTo : MonoBehaviour
{
    bool isScaling = false;
    public float ScalFactor = 1.01f;
    void Start()
    {
        Destroy(gameObject,2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)&& !isScaling )
        {
            transform.localScale *= ScalFactor;

        }
        else
        {
            transform.Translate(Vector3.right*18f*Time.deltaTime);
            isScaling = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "head")
        {
            Destroy(gameObject);
        }
    }
}
