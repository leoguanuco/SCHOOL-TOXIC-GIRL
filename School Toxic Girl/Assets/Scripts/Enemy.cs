using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float vida;
    public GameObject Chico;
    public GameObject Toxica;
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
    public void TomarDaño(float daño)
    {
        vida -= daño;
        if(vida<=0)
        {
            Muerte();
            speed_run = 0f;
        }
    }
    private void Muerte()
    {
        ani.SetTrigger("die");
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
        Comportamientos();
    }
    public void Comportamientos()
    {
        if (Mathf.Abs(Chico.transform.position.x - transform.position.x) > rango_ataque && !atacando)
        {
            if (transform.position.x < Chico.transform.position.x)
            {
                ani.SetBool("isRun", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                ani.SetBool("isRun", true);
                transform.Translate(Vector3.right * speed_run * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0, 180, 0);
                ani.SetBool("attack", false);
            }
        }
        else
        {
            if (!atacando)
            {
                if (transform.position.x < Chico.transform.position.x)
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
}
