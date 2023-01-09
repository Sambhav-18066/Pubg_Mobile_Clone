using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class ScenemanagerLoadingScreen : MonoBehaviour
{
    public GameObject slider;
    private RectTransform rectTransform; 
    private float startTime;
    private float journeyLength;
    public int mapnumber;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = slider.GetComponent<RectTransform>();
        journeyLength = rectTransform.rect.width;
        startTime = Time.time;
        StartCoroutine(AnimateSliderAfterDelay(5));
       
    }


    IEnumerator AnimateSliderAfterDelay(float delay)
    {
        // Wait for the specified delay before starting the animation
        yield return new WaitForSeconds(delay);

        // Animate the slider
        StartCoroutine(AnimateSlider());
    }
    IEnumerator AnimateSlider()
    {
        // Continue looping until the animation is complete
        while (true)
        {
            // Calculate the elapsed time as a fraction of the total duration
            float elapsedTime = Time.time - startTime;
            float fractionJourney = elapsedTime / 10;

            // Update the position of the slider
            rectTransform.anchoredPosition = Vector2.Lerp(Vector2.zero, new Vector2(journeyLength, 0), fractionJourney);

            // If the animation is complete, exit the loop
            if (fractionJourney >= 1)
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(mapnumber);
            }

            // Wait for the next frame before continuing the loop
            yield return 0;
        }
    }

        // Update is called once per frame
        void Update()
    {
        
    }

    public void onEnd()
    {
        
    }
}
