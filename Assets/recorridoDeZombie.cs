using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorridoDeZombie : MonoBehaviour
{
    [SerializeField] recorrido elRecorrido;
    [SerializeField] zombie Zombie;
    [SerializeField] rotacionDelEnemigo rotacion;
    [SerializeField] Rigidbody MyRigidbody;
    int posicion;
    int nodoPosicion=1;


    public int Posicion
    {
        get { return posicion; }
        set { posicion = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if(posicion == 1)
        {
            elRecorrido.GetComponent<recorrido>().Grafo2.asignarEspecial(1);
            MyRigidbody.velocity=(elRecorrido.GetComponent<recorrido>().Grafo2.Tmp.Valor - transform.position).normalized* Zombie.GetComponent<zombie>().Velocidad;
        }
        else if(posicion == 2)
        {
            elRecorrido.GetComponent<recorrido>().Grafo.asignarEspecial(1);
            MyRigidbody.velocity = (elRecorrido.GetComponent<recorrido>().Grafo.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "punto")
        {
            if (posicion == 1)
            {
                for (int i = 0; i < posicion; i++)
                {
                    elRecorrido.GetComponent<recorrido>().Grafo2.asignarEspecialConexion();
                }
                MyRigidbody.velocity = (elRecorrido.GetComponent<recorrido>().Grafo2.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
                nodoPosicion += 1;

                if (elRecorrido.GetComponent<recorrido>().Grafo2.Tmp.Lista.Head == null)
                {
                    MyRigidbody.useGravity = true;
                    Zombie.enabled = true;
                    rotacion.enabled = true;
                    this.enabled = false;
                }
                elRecorrido.GetComponent<recorrido>().Grafo2.asignarEspecial(1);

            }
            else if (posicion == 2)
            {
                for (int i = 0; i < posicion; i++)
                {
                    elRecorrido.GetComponent<recorrido>().Grafo.asignarEspecialConexion();
                }
                MyRigidbody.velocity = (elRecorrido.GetComponent<recorrido>().Grafo.Tmp.Valor - transform.position).normalized * Zombie.GetComponent<zombie>().Velocidad;
                nodoPosicion += 1;

                if (elRecorrido.GetComponent<recorrido>().Grafo2.Tmp.Lista.Head == null)
                {
                    MyRigidbody.useGravity = true;
                    Zombie.enabled = true;
                    rotacion.enabled = true;
                    this.enabled = false;
                }
                elRecorrido.GetComponent<recorrido>().Grafo.asignarEspecial(1);
            }
        }
    }
}
