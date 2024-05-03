using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private Canvas menuCanvas;
    private int plyer = 1;
    private GameObject playerSelected;
    private GameObject playerInstantiate;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickSelctPlayer(GameObject p)
    {
        if (playerSelected == p || plyer >2) return;

        playerSelected = p;
        if(playerInstantiate != null) GameManager.Destroy(playerInstantiate);
        
        menuCanvas.GetComponent<MenuUiHandler>().VisiblePrevia($"P{plyer}");
        GameObject pn = GameObject.Find($"P{plyer}");        
        playerInstantiate = Instantiate(p, pn.transform);
        pn.GetComponentInChildren<TextMeshProUGUI>().text = p.name;
        playerInstantiate.transform.SetParent(pn.transform,true);
    }
    
    public void onClickPronto()
    {
        if (plyer == 1) GameManager.Instance.SetP1(playerSelected);
        else GameManager.Instance.SetP2(playerSelected);
        menuCanvas.GetComponent<MenuUiHandler>().DisableButton($"btn_Pronto_P{plyer}" , false);
        
        if(plyer >=2)
            menuCanvas.GetComponent<MenuUiHandler>().VisibilidadeBtn($"btn_lutar", true);

        plyer++;
        playerSelected = null;
        playerInstantiate = null;
    }

    public void onClickLutar()
    {
        SceneManager.LoadScene((int)GameManager.Scenas.main);
    }

}
