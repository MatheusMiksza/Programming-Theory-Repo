using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject mainUIGame;
    [SerializeField]
    private GameObject gameOverUI;
  
    

    

    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        GameOver(false);
        
    }

    public void InterfaceGame(bool b)
    {
        mainUIGame.SetActive(b);
    }

    public void GameOver(bool b, string winner = "")
    {
        gameOverText.text = $"\n{winner}";
        //InterfaceGame(!b);
        gameOverUI.SetActive(b);
    }

    public void setTimer(string s)
    {
        timerText.text = s;
    }

   
    

}
