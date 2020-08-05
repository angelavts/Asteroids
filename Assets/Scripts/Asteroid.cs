using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
/// Asteroid
///</sumary>
public class Asteroid : MonoBehaviour
{   
    // constants
    const float MinImpulseForce = 0.5f;
    const float MaxImpulseForce = 1f;
    
    // prefabs to instantiate
    [SerializeField] Sprite[] asteroidSprites = new Sprite[3];
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] GameObject prefabAsteroid;
    GameObject asteroid; 
    Rigidbody2D rgb2;


    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = asteroidSprites[Random.Range(0, 3)];        
    }

    /// <summary>
	/// Initializes the object
	/// </summary>
	/// <param name="direction">Direction of moving</param>
    /// <param name="location">Initial location of the object</param>
    public void Initialize(Direction direction, Vector3 location)
    {
        // set random sprite for new asteroid		
        transform.position = location;
        float angle = Random.Range(0, 30 * Mathf.Deg2Rad);
        switch (direction){
            case Direction.Up:
                angle+=75* Mathf.Deg2Rad;
            break;
            case Direction.Left:
                angle+=165* Mathf.Deg2Rad;
            break;
            case Direction.Down:
                angle+=255* Mathf.Deg2Rad;
            break;
            case Direction.Right:
                angle+=345* Mathf.Deg2Rad;
            break;
        }
        StartMoving(angle);        
    }
    /// <summary>
	/// Move object at a specific angle
	/// </summary>
	/// <param name="angle">angle</param>
    public void StartMoving( float angle)
    {     
        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        rgb2 = GetComponent<Rigidbody2D>();
        rgb2.AddForce(magnitude * moveDirection, ForceMode2D.Impulse); 
    }
    /// <summary>
	/// Processes collisions with other game objects
	/// </summary>
	/// <param name="other">information about the other collider</param>
	void OnCollisionEnter2D(Collision2D other)
    {
        // if colliding with asteroid, destroy
        if (other.gameObject.CompareTag("Bullet"))
        {            
            Instantiate(prefabExplosion, 
                    other.gameObject.transform.position,Quaternion.identity);
            Destroy(other.gameObject.gameObject);
            AudioManager.Play(AudioClipName.AsteroidHit);
            if(transform.localScale.x < 1.5f)
            {
                Instantiate(prefabExplosion,gameObject.transform.position,Quaternion.identity);               
            }
            else
            {
                Vector3 scale = transform.localScale;
                scale.x /= 2;
                scale.y /= 2;
                transform.localScale = scale;
                asteroid = Instantiate(prefabAsteroid, transform.position, Quaternion.identity);
                asteroid.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
                asteroid = Instantiate(prefabAsteroid,  transform.position, Quaternion.identity);
                asteroid.GetComponent<Asteroid>().StartMoving(Random.Range(0, 2 * Mathf.PI));
            }
            Destroy(gameObject);
        }
    }
    
}
