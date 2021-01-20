using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int startLives = 3;
    [SerializeField]
    private int lives = 3;
    public int Lives { get { return lives; } set { lives = value; OnLivesChange.Invoke(); } }
    public UnityEvent OnLivesChange;
    private int kills = 0;
    public int Kills { get { return kills; } set { kills = value; OnKillsChange.Invoke(); } }
    public UnityEvent OnKillsChange;
    public float rotationSpeed = 25f;
    // Start is called before the first frame update
    public float fireRate = 0.5f;
    private float fireCooldown;
    public List<GameObject> firePoints;

    public GameObject bulletPrefab;
    private void Awake()
    {
        Kills = 0;
        Lives = startLives;
        OnLivesChange = new UnityEvent();
        OnKillsChange = new UnityEvent();
        fireCooldown = fireRate;
    }
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Rotate(Vector3.left * Input.GetAxis("Vertical") * rotationSpeed * Time.deltaTime, Space.Self);
        }
        fireCooldown -= Time.deltaTime;
        if (fireCooldown <= 0f)
            Fire();
    }


    void Fire()
    {
        foreach (GameObject firePoint in firePoints)
        {
            Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        }
        fireCooldown = fireRate;
    }

    public void TakeDamage(int damage)
    {
        Lives-= damage;
        if (Lives<=0)
        {
            GameManager.GameOver();
        }
    }
}
