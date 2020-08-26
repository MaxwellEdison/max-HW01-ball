using UnityEngine.UI;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{

    Text score;
    Text health;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        health = GameObject.Find("Health").GetComponent<Text>();
        player = GameObject.Find("PlayerBall").GetComponent<Player>();
        health.color = Color.red;
        score.color = Color.green;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        score.text = "Score: " + player._currentScore;

        health.text = "Health: " + player._currentHealth;
    }
}
