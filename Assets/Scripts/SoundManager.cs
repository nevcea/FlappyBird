using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [Header("Sound Clips")]
    [SerializeField] private AudioClip wingSound;
    [SerializeField] private AudioClip pointSound;
    [SerializeField] private AudioClip dieSound;
    [SerializeField] private AudioClip swooshSound;
    [SerializeField] private AudioClip hitSound;

    [Header("Audio Settings")]
    [Range(0, 1)] public float masterVolume = 1f;
    private AudioSource audioSource;

    public void PlayWing() => Play(wingSound, 0.3f);
    public void PlayPoint() => Play(pointSound, 0.7f);
    public void PlayDie() => Play(dieSound, 0.5f);
    public void PlaySwoosh() => Play(swooshSound, 0.6f);
    public void PlayHit() => Play(hitSound, 0.6f);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    private void Play(AudioClip clip, float volumeScale = 1f)
    {
        if (clip != null)
        {
            audioSource.PlayOneShot(clip, masterVolume * volumeScale);
        }
        else
        {
            Debug.LogWarning("사운드 클립이 할당되지 않았습니다!");
        }
    }
}
