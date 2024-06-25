using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultyButton : MonoBehaviour
{
    // biến button cấp độ trò chơi
    [SerializeField] private Button difficulButton;

    //tham chiếu Game Manager để thực hiện start game 
    private GameManager gameManager;

    [SerializeField] private float difficulty;
    // Start is called before the first frame update
    void Start()
    {
        difficulButton=GetComponent<Button>();
        difficulButton.onClick.AddListener(SetDifficulty);
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty()
    {
        gameManager.StartGame(difficulty);
    }    
}
