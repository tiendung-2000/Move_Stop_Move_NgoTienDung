using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Transform playerTF;
    public Sound[] sounds;
    public float maxDistance;

    public static AudioManager instance;
    private void Awake()
    {
        instance = this;
    }
    public void Play(SoundType type)
    {
        int index = (int)type;
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sounds[index].clip;
        audioSource.volume = sounds[index].volume;
        audioSource.pitch = sounds[index].pitch;
        audioSource.Play();
    }

    public bool IsInDistance(Transform tf)
    {
        float dis = Vector3.Distance(tf.position, playerTF.position);
        if(dis < maxDistance)
        {
            return true;
        }
        return false;
    }
}
