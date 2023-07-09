using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    float velocidad;
    int daño;
    float vida;
    [SerializeField] GameObject jugador;
    [SerializeField] Rigidbody MyRigidbody;

    public float Velocidad
    {
        get { return velocidad; }
        set { velocidad = value; }
    }
    public int Daño
    {
        get { return daño; }
        set { daño = value; }
    }
    public float Vida
    {
        get { return vida; }
        set { vida = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyRigidbody.velocity = (jugador.transform.position - transform.position).normalized * velocidad;
    }
}
