using UnityEngine;
public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip pop;

    public void PlayPopSound()
    {
        src.clip = pop;
        src.Play();
    }
}
