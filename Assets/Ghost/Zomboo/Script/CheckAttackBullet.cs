using UnityEngine;

public class CheckAttackBullet : MonoBehaviour
{
   [SerializeField] private float Timer;
   [SerializeField] private float CurrentTimer;
   [SerializeField] private float Speed;
   [SerializeField] private float Speedx2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        if(Timer <= 0)
        {
            GameObject SpawnBullet = ObjectBulletZomboo.instance.GetObjectToPool();
            SpawnBullet.transform.position = transform.position;
            SpawnBullet.transform.rotation = transform.rotation;
            SpawnBullet.SetActive(true);
            SpawnBullet.GetComponent<Rigidbody>().linearVelocity = transform.forward * Speed * Speedx2; 
            Timer = CurrentTimer;
        }
    }
}
