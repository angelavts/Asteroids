using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<sumary>
/// Asteroid spawner
///</sumary>
public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] GameObject prefabAsteroid;
    GameObject asteroid; 
    Vector3 locateAsteroid;
    float ccRadius; 

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        locateAsteroid.x = 0;
        locateAsteroid.y = 0;
        locateAsteroid.z = -Camera.main.transform.position.z;
        asteroid = Instantiate(prefabAsteroid);
        ccRadius = asteroid.GetComponent<CircleCollider2D>().radius; 
        Destroy(asteroid);

        asteroid = Instantiate(prefabAsteroid);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Left,
         new Vector3(ScreenUtils.ScreenRight + ccRadius, 0 , -Camera.main.transform.position.z));

        asteroid = Instantiate(prefabAsteroid);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Right,
         new Vector3(ScreenUtils.ScreenLeft - ccRadius, 0 , -Camera.main.transform.position.z));

        asteroid = Instantiate(prefabAsteroid);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Down,
         new Vector3(0, ScreenUtils.ScreenTop + ccRadius, -Camera.main.transform.position.z));

         asteroid = Instantiate(prefabAsteroid);
        asteroid.GetComponent<Asteroid>().Initialize(Direction.Up,
         new Vector3(0, ScreenUtils.ScreenBottom - ccRadius, -Camera.main.transform.position.z));
        
    }
}
