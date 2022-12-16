using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    [SerializeField] private AudioClip[] _music;
    [SerializeField] private AudioSource _source;
    private int _num = 0;

    private void Start()
    {
        _source = GetComponent<AudioSource>();
        _source.clip = _music[0];
        _source.Play();
    }

    private void Update()
    {
        if (_source.isPlaying)
            return;
        _num++;
        _source.clip = _music[_num % 4];
        _source.Play();
    }
}
