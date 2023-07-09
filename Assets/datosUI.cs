using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class datosUI : MonoBehaviour
{
    [SerializeField] TMP_Text textoBalas;
    [Header("vida")]
    int vida = 100;
    [SerializeField] Color[] corazones = new Color[10];


    public TMP_Text TextoBalas
    {
        get { return textoBalas; }
        set { textoBalas = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
