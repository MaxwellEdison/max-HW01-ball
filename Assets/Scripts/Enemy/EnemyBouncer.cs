using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyBouncer : Enemy
{
    private Vector3 offset;
    public float thrust = 50.0f;

    private void Start()
    {
        thrust = thrust * -1f;
    }
    public override void PlayerImpact(Player player)
    {

        /*        Vector3 pPos = player.transform.position;
                Vector3 thrustVector = new Vector3 (0,0,0);
                float rho = Mathf.Sqrt(Mathf.Pow(pPos.x, 2) + Mathf.Pow(pPos.y,2) + Mathf.Pow(pPos.z,2));
                float theta = Mathf.Acos(pPos.x / rho);
        */
        offset = transform.position - player.transform.position;
        Debug.Log("Player offset = " + offset);
        Rigidbody pRig = player.GetComponent<Rigidbody>();
        pRig.AddForce(offset.x * thrust, offset.y*thrust,offset.z*thrust, ForceMode.VelocityChange);
        Debug.Log("boing");
    }
}
