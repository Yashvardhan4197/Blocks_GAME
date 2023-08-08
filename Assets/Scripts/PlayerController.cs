using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //RigidBody allows physics on the player-
    public Rigidbody2D rigidbody2D1;
    //To get Gane Won UI 
    public GameObject GameWonPanel;
    //Dont work
    public GameObject PausePanel;
    //Didnt work
    public GameObject GameEndPanel;
    //When lost game then
    public GameObject GameLostPanel;
    //To get speed of the player, it is set in movement section in update function
    public float speed;
    //allows when to end the game if true
    private bool gameStat=false;



    // Start is called before the first frame update
    void Start()
    {
        GameWonPanel.SetActive(false);
    }
   
    // Update is called once per frame
    void Update()
    {
        //to end the game and movement-
        if(gameStat==true)
        {
            return;
        }
        if(Input.GetKey("q"))
        {
            Application.Quit();
            return;
        }
        //to stop player from moving/break
        if(Input.GetKey("space"))
        {
            rigidbody2D1.velocity=new Vector2(0,0);
        }
        else
        {
            if(Input.GetAxis("Horizontal")>0)
            {
                rigidbody2D1.velocity= new Vector2(speed,0);
            }
            else if(Input.GetAxis("Horizontal")<0)
            {
                rigidbody2D1.velocity=new Vector2(-speed,0);
            }

                if(Input.GetAxis("Vertical")>0)
                {
                    rigidbody2D1.velocity=new Vector2(0,speed);
                }
                else if(Input.GetAxis("Vertical")<0)
                {
                    rigidbody2D1.velocity=new Vector2(0,-speed);
                }
            //stop moving when input is Null-
            else if(Input.GetAxis("Horizontal")==0 && Input.GetAxis("Vertical")==0)
            {
                rigidbody2D1.velocity=new Vector2(0,0);
            }
        }
    }
    //On trigger entered do this-
 private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Door")
        {
        Debug.Log("level Cmplte");
        GameWonPanel.SetActive(true);
        rigidbody2D1.velocity=new Vector2(0f,0f);
        gameStat=true;
        }


        if(other.tag=="walls")//tagged walls
        {
            Debug.Log("Collision Failed");
        }
        if(other.tag=="Enemy")//tagged enemies and called lost UI
        {
            Debug.Log("Collision Failed");
            GameLostPanel.SetActive(true);
            gameStat=true;
            rigidbody2D1.velocity=new Vector2(0f,0f);
        }
    }

    public void Nextlevel() // Next Level Button code
    {
        //if on last level then 
        if(SceneManager.GetActiveScene().buildIndex==SceneManager.sceneCountInBuildSettings-1)
        {
            SceneManager.LoadScene(0);
        }
        else
        {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
    //restart level button
    public void RestartLevel()
    {
        SceneManager.LoadScene(0);
    }
}