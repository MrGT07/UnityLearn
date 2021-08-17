using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody enemyRB;
    private GameObject player;
    public float speed;

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);
        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
