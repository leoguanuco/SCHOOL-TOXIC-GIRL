using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCaC : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(tiempoSiguienteAtaque > 0)
        {
            tiempoSiguienteAtaque -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && tiempoSiguienteAtaque <= 0)
        {
            Golpe();
            tiempoSiguienteAtaque = tiempoEntreAtaques;
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("attack");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach(Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemy"))
            {
                colisionador.transform.GetComponent<Enemy>().TomarDaño(dañoGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
