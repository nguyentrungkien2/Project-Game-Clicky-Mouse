using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    //tạo list gồm các target khởi tạo
    [SerializeField] List<GameObject> listTargets;

    //biến time lặp lại khởi tạo
    private float timeCourotine = 1.0f;

    //khởi tạo điểm 
    private int score;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textGameOver;

    public Button buttonResetGame;

    public GameObject titleScreen;
    //biến dừng target khi game over 
    public bool isGameActive;

    private int live;
    public TextMeshProUGUI textLive;

    //lấy đối tượng pasue để dùng màn hình
    public GameObject pauseScreen;
    private bool paused;
    // Start is called before the first frame update
    public void StartGame(float difficulty)
    {

        isGameActive = true;
        score = 0;
        CountLive(3);
        timeCourotine /= difficulty;
        StartCoroutine(SpawnTargets());
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }
    public void ChangePaused()
    {
        if (!paused)
        {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1.0f;
        }
    }
    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(timeCourotine);
            int index = Random.Range(0, listTargets.Count);
            Instantiate(listTargets[index]);

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
        if(score<0)
        {
            GameOver();
        }    
    }
    public void CountLive(int lives)
    {
        live += lives;
        textLive.text = "Lives: " + live;
        if (live <= 0)
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        isGameActive = false;
        textGameOver.gameObject.SetActive(true);
        buttonResetGame.gameObject.SetActive(true);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		    Application.Quit();
#endif
    }



}
