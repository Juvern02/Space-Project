
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("----Audio Clip----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("----Audio Clip----")]
    public AudioClip background;
    public AudioClip wind;

    public static audiomanager instance;

    private void Awake()
    {
        if (instance == null)
        {       
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip =background;
        musicSource.Play();
    }
}
