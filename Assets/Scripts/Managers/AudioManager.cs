using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public void PlaySound(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}