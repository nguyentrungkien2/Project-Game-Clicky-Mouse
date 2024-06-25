using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControls : MonoBehaviour
{
    //BG UI Start
    public GameObject begin_UI;

    //FadeIn Game UI
    public GameObject fadeIn;
    public GameObject fadeOut;

    //Time to change FadeIn
    private int timeToStartFade = 1;

    //Title scene
    public GameObject titleScene;
    public GameObject textScore;
    public GameObject textLive;
    public GameObject pauseButton;
    public GameObject lickStartBegin;

    public void SlideMenu()
    {
        StartCoroutine(StartFadeIn());
        begin_UI.SetActive(false);
    }
    IEnumerator StartFadeIn()
    {
        //in fadeIn
        fadeOut.SetActive(true);

        yield return new WaitForSeconds(timeToStartFade);
        fadeOut.SetActive(false);
        fadeIn.SetActive(true);

        yield return new WaitForSeconds(timeToStartFade);
        fadeIn.SetActive(false);
        lickStartBegin.SetActive(false);
        titleScene.gameObject.SetActive(true);
        textScore.gameObject.SetActive(true);
        textLive.gameObject.SetActive(true);
        pauseButton.SetActive(true);
    }
 
}
    