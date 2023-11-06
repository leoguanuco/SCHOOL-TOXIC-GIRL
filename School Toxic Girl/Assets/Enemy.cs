using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject Chico;
    public GameObject Toxica;
    //private float LastShoot;
    public Animator ani;
    public int direccion;
    public float speed_run;
    public bool atacando;

    public float rango_ataque;
    public GameObject rango;
    public GameObject Hit;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        atacando = false;
        rango.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponTrue()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        Hit.GetComponent<BoxCollider2D>().enabled = false;
    }

    private void Update()
    {
        /*Vector3 direction = Chico.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        else transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);*/

        Comportamientos();

        /*float distance = Mathf.Abs(Toxica.transform.position.x - transform.position.x);

        if (distance < 2.0f && Time.time > LastShoot + 0.25f)
        {
            Shoot();
            LastShoot = Time.time;
        }*/
    }
    public void Comportamientos()
    {
        if (Mathf.Abs(Chico.transform.position.x - transform.position.x) > rango_ataque && !atacando)
        {
            if(transform.position.x < Chico.transform.position.x)
            {
                //ani.SetBool("walk", false);
                ani.SetBool("isRun", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
                //ani.SetBool("attack", false);
            }
            else
            {
                //ani.SetBool("walk", false);
                ani.SetBool("isRun", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                //ani.SetBool("attack", false);
            }
        }
        else
        {
            if (!atacando)
            {
                if(transform.position.x < Chico.transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                //ani.SetBool("walk", false);
                ani.SetBool("isRun", false);
            }
        }
    }

    /*private void Shoot()
    {
        Debug.Log("Shoot");
    }*/
}
