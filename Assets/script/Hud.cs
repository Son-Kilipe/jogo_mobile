using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Hud : MonoBehaviour
{
    public Image life; //pega o componente Image da unity
    public Sprite image0;
    public Sprite image25;
    public Sprite image50;
    public Sprite image100;
    public GameObject player; //Pega o player
    private bool gerarimage; //variavel de controle
    public Text text; //pega o componente text da unity


    void Start()
    {
        life.sprite = image100;
        gerarimage = false;
       


    }





    void Update()
    {
        if (player.GetComponent<Personagem>().life == 125 && gerarimage == true)
        {
            StartCoroutine((IEnumerator)WaitImage(0.5f));
        }
        else if (player.GetComponent<Personagem>().life == 100)
        {
            life.sprite = image100;
        }
        else if (player.GetComponent<Personagem>().life == 50)
        {
            life.sprite = image50;
        }
        else if (player.GetComponent<Personagem>().life == 25)
        {
            life.sprite = image25;
            gerarimage = true;
        }

        //text.text = Convert.ToString(player.GetComponent<Personagem>().moeda);

    }
    private IEnumerable WaitImage(float waitTime)
    {
        life.sprite = image0;
        yield return new WaitForSeconds(waitTime);
        life.sprite = image100;
        gerarimage = false;
    }


}
