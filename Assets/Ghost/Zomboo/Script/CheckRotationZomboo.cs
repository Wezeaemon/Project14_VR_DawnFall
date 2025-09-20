using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class CheckRotationZomboo : MonoBehaviour
{
    [SerializeField] Transform RotationPlayer;
    [SerializeField] Transform Target;
    [SerializeField] private float Speed;
    [SerializeField] private string Name;
    [Range(1,30)]
    [SerializeField] private float Range;
    [SerializeField] NavMeshAgent navMeshAgent;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Enimes = GameObject.FindGameObjectsWithTag(Name);
        float ShortDistance = Mathf.Infinity;
        GameObject ResetEnemy = null;
        foreach(GameObject Enemy in Enimes)
        {
            float distance = Vector3.Distance(Enemy.transform.position, transform.position);
            if(ShortDistance > distance)
            {
                ShortDistance = distance;
                ResetEnemy = Enemy;
            }
             if(ResetEnemy != null && ShortDistance <= Range)
            {
                ResetEnemy = Enemy;
                Target = ResetEnemy.transform;
                Target = GameObject.FindGameObjectWithTag(Name).GetComponent<Transform>();
                  Target = ResetEnemy.transform;
                if(Vector3.Distance(Enemy.transform.position, transform.position) <= 5f)
                {
                       Vector3 dir = (transform.position - Target.position).normalized;

            // Điểm đích: vị trí target cộng với hướng ngược, cách ra keepDistance
            Vector3 newPos = Target.position + dir * 5f;

            navMeshAgent.SetDestination(newPos);
                  
                }
                else
                {
                    navMeshAgent.SetDestination(  Target.position);
                }
               
            }
            ResetEnemy = Enemy;
             Target = ResetEnemy.transform;
             Target = GameObject.FindGameObjectWithTag(Name).GetComponent<Transform>();
             LookRotatePlayer();
        }
    }
    public void LookRotatePlayer()
    {
       Vector3 Dir = Target.position - transform.position;
       Quaternion  LookDir = Quaternion.LookRotation(Dir);
       Vector3 rotation = Quaternion.Lerp(RotationPlayer.rotation, LookDir, Speed * Time.deltaTime).eulerAngles;
       RotationPlayer.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }
    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
