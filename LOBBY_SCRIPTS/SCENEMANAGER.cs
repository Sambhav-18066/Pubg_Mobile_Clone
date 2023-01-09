using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;
using System.Threading;
using System.Timers;
using UnityEngine.UIElements;
using UnityEngine.Networking;

public class SCENEMANAGER : MonoBehaviour
{

    public int mapNumber = 2 ;
    public Text countdown;
    public InputField user;
    public TMP_Text username;
    public Canvas countdownCanvas;
    public int t;
    public int i;
    public TMP_Text fpsText;
    public AudioSource audioSource;
    public TMP_Text pingText;

   //private NetworkClient client;
   
    // Start is called before the first frame update
    void Start()
    {
        countdown.GetComponent<Text>().text = "" + i;
        countdown.GetComponent<Text>().text = "" + username;
        Canvas countdownCanvas = GetComponent<Canvas>();
        Text countdownText = GetComponent<Text>();
        username.text = user.text;
        //client = NetworkClient.allClients[0];



    }

   public void Awake()
    {
        countdown.GetComponent<Text>().text = "" + i;
        countdown.GetComponent<Text>().text = "" + username;
        Canvas countdownCanvas = GetComponent<Canvas>();
        Text countdownText = GetComponent<Text>();
    }
    //Selecting map

    public void selectMap()
    {
        
    }

    public void OnMouseDown()
    {
        string tag = gameObject.tag;
        {

        }
    }
    public void STARTGAME()
    {
        StartCoroutine(StartCountDown());

    }

    IEnumerator StartCountDown()
    {
       // Start The Canvas
       countdownCanvas.gameObject.SetActive(true);
        
        //get a random value
        Random rand = new Random();

        // Generate a random number from 1 to 10
        int t = rand.Next(1, 11);
        // Start The Count Down
        //Display the CountDown Value
       
        
            do
            {
            Time.timeScale = 4f;
            t = t - 1;
            countdown.GetComponent<Text>().text = "0" + t;
            yield return new WaitForSeconds(t);
            Thread.Sleep(10);
        } while (t > 0);
        Time.timeScale = 1f;
            
           
        
        
        //wait for required time
        //yield return new WaitForSeconds(t);
        SceneManager.LoadScene(mapNumber);
       
    }

    // Update is called once per frame
    void Update()
    {
        //get FPS
        float fps = 1.0f / Time.deltaTime;
        fpsText.text = "FPS: " + fps.ToString("F2");

        //get ping
       // int ping = client.GetRTT();
        // -pingText.text = "Ping: " + ping + " ms";
    }

    void PlaySound()
    {
        audioSource.Play();
    }
}
