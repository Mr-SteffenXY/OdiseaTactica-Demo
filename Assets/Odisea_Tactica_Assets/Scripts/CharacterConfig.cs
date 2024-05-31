using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configurations/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    public float health;
    public float armour;
    public float recoveryHealth;
    public float speed;
    public float attackPower;
    public float magicPower;
    public float attackRange;
    public float safeDistance;
    public float attackSpeed;
    public float magicCast;
    public float lifeDrain;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0) health = 0;
    }

    public bool IsDead()
    {
        return health <= 0;
    }
}
