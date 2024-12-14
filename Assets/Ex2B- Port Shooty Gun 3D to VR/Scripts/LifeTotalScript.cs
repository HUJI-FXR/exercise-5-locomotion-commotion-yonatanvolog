using UnityEngine;

public class LifeTotalScript : MonoBehaviour
{
    [SerializeField] private float initialLifeTotal = 100f;
    private float lifeTotal;
    private ScoreScript scoreScript;
    private HighScoreScript highScoreScript;
    private MonsterHolderScript monsterHolder;
    private EndgameMessageScript endGameMessage;


    private void Start()
    {
        lifeTotal = initialLifeTotal;
        scoreScript = FindObjectOfType<ScoreScript>(); // player's score
        highScoreScript = FindObjectOfType<HighScoreScript>(); // player's highscore
        monsterHolder = FindObjectOfType<MonsterHolderScript>();
        endGameMessage = FindObjectOfType<EndgameMessageScript>();

    }

    public float GetInitialLifeTotal()
    {
        return initialLifeTotal;
    }
    
    public void TakeDamage(float damage)
    {
        lifeTotal -= damage;
        if (lifeTotal <= 0)
        {
            if (CompareTag("Monster"))
            {
                if (scoreScript != null)
                {
                    scoreScript.AddScore();
                }
            }
            if ((CompareTag("Player") || monsterHolder.IsLast()) && highScoreScript != null)
            {
                if(CompareTag("Player"))
                {
                    endGameMessage.Lose();
                }
                else if (monsterHolder.IsLast())
                {
                    endGameMessage.Win();
                }
                highScoreScript.CheckAndSaveHighScore();
            }
            Destroy(gameObject);
        }
    }


    public void Heal(float healAmount)
    {
        lifeTotal = Mathf.Min(lifeTotal + healAmount, initialLifeTotal);
    }

    public float GetLifeTotal()
    {
        return lifeTotal;
    }
}
