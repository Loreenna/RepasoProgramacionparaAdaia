using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject tittle;
    public GameObject mainButtons;
    public GameObject optionsMenu;

    public void OpenOptions()
    {
        tittle.SetActive(false);
        mainButtons.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("EscenaGuardada");
    }
   

}
