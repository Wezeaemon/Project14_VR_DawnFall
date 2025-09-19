using UnityEngine;

public class AILuka : MonoBehaviour
{
    // Use this for initialization
	void Start ( ) {
		
	}

    enum Around {
        stop,
        up,
        down,
        left,
        right
    }

    public string ShootGunOn;
    public string ShootGunOff;
    public string Luka;
    public string LukaWho;
    [SerializeField] GameObject Shoot;
    private Around rotateTo = Around.stop;
    public AudioSource audioSource;
    public AudioClip ImHere;
    public AudioClip WhoAreYou;
    private float _speed = 0.5f;
	
	// Update is called once per frame
	void Update ( ) {
          
	}
 
   
        public void onReceiveRecognitionResult(string result)
{
    result = result.ToLower();
     if (result.Contains(ShootGunOn.ToLower()))
    {
           Shoot.SetActive(true);
    }
    
     if (result.Contains(ShootGunOff.ToLower()))
     {
        Shoot.SetActive(false);
     }
     if (result.Contains(Luka.ToLower()))
        {
            Debug.Log("Có");
            audioSource.clip = ImHere;
            audioSource.Play();
        }

    if (result.Contains(LukaWho.ToLower()))
    {
        Debug.Log("Có");
        audioSource.clip = WhoAreYou;
        audioSource.Play();
    }
   
       
      

   
}

    }
 
