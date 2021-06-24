using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio", menuName = "New Track")]
public class SoundSO : ScriptableObject
{
    public new string name;
    public AudioClip clip;
    public AudioSource source;

    [Range(0f, 1f)]
    public float volume;

    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
}
