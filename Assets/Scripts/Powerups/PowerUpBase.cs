using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    [SerializeField] ParticleSystem _powerParticles;
    [SerializeField] AudioClip _powerSound;
    Player player;
    public float powerDur;
    public bool invincible;
    public float timeLeft;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            PowerUp(player);
            //spawn particles & sfx
            
            Feedback();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            timeLeft = powerDur;
        }
    }

    protected abstract void PowerUp(Player player);

    protected abstract void PowerDown(Player player);

    private void Awake()
    {
        player = GameObject.Find("PlayerBall").GetComponent<Player>();
    }

   private void FixedUpdate()
    {
        if (invincible == true)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log("time left =" + timeLeft);
            //_powerParticles = Instantiate(_powerParticles, player.transform.position, Quaternion.identity);
            if (timeLeft <= 0)
            {

                invincible = false;


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
