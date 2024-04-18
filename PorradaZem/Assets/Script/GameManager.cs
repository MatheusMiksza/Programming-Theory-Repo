using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasGame;   
    [SerializeField]
    private GameObject plyer01;
    [SerializeField]
    private GameObject plyer02;
    [SerializeField]
    private Slider[] lifeBars;

    GameObject[] players;
    private int timer = 60;
    public bool isGameActive { get; private set; }

    private MainUIHandler mainUIHandler;
    // Start is called before the first frame update
    void Start()
    {
        mainUIHandler = canvasGame.GetComponent<MainUIHandler>();
        mainUIHandler.setTimer(timer.ToString());
        StartGame();
    }

    void StartGame()
    {
        isGameActive = true;
        SetLifeBar();
        StartCoroutine(Cronometro());
        mainUIHandler.InterfaceGame(true);
    }

    IEnumerator Cronometro()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            timer--;
            if (timer < 0) GameOver();
            mainUIHandler.setTimer($"{timer}");
        }
    }

    void SetLifeBar()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0;i< players.Length;i++)
        {
            players[i].GetComponent<PlayerController>().CriaLifeBar(lifeBars[i]);
        }
    }

    public void SetParent(Slider slider)
    {
        slider.transform.SetParent(canvasGame.transform,true);
    }

    string Winner()
    {
        PlayerController p1 = players[0].GetComponent<PlayerController>();
        PlayerController p2 = players[1].GetComponent<PlayerController>();

        if (p1.p_life > p2.p_life) return p1.GetName(); 
        else if (p1.p_life < p2.p_life) return p2.GetName(); 
        else return "Embate!"; 
        
    }

    public void GameOver()
    {
        canvasGame.GetComponent<MainUIHandler>().GameOver(true, Winner());
        isGameActive = false;
        //timer = 60;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
