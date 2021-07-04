using UnityEngine;

//https://github.com/skillitronic/MyTools/tree/main/Assets/Scripts/Sound%20System 
[CreateAssetMenu(menuName = "Audio Files", fileName = "Create Audio file")]
public class AudioFile : ScriptableObject
{
    [SerializeField] private AudioClip _clip;
    public AudioClip AudioClip => _clip;
    
    [Range(0f,1f)]
    [SerializeField] private float _volume = 0.3f;
    public float Volume => _volume;

    [Space(15f)]
    [SerializeField] private bool _randomPitch = false;
    public bool RandomPitch => _randomPitch;

    [Tooltip("If you don't activate a random pitch, this variable will be used as a pitch for a sound")]
    [Range(-3f,3f)]
    [SerializeField] private float _minPitch = 1f;
    public float MinPitch => _minPitch;

    [Range(-3f, 3f)]
    [SerializeField] private float _maxPitch;
    public float MaxPitch => _maxPitch;

    [Space(15f)]
    [Tooltip("0 - 2d \n 1 - 3d")]
    [Range(0,1f)]
    [SerializeField] private float _spartalBlend;
    public float SpartalBlend => _spartalBlend;
}
