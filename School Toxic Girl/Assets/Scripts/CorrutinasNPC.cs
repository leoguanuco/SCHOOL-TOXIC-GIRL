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
        }
    }
    IEnumerator RotarMascota()
    {
        yield return new WaitForSecondsRealtime(2);
        for (int i = 0; i < puntosDeControl.Length; i++)
        {
            if (cat.transform.position.x <= puntosDeControl[i].position.y)
            {
                cat.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
            else
            {
                cat.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y - 360, 0);
            }
        }
        yield return null;
    }
}
