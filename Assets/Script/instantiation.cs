using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class instantiation : MonoBehaviour
{
    public GameObject egg;
    public GameObject Canvas;
    public GameObject Bomb;
    public GameObject spawnEgg;
    public GameObject spawnBomb;
    public GameObject orange;
    public GameObject spawnorange;
    public GameObject Heart;
    public GameObject spawnHeart;
    public float storetime;
    public float Heart_initiating_time;
    // Start is called before the first frame update

    void Start()
    {
        storetime = Time.time;
        Heart_initiating_time = Time.time+50;
    }

    // Update is called once per frame
    void Update()
    {     
        if (Time.time >= storetime)
        { 
            storetime += 3;     //after every 3 second game object instantiate
            spawnEgg = Instantiate(egg, transform.position, Quaternion.identity);
            spawnEgg.transform.SetParent(Canvas.transform);
            transform.position = new Vector3(Random.Range(0.0f, Screen.width), Screen.height, 0);
            spawnBomb = Instantiate(Bomb, transform.position, Quaternion.identity);
            spawnBomb.transform.SetParent(Canvas.transform);
            transform.position = new Vector3(Random.Range(0.0f, Screen.width), Screen.height, 0);
            spawnorange = Instantiate(orange, transform.position, Quaternion.identity);
            spawnorange.transform.SetParent(Canvas.transform);
            transform.position = new Vector3(Random.Range(0.0f, Screen.width), Screen.height, 0);

           // spawnHeart = Instantiate(Heart, transform.position, Quaternion.identity);
            //spawnHeart.transform.SetParent(Canvas.transform);
            //transform.position = new Vector3(Random.Range(0.0f, Screen.width), Screen.height, 0);
              if (Time.time >= Heart_initiating_time)
              {
                  Heart_initiating_time += 40;
                  spawnHeart = Instantiate(Heart, transform.position, Quaternion.identity);
                  spawnHeart.transform.SetParent(Canvas.transform);
                 
                  transform.position = new Vector3(Random.Range(0.0f, Screen.width), Screen.height, 0);
              }
        }
        
       
    }
}

