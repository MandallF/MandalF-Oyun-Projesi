using UnityEngine;

public class Enemy_sc : MonoBehaviour
{
    [Header("Hareket Ayarlari")]
    [SerializeField] private float speed = 2f;   
    [SerializeField] private float leftLimit = -7.34f;
    [SerializeField] private float rightLimit = 7.34f;

    private bool movingRight = true;

    [Header("Can Ayarlari")]
    [SerializeField] private int health = 1000;

    void Start()
    {
        transform.position = new Vector3(0f, 3.33f, 0f);
    }

    void Update()
    {
        enemyMovement();
    }

    void enemyMovement()
    {
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

            if (transform.position.x >= rightLimit)
                movingRight = false;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

            if (transform.position.x <= leftLimit)
                movingRight = true;
        }
    }

     public void TakeDamage(int amount)
    {
        health -= amount;
        Debug.Log("Enemy Health: " + health);

        if (health <= 0)
        {
            Debug.Log("Enemy öldü!");
            Destroy(gameObject);
        }
    }
}
