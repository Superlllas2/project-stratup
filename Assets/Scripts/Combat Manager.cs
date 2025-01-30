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

    public GameObject playerDefeatedImage;  // Image to show when the player is defeated
    public GameObject bossDefeatedImage;    // Image to show when the boss is defeated

    private void Start()
    {
        StartCombat();
    }

    private void StartCombat()
    {
        // Reset health at the start of the combat
        playerHealth = 100;
        bossHealth = 100;

        // Hide defeat images at the start
        playerDefeatedImage.SetActive(false);
        bossDefeatedImage.SetActive(false);

        UpdateHealthUI();
    }

    // Player attack
    public void PlayerAttack1()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        bossHealth = Mathf.Max(bossHealth, 0);  // Ensure boss health does not go below 0
        Debug.Log("Player attacks1 the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Player attack
    public void PlayerAttack2()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        bossHealth = Mathf.Max(bossHealth, 0);  // Ensure boss health does not go below 0
        Debug.Log("Player attacks2 the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Player ultimate attack
    public void PlayerUltimate()
    {
        int damage = Random.Range(10, 20); // Random damage for now
        bossHealth -= damage;
        bossHealth = Mathf.Max(bossHealth, 0);  // Ensure boss health does not go below 0
        Debug.Log("Player attacks the Boss for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Boss attack
    public void BossAttack()
    {
        int damage = Random.Range(5, 15);  // Random damage
        playerHealth -= damage;
        playerHealth = Mathf.Max(playerHealth, 0);  // Ensure player health does not go below 0
        Debug.Log("Boss attacks the Player for " + damage + " damage!");
        CheckCombatStatus();
        UpdateHealthUI();
    }

    // Check if combat is over
    private void CheckCombatStatus()
    {
        if (playerHealth <= 0)
        {
            playerHealth = 0; // Ensure player health is exactly 0
            Debug.Log("Player has been defeated!");
            playerDefeatedImage.SetActive(true);  // Show player defeat image
        }

        if (bossHealth <= 0)
        {
            bossHealth = 0; // Ensure boss health is exactly 0
            Debug.Log("Boss has been defeated!");
            bossDefeatedImage.SetActive(true);    // Show boss defeat image
        }
    }

    // Update health UI
    private void UpdateHealthUI()
    {
        playerHealthText.text = "Player Health: " + playerHealth;
        bossHealthText.text = "Boss Health: " + bossHealth;
    }
}
