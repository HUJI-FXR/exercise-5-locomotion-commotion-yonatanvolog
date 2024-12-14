using TMPro;
using UnityEngine;

public class EndgameMessageScript : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    
    public void Lose()
    {
        if (textMesh != null)
        {
            textMesh.enabled = true;
            textMesh.text = "You Lost!";
        }
    }

    public void Win()
    {
        if (textMesh != null)
        {
            textMesh.enabled = true;
            textMesh.text = "You Won!";
        }
    }
}