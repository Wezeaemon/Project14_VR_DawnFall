using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class ObjectBulletZomboo : MonoBehaviour
{
    [SerializeField] private int Amount;
    public GameObject Bullet;
    public static List<GameObject> ObjectPool = new List<GameObject>();
    public static  ObjectBulletZomboo instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        for (int i = 0; i < Amount; i++)
        {
            GameObject SpawnBullet = Instantiate(Bullet);
            SpawnBullet.SetActive(false);
            ObjectPool.Add(SpawnBullet);
        }
    }

    public GameObject GetObjectToPool()
    {
        for(int i = 0; i < ObjectPool.Count; i++)
        {
            if(!ObjectPool[i].activeInHierarchy)
            {
                return ObjectPool[i];
            }
        }
        return null;
    }
}
