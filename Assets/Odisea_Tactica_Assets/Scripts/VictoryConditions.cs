using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryConditions : MonoBehaviour
{
    public List<GameObject> particulas; // Lista de part�culas
    public GameObject interfazVictoria; // Referencia a la interfaz de usuario de victoria
    public float delay = 1f; // Retraso entre activar y desactivar las part�culas

    // M�todo para mostrar la interfaz de usuario de victoria y comenzar la coroutine de las part�culas
    public void MostrarVictoria()
    {
        // Muestra la interfaz de usuario de victoria
        interfazVictoria.SetActive(true);

        // Comienza la coroutine de las part�culas
        StartCoroutine(ActivarDesactivarParticulas());
    }

    // Coroutine para activar y desactivar las part�culas mientras la interfaz de victoria est� activa
    IEnumerator ActivarDesactivarParticulas()
    {
        while (interfazVictoria.activeSelf)
        {
            // Activa las part�culas
            foreach (GameObject particula in particulas)
            {
                particula.SetActive(true);
            }

            // Espera el retraso
            yield return new WaitForSeconds(delay);

            // Desactiva las part�culas
            foreach (GameObject particula in particulas)
            {
                particula.SetActive(false);
            }

            // Espera el retraso
            yield return new WaitForSeconds(delay);
        }
    }
}
