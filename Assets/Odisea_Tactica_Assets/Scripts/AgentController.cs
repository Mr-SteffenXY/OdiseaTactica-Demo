using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    public Camera mainCamera;
    public List<NavMeshAgent> agents;
    public List<CharacterConfig> allyConfigs; // Lista de configuraciones para los aliados
    public TextMeshProUGUI textMeshPro;
    public TextMeshProUGUI actionsRemainingText;
    public List<string> currentAgentTexts;

    private int currentAgentIndex = 0;
    private NavMeshAgent currentAgent;
    private Animator currentAnimator;
    private int actionsRemaining = 5;

    void Start()
    {
        if (agents.Count == 0 || allyConfigs.Count != agents.Count)
        {
            Debug.LogError("Agents or allyConfigs not assigned properly in AgentController.");
            return;
        }

        for (int i = 0; i < agents.Count; i++)
        {
            agents[i].speed = allyConfigs[i].speed;
            // Otras configuraciones iniciales si es necesario
        }

        SelectAgent(0);
    }

    void Update()
    {
        bool isEnemyTurn = TurnManager.Instance.CurrentTurn == TurnManager.Turn.Enemies;
        foreach (var agent in agents)
        {
            var animator = agent.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("EnemyTurn", isEnemyTurn);
            }
        }

        if (!isEnemyTurn)
        {
            HandleAgentSwitch();
            HandleClickMovement();
            UpdateAnimator();
        }
    }

    void HandleAgentSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            currentAgentIndex = (currentAgentIndex + 1) % agents.Count;
            SelectAgent(currentAgentIndex);
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
        {
            currentAgentIndex--;
            if (currentAgentIndex < 0)
            {
                currentAgentIndex = agents.Count - 1;
            }
            SelectAgent(currentAgentIndex);
        }
    }

    void SelectAgent(int index)
    {
        if (currentAgent != null)
        {
            Transform currentSelector = currentAgent.transform.Find("Selector");
            if (currentSelector != null)
            {
                currentSelector.gameObject.SetActive(false);
            }
        }

        currentAgent = agents[index];
        currentAnimator = currentAgent.GetComponent<Animator>();

        if (textMeshPro == null)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        textMeshPro.text = currentAgentTexts[index];

        Transform newSelector = currentAgent.transform.Find("Selector");
        if (newSelector != null)
        {
            newSelector.gameObject.SetActive(true);
        }

        Debug.Log("Selected agent: " + currentAgent.gameObject.name);
    }

    void HandleClickMovement()
    {
        if (actionsRemaining > 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                currentAgent.SetDestination(hit.point);
                actionsRemaining--;
                UpdateActionsRemainingText();
            }
        }
    }

    void UpdateAnimator()
    {
        if (currentAnimator != null)
        {
            float speed = currentAgent.velocity.magnitude;
            currentAnimator.SetFloat("SpeedRun", speed);
        }
    }

    public void ResetActions()
    {
        actionsRemaining = 5;
        UpdateActionsRemainingText();
    }

    private void UpdateActionsRemainingText()
    {
        if (actionsRemainingText != null)
        {
            actionsRemainingText.text = "Acciones restantes: " + actionsRemaining;
        }
    }

    public void ApplyDamage(float damage, NavMeshAgent enemy)
    {
        EnemyController enemyController = Object.FindObjectOfType<EnemyController>();
        if (enemyController != null)
        {
            float initialHealth = enemyController.GetHealth();
            Debug.Log("Vida inicial del enemigo: " + initialHealth);

            enemyController.ApplyDamage(damage, enemy);

            float finalHealth = enemyController.GetHealth();
            Debug.Log("Vida final del enemigo: " + finalHealth);
        }
    }
}
