using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public GameObject[] vidas;

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
        Debug.Log("Has Muerto");
    }

    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}