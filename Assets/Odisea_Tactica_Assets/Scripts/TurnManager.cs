using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance { get; private set; }

    public enum Turn { Allies, Enemies }
    public Turn CurrentTurn { get; private set; }

    public EnemyController enemyController; // Referencia al controlador de enemigos
    public AgentController agentController; // Referencia al controlador de agentes

    private int enemyActionsRemaining = 4;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CurrentTurn = Turn.Allies;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }
    }

    public void EndTurn()
    {
        if (CurrentTurn == Turn.Allies)
        {
            CurrentTurn = Turn.Enemies;
            enemyActionsRemaining = 4;
            Debug.Log("Enemy turn starts.");
            enemyController.StartEnemyTurn();
        }
        else
        {
            CurrentTurn = Turn.Allies;
            agentController.ResetActions();
            Debug.Log("Allies turn starts.");
        }
    }

    public void DecrementEnemyAction()
    {
        enemyActionsRemaining--;
        if (enemyActionsRemaining <= 0)
        {
            EndTurn();
        }
    }
}
