
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [Header("----Audio Clip----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("----Audio Clip----")]
    public AudioClip background;
    public AudioClip wind;
    public AudioClip steps;
    

    private void Start()
    {
        musicSource.clip =background;
        musicSource.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
