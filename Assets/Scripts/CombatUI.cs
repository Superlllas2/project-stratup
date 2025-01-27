using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CombatUI : MonoBehaviour
{
    public Button attackButton1;  // Button to attack
    public Button attackButton2;  // Button to attack
    public Button ultimateButton;  // Button to attack
    public CombatManager combatManager;
    
    public Image attackButton1Timer;  // Pie timer for Attack 1
    public Image attackButton2Timer;  // Pie timer for Attack 2
    public Image ultimateButtonTimer;
    
    public float attackCooldownTime = 2f;    // Cooldown time for normal attacks
    public float ultimateCooldownTime = 5f;  // Cooldown time for ultimate attack

    private bool isAttackButton1OnCooldown = false;
    private bool isAttackButton2OnCooldown = false;
    private bool isUltimateButtonOnCooldown = false;

    void Start()
    {
        attackButton1.onClick.AddListener(OnAttack1Clicked);
        attackButton2.onClick.AddListener(OnAttack2Clicked);
        ultimateButton.onClick.AddListener(OnUltimateClicked);
    }

// Trigger Attack 1 when the button is clicked
    private void OnAttack1Clicked()
    {
        if (!isAttackButton1OnCooldown)
        {
            combatManager.PlayerAttack1();  // Let combat manager handle the player's attack
            StartCoroutine(ButtonCooldown(attackButton1, attackCooldownTime, 1));
        }
    }

    // Trigger Attack 2 when the button is clicked
    private void OnAttack2Clicked()
    {
        if (!isAttackButton2OnCooldown)
        {
            combatManager.PlayerAttack2();  // Let combat manager handle the player's attack
            StartCoroutine(ButtonCooldown(attackButton2, attackCooldownTime, 2));
        }
    }

    // Trigger Ultimate Attack when the button is clicked
    private void OnUltimateClicked()
    {
        if (!isUltimateButtonOnCooldown)
        {
            combatManager.PlayerUltimate();  // Let combat manager handle the player's ultimate attack
            StartCoroutine(ButtonCooldown(ultimateButton, ultimateCooldownTime, 3));
        }
    }

    // Handles cooldown for each button
    private IEnumerator ButtonCooldown(Button button, float cooldownTime, int buttonType)
    {
        if (buttonType == 1)
            isAttackButton1OnCooldown = true;
        else if (buttonType == 2)
            isAttackButton2OnCooldown = true;
        else if (buttonType == 3)
            isUltimateButtonOnCooldown = true;

        button.interactable = false;  // Disable the button to prevent further clicks
        
        Image timerImage = GetTimerImage(buttonType);  // Get the correct timer image
        float elapsedTime = 0f;

        // Wait for the cooldown period to finish
        while (elapsedTime < cooldownTime)
        {
            elapsedTime += Time.deltaTime;
            float fillAmount = Mathf.Lerp(0, 1f, elapsedTime / cooldownTime);  // Decrease fill amount from 1 to 0
            timerImage.fillAmount = fillAmount;  // Update the pie timer's fill amount
            yield return null;
        }

        // Reset pie timer and re-enable the button after cooldown
        button.interactable = true;
        timerImage.fillAmount = 1f;  // Reset fill amount

        if (buttonType == 1)
            isAttackButton1OnCooldown = false;
        else if (buttonType == 2)
            isAttackButton2OnCooldown = false;
        else if (buttonType == 3)
            isUltimateButtonOnCooldown = false;
    }
    
    // Get the appropriate timer image based on button type
    private Image GetTimerImage(int buttonType)
    {
        if (buttonType == 1)
            return attackButton1Timer;
        else if (buttonType == 2)
            return attackButton2Timer;
        else
            return ultimateButtonTimer;
    }
}