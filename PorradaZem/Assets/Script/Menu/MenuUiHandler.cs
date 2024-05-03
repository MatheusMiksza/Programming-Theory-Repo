using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUiHandler : MonoBehaviour
{
    [SerializeField]
    private Button btn_play;
    [SerializeField]
    private GameObject uiPlyerSelect;
    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private List<GameObject> UiPrevia;
    [SerializeField]
    private List<GameObject> buttons;
    
    void Start()
    {
        
    }

    public void onClickBtnPlay()
    {
        menu.SetActive(false);
        plyerSelectVisible(true);
    }

    private void plyerSelectVisible(bool b)
    {
        uiPlyerSelect.SetActive(true);
    }

   
    public void DisableButton(string name,bool disable = false)
    {
        buttons.Find(x => x.name == $"{name}").GetComponent<Button>().interactable = disable;

    }
    public void VisibilidadeBtn(string name, bool disable = true)
    {
        buttons.Find(x => x.name == $"{name}").SetActive(disable);
    }

    public void VisiblePrevia(string name)
    {
        UiPrevia.Find(x => x.name == name).SetActive(true);
    }

}
