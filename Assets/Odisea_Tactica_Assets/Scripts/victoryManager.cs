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
        // Asigna el método ReduceEnemyHealth al botón
        reduceHealthButton.onClick.AddListener(ReduceEnemyHealth);

        // Asegúrate de que la pantalla de victoria esté oculta al inicio
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

        // Verifica si todos los enemigos están muertos
        CheckVictory();
    }

    void CheckVictory()
    {
        foreach (var enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                return; // Si hay algún enemigo vivo, no hemos ganado todavía
            }
        }

        // Si todos los enemigos están muertos, muestra la pantalla de victoria
        victoryScreen.SetActive(true);
    }
}
