using UnityEngine;
using TMPro;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private string winnerMessage = "WINNER ";
    [SerializeField] private bool pauseOnWin = true;
    [SerializeField] private TMP_Text winnerText;

    private void Start()
    {
        if (winnerText != null)
        {
            winnerText.gameObject.SetActive(false);
            winnerText.text = "";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        winnerText.gameObject.SetActive(true);
        winnerText.text = winnerMessage;
    }
}
