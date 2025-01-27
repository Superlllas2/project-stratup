using UnityEngine;

public class BossAI : MonoBehaviour
{
    public CombatManager combatManager;
    public float attackDelay = 2f; // Time between each boss attack

    private void Start()
    {
        InvokeRepeating("BossAttack", attackDelay, attackDelay);
    }

    private void BossAttack()
    {
        combatManager.BossAttack(); // Call combat manager for boss attack
    }
}