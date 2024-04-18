using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{
    [SerializeField]
    GameObject mainUIGame;
    [SerializeField]
    GameObject gameOverUI;

    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        InterfaceGame(false);
        GameOver(false);
        
    }

    public void InterfaceGame(bool b)
    {
        mainUIGame.SetActive(b);
    }

    public void GameOver(bool b, string winner = "")
    {
        gameOverText.text = $" Vitoria\n{winner}";
        //InterfaceGame(!b);
        gameOverUI.SetActive(b);
    }

    public void setTimer(string s)
    {
        timerText.text = s;
    }


}
