using UnityEngine;
using TMPro;

public class LifeBarScript : MonoBehaviour
{
    [SerializeField] private LifeTotalScript playerLifeTotalScript;
    private TextMeshProUGUI lifeBarText;

    private void Awake()
    {
        lifeBarText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playerLifeTotalScript != null)
        {
            float lifeTotal = playerLifeTotalScript.GetLifeTotal();
            lifeBarText.text = "HP: " + (int)lifeTotal;
        }
        else
        {
            lifeBarText.text = "HP: N/A";
        }
    }
}
