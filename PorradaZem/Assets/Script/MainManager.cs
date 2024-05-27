using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private Canvas canvasGame;
    [SerializeField]
    private Slider[] lifeBars;
    [SerializeField]
    private GameObject P1;
    [SerializeField]
    private GameObject P2;

    GameObject[] players;
    // ENCAPSULATION
    public bool isGameActive { get; private set; }
    private int timer = 60;
    private MainUIHandler mainUIHandler;
    


    // Start is called before the first frame update
    void Awake()
    {
       

        mainUIHandler = canvasGame.GetComponent<MainUIHandler>();
        mainUIHandler.setTimer(timer.ToString());
        SetPlayers();
        StartGame();
        StartCoroutine(Cronometro());

    }
    void StartGame()
    {

        SetLifeBar();
        timer = 60;
        mainUIHandler.InterfaceGame(true);
        isGameActive = true;
    }
    void RestartGame()
    {
        SceneManager.LoadScene((int)GameManager.Scenas.main);
      
    }
    void SetPlayers()
    {
        Instantiate(GameManager.Instance.p1,P1.transform);
        Instantiate(GameManager.Instance.p2,P2.transform);
        
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


    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        canvasGame.GetComponent<MainUIHandler>().GameOver(true, Result());
        isGameActive = false;
      
    }

    string Result()
    {
        PlayerController p1 = players[0].GetComponent<PlayerController>();
        PlayerController p2 = players[1].GetComponent<PlayerController>();

        if (p1.p_life > p2.p_life) return $"Vitoria\n{p1.GetName()}" ;
        else if (p1.p_life < p2.p_life) return $"Vitoria\n{p2.GetName()}";
        else return "Embate!";

    }

    void SetLifeBar()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PlayerController>().CriaLifeBar(lifeBars[i]);
        }
    }
    public void onClickRevanche()
    {
        RestartGame();
    }
    public void onClickVoltar()
    {
        SceneManager.LoadScene((int)GameManager.Scenas.menu);

    }

}
