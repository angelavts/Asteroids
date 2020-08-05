using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    float ccRadius;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        ccRadius = GetComponent<CircleCollider2D>().radius; 
        ScreenUtils.Initialize();
    }
    ///<sumary>
    /// OnBecameInvisible of the GameObject
    ///</sumary>
    void OnBecameInvisible()
    {
        Vector2 position = transform.position;

        // check left, right, top, and bottom sides
        if (position.x + ccRadius < ScreenUtils.ScreenLeft ||
            position.x - ccRadius > ScreenUtils.ScreenRight)
        {
            position.x *= -1;
        }
        if (position.y - ccRadius > ScreenUtils.ScreenTop ||
            position.y + ccRadius < ScreenUtils.ScreenBottom)
        {
            position.y *= -1;
        }
        // move ship
        transform.position = position;
    }
}
