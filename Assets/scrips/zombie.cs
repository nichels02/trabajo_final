using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour
{
    float velocidad;
    int daño;
    float vida;
    bool seguir=false;
    Vector3 posicion;
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
    public GameObject Jugador
    {
        get { return jugador; }
        set { jugador = value; }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (seguir == true)
        {
            posicion=new Vector3(jugador.transform.position.x, 139.2625F, jugador.transform.position.z);
            MyRigidbody.velocity = (posicion - transform.position).normalized * velocidad;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        seguir = true;
        MyRigidbody.mass = 1;
    }
}
