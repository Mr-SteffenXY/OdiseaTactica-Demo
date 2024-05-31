using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    private float health;
    public List<NavMeshAgent> enemies; // Lista de enemigos a controlar
    public List<Transform> allies; // Lista de aliados a buscar
    public float attackRange = 2f; // Rango de ataque para el primer enemigo
    public float safeDistance = 5f; // Distancia segura para el segundo enemigo
    public Button CardButton;

    private int currentEnemyIndex = 0;
    private int enemyActionsRemaining;

    void Start()
    {
        // Asegúrate de que CardButton no sea null
        if (CardButton != null)
        {
            CardButton.onClick.AddListener(OnCardButtonClicked);
        }
    }

    void OnCardButtonClicked()
    {
        // Define el daño y el enemigo
        float damage = 10f; // Cambia esto al valor que quieras
        NavMeshAgent enemy = enemies[currentEnemyIndex];

        // Aplica daño cuando se hace clic en el botón
        ApplyDamage(damage, enemy);
    }

    public void ApplyDamage(float damage, NavMeshAgent enemy)
    {
        health -= damage;

        // Actualizar el parámetro Health del Animator
        Animator enemyAnimator = enemy.GetComponent<Animator>();
        if (enemyAnimator != null)
        {
            enemyAnimator.SetFloat("Health", health);
        }

        // Comprobar si el enemigo ha muerto
        if (health < 1)
        {
            enemyAnimator.SetFloat("Health", 0);
            enemy.enabled = false;
        }
    }

    public void StartEnemyTurn()
    {
        enemyActionsRemaining = enemies.Count; // Resetear el número de acciones enemigas
        StartCoroutine(EnemyTurnRoutine());
    }

    private IEnumerator EnemyTurnRoutine()
    {
        while (TurnManager.Instance.CurrentTurn == TurnManager.Turn.Enemies && enemyActionsRemaining > 0)
        {
            NavMeshAgent enemy = enemies[currentEnemyIndex];
            Animator enemyAnimator = enemy.GetComponent<Animator>();

            // Primer enemigo: ataca al primer aliado en la lista si está en rango
            // Segundo enemigo: ataca al último aliado en la lista desde una distancia segura
            Transform targetAlly = currentEnemyIndex == 0 ? allies[0] : allies[allies.Count - 1];

            if (targetAlly != null)
            {
                enemy.SetDestination(targetAlly.position);
                enemy.speed = 5f;

                // Espera hasta que el enemigo llegue al rango de ataque
                while (!enemy.pathPending && enemy.remainingDistance > (currentEnemyIndex == 0 ? attackRange : safeDistance))
                {
                    UpdateEnemySpeed(enemy, enemyAnimator);
                    yield return null;
                }

                // Detenerse y atacar
                enemy.speed = 0f;
                enemyAnimator.SetFloat("SpeedRun", 0f);

                if (enemy.remainingDistance <= (currentEnemyIndex == 0 ? attackRange : safeDistance))
                {
                    enemyAnimator.SetTrigger(currentEnemyIndex == 0 ? "Attack" : "MagicAttack");
                }
            }

            TurnManager.Instance.DecrementEnemyAction();
            enemyActionsRemaining--;
            currentEnemyIndex++;

            // Resetear índice si todos los enemigos han actuado
            if (currentEnemyIndex >= enemies.Count)
            {
                currentEnemyIndex = 0;
            }

            yield return new WaitForSeconds(1f); // Tiempo de espera entre acciones de los enemigos
        }

        TurnManager.Instance.EndTurn();
    }

    private void UpdateEnemySpeed(NavMeshAgent enemy, Animator enemyAnimator)
    {
        // Calcular la velocidad del enemigo en función de su NavMeshAgent
        float speed = enemy.velocity.magnitude;

        // Enviar la velocidad al Animator
        enemyAnimator.SetFloat("SpeedRun", speed);
    }

    public bool IsDead()
    {
        return health <= 0;
    }

    internal float GetHealth()
    {
        Debug.Log("Health: " + health);
        return health;
    }
}
