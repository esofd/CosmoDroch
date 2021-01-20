using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private Vector3 rotationVector;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private float speed;
    public Transform target;
    private void Start()
    {
        rotationVector = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        rotationSpeed = Random.Range(1f, 5f);
        speed = Random.Range(1f, 2f);
        target = GameManager.instance.Player.transform;
    }
    void Update()
    {
        transform.Rotate(rotationVector * rotationSpeed * Time.deltaTime, Space.Self);

        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Death();
           
    }

    private void Death()
    {
        GameManager.instance.Player.Kills++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
                bullet.Explode();
            }
        }
        else if (other.tag == "Player")
        {
            GameManager.instance.Player.TakeDamage(1);
        }
    }
}
