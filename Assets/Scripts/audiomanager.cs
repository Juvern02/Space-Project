
using UnityEngine;

public class audiomanager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;

    private void Start()
    {
        musicSource.clip =background;
        musicSource.Play();
    }
}
