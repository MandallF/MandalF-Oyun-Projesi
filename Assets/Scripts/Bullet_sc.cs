using UnityEngine;

public class Bullet_sc : MonoBehaviour
{
    [Header("Hareket Ayarlari")]
    [SerializeField] private float speed = 10f;
    [SerializeField] private float maxY = 5.34f;
    
    [Header("Hasar Ayarlari")]
    [SerializeField] private int damage = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    transform.Translate(Vector3.up * speed * Time.deltaTime);

    if (transform.position.y > maxY)
    {
        Destroy(gameObject);
    }  
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) 
        {
        other.GetComponent<Enemy_sc>().TakeDamage(damage);

            Destroy(gameObject);
        }
    }
}
