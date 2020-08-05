using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
/// the best ship
///</sumary>
public class Ship : MonoBehaviour
{
    // constants
    const int thrustForce = 5;
    const int rotateDegreesPerSecond = 220;
    // prefabs to instantiate
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] GameObject prefabBullet;
    [SerializeField] GameObject HUB;
    
    // cached for efficiency
    Rigidbody2D rgb2;
    Vector2 thrustDirection = new Vector2(1,0);
    float thrustInput;
    float rotationInput;
    float rotationAmount;
    float rotationAngle;
    GameObject bullet;
    

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();    
    }

    /// <summary>
    ///  Update is called once per frame
    /// </summary>
    void Update()
    {    
        rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {
            // calculate rotation amount and apply rotation
            rotationAmount = rotateDegreesPerSecond * Time.deltaTime; 
            if (rotationInput < 0) 
            { 
                rotationAmount *= -1;   
            }             
            transform.Rotate(Vector3.forward, rotationAmount); 
            // calculate new  thrust directionamount and apply 
            rotationAngle = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(rotationAngle);
            thrustDirection.y = Mathf.Sin(rotationAngle); 
        }

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            AudioManager.Play(AudioClipName.PlayerShot);
            bullet = Instantiate(prefabBullet,transform.position, Quaternion.identity);
            bullet.GetComponent<Bullet>().ApplyForce(thrustDirection);
        }
                   
    }
    ///<sumary>
    /// FixedUpdate of the ship
    ///</sumary>
    void FixedUpdate()
    {
        thrustInput = Input.GetAxis("Thrust");
        if (thrustInput != 0)
        {
            rgb2.AddForce(thrustForce * thrustDirection, ForceMode2D.Force);
        }   
    }
    /// <summary>
	/// Processes collisions with other game objects
	/// </summary>
	/// <param name="other">information about the other collider</param>
	void OnCollisionEnter2D(Collision2D other)
    {
        // if colliding with asteroid, destroy
        if (other.gameObject.CompareTag("Asteroid"))
        { 
            AudioManager.Play(AudioClipName.PlayerDeath);
            HUB.GetComponent<HUB>().StopGameTimer();           
            Instantiate(prefabExplosion,  transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
