using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("AudioSources")]
    [SerializeField] private AudioSource moving;
    [SerializeField] private AudioSource jump;

    [Header("AudioClips")]
    [SerializeField] private AudioClip walk;
    [SerializeField] private AudioClip run;
    public void AudioWalk()
    {
        if(!moving.isPlaying)
            moving.PlayOneShot(walk);
    }
    public void AudioJump()
    {
        jump.Play();
    }
    public void AudioRun()
    {
        if (!moving.isPlaying)
            moving.PlayOneShot(run);
    }
}
