using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class movimiento : rotacion
{
    [Header("Datos de Movimiento y Rotacion")]
    [SerializeField] float velocidad;
    [SerializeField] Rigidbody myRigidbody;
    Vector2 inputMovement;
    Vector2 Vector;

    [Header("Disparar")]
    listas.pila<string> listaDeArmas = new listas.pila<string>();
    [SerializeField] GameObject generadorDeBala;
    [SerializeField] GameObject generadorDeBalaEscoprta1;
    [SerializeField] GameObject generadorDeBalaEscoprta2;
    [SerializeField] GameObject Bala;
    float tiempo;
    float tiempomax=1;
    Quaternion quaternionTemporal;


    [Header("Cantidad Balas")]
    [SerializeField] TMP_Text textoBalas;





    // Start is called before the first frame update
    void Start()
    {
        listaDeArmas.Add("pistolaPrincipal",10,10,1);
    }

    // Update is called once per frame
    void Update()
    {
        if (tiempo <= listaDeArmas.Head.TiempoMax)
        {
            tiempo += Time.deltaTime;
        }
        
    }

    public void Movement()
    {
        myRigidbody.velocity = transform.right * inputMovement.x * velocidad + transform.forward * inputMovement.y * velocidad;

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        inputMovement = value.ReadValue<Vector2>();
        inputMovement = inputMovement.normalized;
        myRigidbody.velocity = transform.right * inputMovement.x * velocidad + transform.forward * inputMovement.y * velocidad;

    }

 
    public void OnRotation(InputAction.CallbackContext value)
    {
        Vector2 inputRotation = value.ReadValue<Vector2>();
        Vector.x = angulos.x;
        Vector.y = angulos.y;
        //inputMovement.y = Mathf.Clamp(inputMovement.y, -0.4f, 0.5f);
        angulos.x = Mathf.Clamp(angulos.x, -50, 50);
        if (Vector != inputRotation)
        {
            angulos.x -= inputRotation.y / 20;
            angulos.y += inputRotation.x / 8;
            Movement();
        }
        
    }

    public void Disparar(InputAction.CallbackContext value)
    {
        float valor = value.ReadValue<float>();
        if (listaDeArmas.Head.Valor == "pistolaPrincipal")
        {
            if (tiempo > 1)
            {
                if (valor == 1)
                {

                    Instantiate(Bala, generadorDeBala.transform.position, generadorDeBala.transform.rotation);
                    listaDeArmas.Head.CantidadDeBalas -= 1;
                    tiempo = 0;

                    if (listaDeArmas.Head.CantidadDeBalas <= 0)
                    {
                        listaDeArmas.Head.CantidadDeBalas = listaDeArmas.Head.CantidadDeBalasCargador;
                    }

                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";

                }
            }
        }
        else if (listaDeArmas.Head.Valor == "metralleta")
        {
            if (tiempo > listaDeArmas.Head.TiempoMax)
            {
                if (valor == 1)
                {

                    Instantiate(Bala, generadorDeBala.transform.position, generadorDeBala.transform.rotation);
                    listaDeArmas.Head.CantidadDeBalas -= 1;
                    tiempo = 0;

                    if (listaDeArmas.Head.CantidadDeBalas <= 0 && listaDeArmas.Head.CantidadDeBalasTotales <= 0)
                    {
                        Debug.Log("- metralleta");
                        listaDeArmas.remove();
                        if (listaDeArmas.Head.Valor == "pistolaPrincipal")
                        {
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";
                        }
                        else
                        {
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                        }
                    }
                    else if (listaDeArmas.Head.CantidadDeBalas <= 0)
                    {
                        listaDeArmas.Head.CantidadDeBalas = listaDeArmas.Head.CantidadDeBalasCargador;
                        listaDeArmas.Head.CantidadDeBalasTotales -= listaDeArmas.Head.CantidadDeBalasCargador;
                    }

                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                }
            }
        }
        else if (listaDeArmas.Head.Valor == "escopeta")
        {
            if (tiempo > listaDeArmas.Head.TiempoMax)
            {
                if (valor == 1)
                {
                    Instantiate(Bala, generadorDeBalaEscoprta1.transform.position, generadorDeBalaEscoprta1.transform.rotation);

                    Instantiate(Bala, generadorDeBalaEscoprta2.transform.position, generadorDeBalaEscoprta2.transform.rotation);
                    listaDeArmas.Head.CantidadDeBalas -= 2;
                    tiempo = 0;

                    if (listaDeArmas.Head.CantidadDeBalas <= 0 && listaDeArmas.Head.CantidadDeBalasTotales <= 0)
                    {
                        Debug.Log("- escopeta");
                        listaDeArmas.remove();
                        if (listaDeArmas.Head.Valor == "pistolaPrincipal")
                        {
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ ?";
                        }
                        else
                        {
                            textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                        }
                    }
                    else if(listaDeArmas.Head.CantidadDeBalas <= 0)
                    {
                        listaDeArmas.Head.CantidadDeBalas = listaDeArmas.Head.CantidadDeBalasCargador;
                        listaDeArmas.Head.CantidadDeBalasTotales -= listaDeArmas.Head.CantidadDeBalasCargador;
                    }

                    textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
                }
            }
        }

        
        /*
        if (CantidadBala > 0 & tiempo>1)
        {
            if (valor == 1)
            {
                
                Instantiate(Bala, generadorDeBala.transform.position, generadorDeBala.transform.rotation);
                CantidadBala -= 1;
                tiempo = 0;
            }
        }
        */
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "arma")
        {
            string arma = other.GetComponent<arma>().QueArma;
            Destroy(other.gameObject);
            if(arma == "metralleta" && other.GetComponent<arma>().CanDetect == true)
            {
                Debug.Log("metralleta");
                listaDeArmas.Add2(arma,30,30,300, 0.2f);
                textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
            }
            else if(arma == "escopeta" && other.GetComponent<arma>().CanDetect == true)
            {
                Debug.Log("escopeta");
                listaDeArmas.Add2(arma, 8, 8, 64, 2);
                textoBalas.text = listaDeArmas.Head.CantidadDeBalas + "/ " + listaDeArmas.Head.CantidadDeBalasTotales;
            }
            if (other.GetComponent<arma>().CanDetect == true)
            {
                other.GetComponent<arma>().CanDetect = false;
            }
        }
    }
}
