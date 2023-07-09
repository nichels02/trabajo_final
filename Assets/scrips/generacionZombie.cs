using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generacionZombie : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    [SerializeField] GameObject controladorDeRondas;
    [Header("Posiciones")]
    [SerializeField] Vector3 posicion1;
    [SerializeField] Vector3 posicion2;
    [Header("Datos")]
    [SerializeField] int vida;
    [SerializeField] int daño;
    [SerializeField] int velocidad;
    bool eleccion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generacionZombieEnemigo()
    {
        eleccion = Random.Range(0, 2) == 1;
        if (eleccion == true)
        {
            GameObject enemigo= Instantiate(zombie, posicion1, transform.rotation);
            enemigo.GetComponent<zombie>().Vida = vida * controladorDeRondas.GetComponent<controladorRondas>().Rondas;
            enemigo.GetComponent<zombie>().Daño = daño;
            enemigo.GetComponent<zombie>().Velocidad = velocidad;
            enemigo.GetComponent<recorridoDeZombie>().Posicion = 1;
            Debug.Log("1");
        }
        else
        {
            GameObject enemigo = Instantiate(zombie, posicion2, transform.rotation);
            enemigo.GetComponent<zombie>().Vida = vida * controladorDeRondas.GetComponent<controladorRondas>().Rondas;
            enemigo.GetComponent<zombie>().Daño = daño;
            enemigo.GetComponent<zombie>().Velocidad = velocidad;
            enemigo.GetComponent<recorridoDeZombie>().Posicion = 2;
            Debug.Log("2");
        }
    }
}
