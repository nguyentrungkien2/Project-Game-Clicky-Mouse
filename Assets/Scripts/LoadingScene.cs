using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    // Loading UI
    public GameObject loadingScene;
    public Image fillValueLoading;
    public TMP_Text percentLoading;
    public GameObject ui_StartGame;
    public GameObject clickStartGame;
    public GameObject pauseGameButton;
    public GameObject textLive;
    public GameObject textScrore;

    // Object to turn on when loading is complete
    public GameObject otherObject;

    private float progress = 0.0f;

    public void StartLoading()
    {
        StartCoroutine(LoadSimulation());
    }

    private IEnumerator LoadSimulation()
    {
        loadingScene.SetActive(true);
        progress = 0.0f; // Reset progress to 0 at the start

        while (progress < 1f)
        {
            // Increment progress
            progress += Time.deltaTime * 0.5f; // Adjust speed of loading
            float progressValue = Mathf.Clamp01(progress);

            fillValueLoading.fillAmount = progressValue;
            percentLoading.text = (progressValue * 100).ToString("F0") + "%";
            yield return null;
        }

        loadingScene.SetActive(false);

        if (otherObject != null)
        {
            EventFinshedLoading();
        }
    }
    void EventFinshedLoading()
    {
        clickStartGame.SetActive(false);
        ui_StartGame.SetActive(false);
        loadingScene.SetActive(false);
        otherObject.SetActive(true);
        pauseGameButton.SetActive(true);
        textLive.SetActive(true);
        textScrore.SetActive(true);
    }    
}
