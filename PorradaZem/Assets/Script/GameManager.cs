using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    // ENCAPSULATION
    public GameObject p1 { get; private set; }
    public GameObject p2 { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SetP1(GameObject p)
    {
        p1 = p;
    }
    public void SetP2(GameObject p)
    {
        p2 = p;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public enum Scenas
    {
        menu=0,
        main=1

    }
}
