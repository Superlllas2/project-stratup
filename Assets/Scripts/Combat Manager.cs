using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CombatManager : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI bossHealthText;

    public int playerHealth = 100;
    public int bossHealth = 100;

    private void Start()
    {
        StartCombat();
    }

    private void StartCombat()
    {
        // Reset health at the start of the combat
        playerHealth = 100;
        bossHealth = 100;

        UpdateHealthUI();
    }

    // Player attack
    public void PlayerAttack1()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        Debug.Log("Player attacks1 the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }
    
    // Player attack
    public void PlayerAttack2()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        Debug.Log("Player attacks2 the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }
    
    // Player attack
    public void PlayerUltimate()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        Debug.Log("Player attacks the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Boss attack
    public void BossAttack()
    {
        int damage = Random.Range(5, 15);  // Random damage
        playerHealth -= damage;
        Debug.Log("Boss attacks the Player for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Check if combat is over
    private void CheckCombatStatus()
    {
        if (playerHealth <= 0)
        {
            Debug.Log("Player has been defeated!");
        }
        if (bossHealth <= 0)
        {
            Debug.Log("Boss has been defeated!");
        }
    }

    // Update health UI
    private void UpdateHealthUI()
    {
        playerHealthText.text = "Player Health: " + playerHealth;
        bossHealthText.text = "Boss Health: " + bossHealth;
    }
}