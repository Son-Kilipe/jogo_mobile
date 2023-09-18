using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pause;
    public static bool Ispause;
    public Button btn_Menu;
    public Sprite play, pausa;


    void Start()
    {
        pause.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BtnPausar();
        }


    }

    private void Pausar()
    {
        pause.SetActive(true);
        btn_Menu.image.sprite = play;
        Time.timeScale = 0f;
        Ispause = true;

    }

    private void VoltarGame()
    {
        pause.SetActive(false);
        btn_Menu.image.sprite = pausa;
        Time.timeScale = 1f;
        Ispause = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void BtnPausar()
    {
        if (Ispause)
        {
            VoltarGame();
        }
        else
        {
            Pausar();
    
        }
    }
}
