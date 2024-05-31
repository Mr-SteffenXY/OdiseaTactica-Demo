using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasEnemigas : MonoBehaviour
{
    public List<GameObject> particulas; // Lista de part�culas
    public GameObject[] enemigos; // Referencia a los enemigos en el mapa

    // Start is called before the first frame update
    void Start()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemys"); // Encuentra todos los enemigos en el mapa
    }

    // M�todo para instanciar part�culas en los enemigos
    public void InstanciarParticulas()
    {
        foreach (GameObject enemigo in enemigos)
        {
            int indiceParticula = Random.Range(0, particulas.Count); // Selecciona una part�cula aleatoria de la lista
            Instantiate(particulas[indiceParticula], enemigo.transform.position, Quaternion.identity); // Instancia la part�cula en la posici�n del enemigo
        }
    }
}
