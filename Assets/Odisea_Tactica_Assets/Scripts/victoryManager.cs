using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button reduceHealthButton;
    public GameObject victoryScreen;
    public List<EnemyController> enemies;

    void Start()
    {
        // Asigna el m�todo ReduceEnemyHealth al bot�n
        reduceHealthButton.onClick.AddListener(ReduceEnemyHealth);

        // Aseg�rate de que la pantalla de victoria est� oculta al inicio
        victoryScreen.SetActive(false);

        // Encuentra todos los enemigos en la escena
        enemies.AddRange(Object.FindObjectsOfType<EnemyController>());
    }

    void ReduceEnemyHealth()
    {
        // Reduce la salud de todos los enemigos
        foreach (var enemy in enemies)
        {
            enemy.ApplyDamage(10f, enemy.GetComponent<NavMeshAgent>()); // Ejemplo: reduce 10 puntos de salud
        }

        // Verifica si todos los enemigos est�n muertos
        CheckVictory();
    }

    void CheckVictory()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                return; // Si hay alg�n enemigo vivo, no hemos ganado todav�a
            }
        }

        // Si todos los enemigos est�n muertos, muestra la pantalla de victoria
        victoryScreen.SetActive(true);
    }
}
