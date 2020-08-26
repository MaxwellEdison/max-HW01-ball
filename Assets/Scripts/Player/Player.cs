using UnityEngine;

[RequireComponent(typeof(BallMotor))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    public int _currentHealth;
    public  bool freezeHealth = false;
    [SerializeField] public int _currentScore;
    BallMotor _ballMotor;

    private void Awake()
    {
        _ballMotor = GetComponent<BallMotor>();
    }

    private void Start()
    {
        //set current health to max health on start
        _currentHealth = _maxHealth;
        _currentScore = 0;
    }


    private void FixedUpdate()
    {
        ProcessMovement();  
    }

    private void ProcessMovement()
    {
        //TODO move into Input script
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical).normalized;

        _ballMotor.Move(movement);
    }
    //increases health by int 'amount'
    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("player's health: " + _currentHealth);
    }
    //decreases health by int 'amount'
    public void DecreaseHealth(int amount)
    {
        if (freezeHealth != true)
        {
            _currentHealth -= amount;
            Debug.Log("Player's health: " + _currentHealth);

            //if health is less than or equal to 0, kill player
            if (_currentHealth <= 0)
            {
                Kill();
                //X n X
            }
        } 


    }

    public void keepScore(int amount)
    {
        _currentScore += amount;
        Debug.Log("Player Score: " + _currentScore);
    }    

    //how do I kill?
    public void Kill()
    {
        if (freezeHealth != true) 
        {
            gameObject.SetActive(false);
        }

        //play particles
        //play sounds
    }

}
