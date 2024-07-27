using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaduong : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int diemhientai = 0;

    [SerializeField] private float tocdo = 3f;
    private void Update()
    {
        if (Vector2.Distance(waypoints[diemhientai].transform.position, transform.position) < .1f)
        {
            diemhientai++;
            if(diemhientai >= waypoints.Length)
            {
                diemhientai = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[diemhientai].transform.position, Time.deltaTime * tocdo);
    }
}
