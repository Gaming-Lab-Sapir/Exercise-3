using UnityEngine;
using TMPro;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private string winnerMessage = "WINNER ";
    [SerializeField] private bool pauseOnWin = true;
    [SerializeField] private TMP_Text winnerText;
    [SerializeField] private TMP_Text level1Text;
    [SerializeField] private TMP_Text level2Text;
    [SerializeField] private TMP_Text level3Text;

    private int currentLevel = 1;

    [SerializeField] private int totalLevels = 3;   
    private int completedLevels = 0;                
    private bool pausedByFinish = false;
    [SerializeField] private bool resumeOnAnyKey = true;

    private void Start()
    {
        if (winnerText != null) { winnerText.gameObject.SetActive(false); winnerText.text = ""; }
        if (level1Text != null) level1Text.gameObject.SetActive(false);
        if (level2Text != null) level2Text.gameObject.SetActive(false);
        if (level3Text != null) level3Text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (!other.CompareTag("Player")) return;

        if (level1Text) level1Text.gameObject.SetActive(false);
        if (level2Text) level2Text.gameObject.SetActive(false);
        if (level3Text) level3Text.gameObject.SetActive(false);
        if (winnerText) winnerText.gameObject.SetActive(false);

        if (completedLevels < totalLevels)
        {
            int next = completedLevels + 1; 
            if (next == 1 && level1Text) level1Text.gameObject.SetActive(true);
            if (next == 2 && level2Text) level2Text.gameObject.SetActive(true);
            if (next == 3 && level3Text) level3Text.gameObject.SetActive(true);

            completedLevels++;   
        }
        if (completedLevels >= totalLevels && winnerText)
        {
            winnerText.gameObject.SetActive(true);
            winnerText.text = winnerMessage;   
        }

        if (pauseOnWin)
        {
            Time.timeScale = 0f;
            pausedByFinish = true;
        }
    }

    private void Update()
    {
        if (resumeOnAnyKey && pausedByFinish && Input.anyKeyDown)
        {
            Time.timeScale = 1f;
            pausedByFinish = false;

            if (level1Text) level1Text.gameObject.SetActive(false);
            if (level2Text) level2Text.gameObject.SetActive(false);
            if (level3Text) level3Text.gameObject.SetActive(false);
            if (winnerText) winnerText.gameObject.SetActive(false);
        }
    }
}
