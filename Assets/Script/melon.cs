using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class melon : MonoBehaviour
{
    private int Melon = 0;
    public AudioSource thucan;

    [SerializeField] private Text melonText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("thucan"))
        {
            Destroy(collision.gameObject);
            Melon++;
            melonText.text = "Melon: " + Melon;
            thucan.Play();
        }
    }
}
