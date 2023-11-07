using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CorrutinasNPC : MonoBehaviour
{
    [SerializeField] private GameObject cat;
    [SerializeField] private Transform[] puntosDeControl;
    [SerializeField] private float velocidad = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("RealizarMovimiento");
        
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("RealizarMovimiento");
        }
    }
    IEnumerator RealizarMovimiento()
    {
        int i = 0;
        Vector3 nuevaPosicion = new Vector3(puntosDeControl[i].position.x, cat.transform.position.y);
        while (true)
        {
            while(cat.transform.position != nuevaPosicion)
            {
                cat.transform.position = Vector3.MoveTowards(cat.transform.position, nuevaPosicion, velocidad * Time.deltaTime);
                yield return null;
            }
            yield return StartCoroutine("RotarMascota");
            if (i < puntosDeControl.Length - 1)
            {
                i++;
            }
            else
            {
                i = 0;
            }
            nuevaPosicion = new Vector3(puntosDeControl[i].position.x, cat.transform.position.y);
            Debug.Log(i);
        }
    }
    IEnumerator RotarMascota()
    {
        int i = 1;
        yield return new WaitForSecondsRealtime(2);
        if (i < puntosDeControl.Length)
        {
            cat.transform.localScale = new Vector3(3, 3, 0);
        }
        else
        {
            cat.transform.localScale = new Vector3(-3, -3, 0);
        }
        yield return null;
    }
}
