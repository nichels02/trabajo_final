using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recorrido : MonoBehaviour
{
    listas.grafo<Vector3> Grafo = new listas.grafo<Vector3>();
    listas.grafo<Vector3> Grafo2 = new listas.grafo<Vector3>();
    [SerializeField] GameObject prefab;
    [SerializeField] Vector3[] vectores;
    [SerializeField] Vector3[] vectores2;

    public listas.grafo<Vector3> grafo
    {
        get { return grafo; }
        set { grafo = value; }
    }
    public listas.grafo<Vector3> grafo2
    {
        get { return grafo2; }
        set { grafo2 = value; }
    }

    void Start()
    {
        for(int i = 0; i < vectores.Length; i++)
        {
            Grafo.add(vectores[i]);
        }
        for(int i = 0; i < vectores2.Length; i++)
        {
            Grafo2.add(vectores2[i]);
        }

        /*
        Grafo.add(new Vector3(10, 0, -9));
        Grafo.add(new Vector3(10, 0, 3));
        Grafo.add(new Vector3(10, 7, 3));
        Grafo.add(new Vector3(-3, 7, 3));
        */
        for(int i = 0; i < vectores.Length-1; i++) 
        {
            Grafo.asignarEspecial(i+1);
            Grafo.asignarEspecial2(i + 2);
            Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        }

        for (int i = 0; i < vectores2.Length - 1; i++)
        {
            Grafo2.asignarEspecial(i+1);
            Grafo2.asignarEspecial2(i + 2);
            Grafo2.Tmp.Lista.AddNodeEnd(Grafo2.createConexion(Grafo2.Tmp2));
        }
        /*
        Grafo.asignarEspecial(1);
        Grafo.asignarEspecial2(2);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        Grafo.asignarEspecial(2);
        Grafo.asignarEspecial2(3);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        Grafo.asignarEspecial(3);
        Grafo.asignarEspecial2(4);
        Grafo.Tmp.Lista.AddNodeEnd(Grafo.createConexion(Grafo.Tmp2));
        */
        Grafo.asignarEspecial(1);
        Grafo2.asignarEspecial(1);

        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Instantiate(prefab, Grafo2.Tmp.Valor, transform.rotation);
        for (int i = 0; i < vectores.Length-1; i++)
        {
            Grafo.asignarEspecialConexion();
            Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        }
        for (int i = 0; i < vectores2.Length-1; i++)
        {
            Grafo2.asignarEspecialConexion();
            Instantiate(prefab, Grafo2.Tmp.Valor, transform.rotation);
        }

        /*
        Grafo.asignarEspecial(1);
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecialConexion();
        Instantiate(prefab, Grafo.Tmp.Valor, transform.rotation);
        Grafo.asignarEspecial(1);
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "punto")
        {
            if (Grafo.Tmp.Lista.Head != null)
            {
                Grafo.asignarEspecialConexion();
                myRigidbody.velocity = (Grafo.Tmp.Valor - transform.position).normalized * velocity;
            }
            /*
            else
            {
                myRigidbody.useGravity = true;
                codigo.enabled = true;
                this.enabled = false;
            }
            
        }
    }
    */
}

