using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasEnemigas : MonoBehaviour
{
    public List<GameObject> particulas; // Lista de partículas
    public GameObject[] enemigos; // Referencia a los enemigos en el mapa

    // Start is called before the first frame update
    void Start()
    {
        enemigos = GameObject.FindGameObjectsWithTag("Enemys"); // Encuentra todos los enemigos en el mapa
    }

    // Método para instanciar partículas en los enemigos
    public void InstanciarParticulas()
    {
        foreach (GameObject enemigo in enemigos)
        {
            int indiceParticula = Random.Range(0, particulas.Count); // Selecciona una partícula aleatoria de la lista
            Instantiate(particulas[indiceParticula], enemigo.transform.position, Quaternion.identity); // Instancia la partícula en la posición del enemigo
        }
    }
}
