using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private int Velocity = -1;
    // Update is called once per frame
    void Update()
    {
        if(transform.position.x >= 7.5f)
        {
            Velocity = -1;
        }
        if(transform.position.x <= -7.5f)
        {
            Velocity = 1;
        }
        transform.Translate(new Vector2(Velocity, 0) * 1 * Time.deltaTime);
    }
}
