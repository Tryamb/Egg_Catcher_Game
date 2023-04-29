using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EggScorePrint : MonoBehaviour
{
    public GameObject gameview;
    public GameObject gameview_inside;
    public float storetime;
    public Image healthBar;
    float health, maxhealth = 100;
    float lerpSpeed;
    public GameObject script;
    // Start is called before the first frame update
    void Start()
    {
        gameview_inside.SetActive(false);
        storetime = Time.time;
        health = maxhealth;
        script.SetActive(true);
    }
    private int score = 0;
    public Text Scoreprint; // these are for printing result of game at runtime
    public Text result;
    public Text printtime;
    public Text waiting;
    public Text result1;
    public Text message;
    public float endtime = 90.0f;
    public float time2 = 5.0f; 
    public string str1;
    public string str2;
    public GameObject GameOver;
    
    public void game_over()
    {
        gameview.SetActive(false);
        GameOver.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D other)
    { if (other.gameObject.tag == "Egg" && endtime>0)
        {
            Destroy(other.gameObject);
             score += 2;
        }
        
       if (other.gameObject.tag == "orange" && endtime > 0)
       {
            Destroy(other.gameObject);
             score += 1;
       }  
      if(other.gameObject.tag == "bomb" && endtime>0)
      {
            Destroy(other.gameObject);
            health -= 25;
      }
        if (other.gameObject.tag == "Life" && endtime > 0)
        {
            Destroy(other.gameObject);
            health = 100;
            endtime = 90.0f;
        }
    }
    // Update is called once per frame
    void Update()
    {    
         Scoreprint.text = score.ToString();
        lerpSpeed = 3f * Time.deltaTime;
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxhealth),lerpSpeed);
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxhealth));
        healthBar.color = healthColor;
        // Debug.Log(score);
        if (Time.time > storetime && endtime > 0)   //time1 = 1 (timer will run 1 s to 150 s)
        {
            storetime += 1;
            endtime -= 1;
            printtime.text = endtime.ToString();
            if(endtime==0)
            {
                script.SetActive(false);
            }
            
        }
            if (time2 > 0)
            {
                if (Time.time > storetime && endtime <= 0)                              //all printing condition constrain                                                                                 
                {
                    storetime += 1;
                    time2 -= 1;//waiting time decreases
                    result.text = "YOUR SCORE : " + score.ToString();
                    gameview_inside.SetActive(true);

                if (score >=25)
                  {
                  
                    result1.text = "YOU WON";
                  }

                str1 = "Please wait "+ time2.ToString()+" seconds";
                    str2 = " time up !now basket willn't collect any of items";     //prints message
                    waiting.text = str1.ToString();
                
                    message.text = str2.ToString();
                }
            }      
            if ((endtime <= 0 && score <25) || (health==0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
    }
    public void res()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
}
