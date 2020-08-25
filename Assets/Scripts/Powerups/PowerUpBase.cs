using UnityEditor.MemoryProfiler;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{


    [SerializeField] float _movementBonus = 1;
    [SerializeField] ParticleSystem _powerParticles;
    [SerializeField] AudioClip _powerSound;
    public float powerDur = 10f;
    public bool invincible;
    public float timeLeft;
    bool powerUp;
    Rigidbody _rb;
    float duration;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            //spawn particles & sfx
            Feedback();
            gameObject.SetActive(false);
        }
    }

    protected abstract void PowerUp(Player player);

    protected abstract void PowerDown(Player player);

    protected float MovementBonus
    {
        get
        {
            return _movementBonus;
        }
    }

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody>();
    }

   private void FixedUpdate()
    {
        if (invincible == true)
        {
            float timeLeft = powerDur - Time.deltaTime;
            Debug.Log("time left =" + timeLeft);
            if (timeLeft <= 0)
            {
                invincible = false;
                Player player = GameObject.Find("PlayerBall").GetComponent<Player>();
                PowerDown(player);
                Debug.Log("powering down");
            }
        }
    }

    private void Feedback()
    {
        //particles
        if (_powerParticles != null)
        {
            _powerParticles = Instantiate(_powerParticles, transform.position, Quaternion.identity);
        }
        //audio
        if (_powerSound != null)
        {
            AudioHelper.PlayClip2D(_powerSound, 1f);
        }
    }
}
