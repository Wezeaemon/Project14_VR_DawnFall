using UnityEngine;

public class ScriptDestroyEverthing : MonoBehaviour
{
   [SerializeField] private float Timer;
   [SerializeField] private float CurrentTimer;
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
          gameObject.SetActive(false);
          Timer = CurrentTimer;
        }
    }
}
