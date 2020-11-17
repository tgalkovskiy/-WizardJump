using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    private bool MovePlatform = false;
    private int Touch = 0;
    private float SpeedPlatform = 0f;
    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Touch += 1;
        if (Touch > 0)
        {
            SpeedPlatform = 0.6f;
        }
        if (Touch >= 3)
        {
            //SpeedPlatform = 9f;
            //BoxCollider2D.isTrigger = true;
        } 
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        BoxCollider2D.isTrigger = false;
        MovePlatform = true;
    }
    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * SpeedPlatform);
    }
}
