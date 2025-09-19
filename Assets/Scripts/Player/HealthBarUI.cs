using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;   
    [SerializeField] private Image fillImage;             
    [SerializeField] private TMP_Text hpText;             
    [SerializeField] private bool hideWhenFull = false;   

    void Awake()
    {
        if (!playerHealth) playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void LateUpdate()
    {
        if (!playerHealth || !fillImage) return;

        float pct = Mathf.Clamp01(
            playerHealth.CurrentHealthPoints / (float)playerHealth.MaxHealthPoints
        );

        fillImage.fillAmount = pct;

        if (hpText) hpText.text = Mathf.RoundToInt(pct * 100f) + "%";

        if (hideWhenFull)
            fillImage.transform.parent.gameObject.SetActive(pct < 0.999f);
    }
}
