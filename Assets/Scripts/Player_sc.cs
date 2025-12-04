using System.Collections;
using UnityEngine;

public class Player_sc : MonoBehaviour
{
    [Header("Hareket Ayarlari")]
    [SerializeField] private float speed = 5f;
    
    
    [Header("Ateşleme Ayarlari")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireInterval = 3f;

    [Header("Can Ayarlari")]
    [SerializeField] private int health = 100;


    void Start()
    {
        transform.position = Vector3.zero;
        InvokeRepeating("FireBullet", 0f, fireInterval);
    }

    void Update()
    {
        cubeMovement();
    }

    void cubeMovement()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f);

        if (movement.magnitude > 1f)
        movement.Normalize();

        transform.position += movement * speed * Time.deltaTime;

       

        // Ekranın sağ/sol sınırından çıkarsa diğer taraftan girsin (wrap)
        if (transform.position.x <= -9.4f)
            transform.position = new Vector3(9.4f, transform.position.y, 0);
        else if (transform.position.x >= 9.4f)
            transform.position = new Vector3(-9.4f, transform.position.y, 0);

        // Y ekseni sınırlandırma
        float clampedY = Mathf.Clamp(transform.position.y, -4.5f, 0f);
        transform.position = new Vector3(transform.position.x, clampedY, 0f);
    }

    void FireBullet()
    {
    Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    public void TakeDamage(int amount)
{
    health -= amount;

    if (health <= 0)
    {
        Debug.Log("Player öldü!");
        Destroy(gameObject);
    }
}

}