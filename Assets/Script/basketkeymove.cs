using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basketkeymove : MonoBehaviour
{
    public GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow)&&bucket.transform.position.x>0)
        {
            gameObject.transform.position += new Vector3(-100.0f,0,0);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)&&bucket.transform.position.x<Screen.width)
        {
            gameObject.transform.position += new Vector3(100.0f,0,0);
        }
    }
}
