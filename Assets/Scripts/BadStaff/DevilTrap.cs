using UnityEngine;

public class DevilTrap : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;

    private bool hasTriggered = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return;  

        if (other.CompareTag("Player"))
        {
            GameEvents.RaisePlayerDamaged(damageAmount);
            hasTriggered = true;
        }
    }
}


