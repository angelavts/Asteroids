using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Timer lifeTimer;
    float lifeTime = 2f;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if(lifeTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    /// <summary>
	/// Apply force to the object
	/// </summary>
	/// <param name="direction">Direction of the impulse</param>
    public void ApplyForce(Vector2 direction)
    {
        float magnitude=10f;
        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.Duration = lifeTime;
        GetComponent<Rigidbody2D>().AddForce(magnitude * direction, ForceMode2D.Impulse); 
        lifeTimer.Run();
    }
}
