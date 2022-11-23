using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 3;

    public int puntos = 0;

    public GameObject[] corazones;

    public GameObject cochina;

    public GameObject HUD;

    public GameObject Marco;

    public GameObject personajeDerrota;

    public GameObject personajeVictoria;

    public Text EstrellitaDondeEstas;


    // Start is called before the first frame update
    void Awake()
    {
        //Si ya hay una instancia y no soy yo me destruyo
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this);

    }

    public void RestarVidas()
    {
        vidas--;
    
        if(vidas == 2)
        {
            corazones[2].SetActive(false);
        }

        if(vidas == 1)
        {
            corazones[1].SetActive(false);
        }

        if(vidas == 0)
        {
            cochina.SetActive(false);
            HUD.SetActive(false);
            Marco.SetActive(true);
            personajeDerrota.SetActive(true);
        }
    
    }

    public void MeCojoAAdaia()
    {
        Debug.Log("puta");
        puntos++;
        EstrellitaDondeEstas.text = "" + puntos;
        if(puntos == 5)
        {
            cochina.SetActive(false);
            HUD.SetActive(false);
            Marco.SetActive(true);
            personajeVictoria.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
