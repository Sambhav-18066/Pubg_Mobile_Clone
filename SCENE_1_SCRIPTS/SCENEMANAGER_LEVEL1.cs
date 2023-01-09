using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SCENEMANAGER_LEVEL1 : MonoBehaviour



    
{

    public RawImage image;


    private void Awake()
    {
        StartCoroutine(stopvideo());
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        StartCoroutine(stopvideo());
    }

   //Change The Scene

    public void ChangeToLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
       
    }

    public void SKIPVIDEO()
    {
        RawImage.Destroy(image);
    }


    //DISABLE VIDEO IMAGE AFTER VIDEO IS ENDED
  
    IEnumerator stopvideo()
    {
        //wait for required time
        yield return new WaitForSeconds(45);
        SceneManager.LoadScene("Lobby");
        RawImage.Destroy(image);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
