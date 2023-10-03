using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public DynamicJoystick joydyn;
    public float speed;
    public float speedRotation;
    Animator m_Animator;
    public int life = 100;



    // Start is called before the first frame update
    void Start()
    {
        //m_Animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveV = joydyn.Vertical;
        transform.Translate(0, 0, moveV * Time.deltaTime * speed);

        float moveH = joydyn.Horizontal;
        transform.Rotate(0, moveH * Time.deltaTime * speedRotation, 0);

        /*if (moveH > 0 || moveH < 0 || moveV > 0 || moveV < 0)
        {

            m_Animator.SetBool("walk", true);

        }
        else
        {
            m_Animator.SetBool("walk", false);
        }*/
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            life -= 25;
            if (life <= 0)
            {

                life = 125;
                this.transform.position = new Vector3(-265.899994f, -187.770004f, 11.1000004f);
                this.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            life -= 25;
            if (life <= 0)
            {

                life = 125;
                this.transform.position = new Vector3(-4f, -35f, 181f);
                this.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }
}

