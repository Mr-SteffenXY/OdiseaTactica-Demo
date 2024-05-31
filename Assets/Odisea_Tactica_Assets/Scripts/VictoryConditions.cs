using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryConditions : MonoBehaviour
{
    public List<GameObject> particulas; // Lista de partículas
    public GameObject interfazVictoria; // Referencia a la interfaz de usuario de victoria
    public float delay = 1f; // Retraso entre activar y desactivar las partículas

    // Método para mostrar la interfaz de usuario de victoria y comenzar la coroutine de las partículas
    public void MostrarVictoria()
    {
        // Muestra la interfaz de usuario de victoria
        interfazVictoria.SetActive(true);

        // Comienza la coroutine de las partículas
        StartCoroutine(ActivarDesactivarParticulas());
    }

    // Coroutine para activar y desactivar las partículas mientras la interfaz de victoria esté activa
    IEnumerator ActivarDesactivarParticulas()
    {
        while (interfazVictoria.activeSelf)
        {
            // Activa las partículas
            foreach (GameObject particula in particulas)
            {
                particula.SetActive(true);
            }

            // Espera el retraso
            yield return new WaitForSeconds(delay);

            // Desactiva las partículas
            foreach (GameObject particula in particulas)
            {
                particula.SetActive(false);
            }

            // Espera el retraso
            yield return new WaitForSeconds(delay);
        }
    }
}
