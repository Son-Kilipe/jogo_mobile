using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bau : MonoBehaviour
{
    public float rotationspeed = 30.00f; //Velocidade de rotação em graus por segundo
    public GameObject question;  

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * rotationspeed * Time.deltaTime);
        // Rotaciona o objeto no eixo Y

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            rotationspeed = 0f;

            this.gameObject.SetActive(false);
            question.SetActive(true);

        }
    }

}
