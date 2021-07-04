using UnityEngine;

//Could use easier system, but wanted to try out my own.
//https://github.com/skillitronic/MyTools/tree/main/Assets/Scripts/Sound%20System
public static class AudioSystem
{
    public static void PlaySFX(GameObject target,AudioFile file)
    {
        AudioSource src = target.AddComponent<AudioSource>();

        src.clip = file.AudioClip;
        src.volume = file.Volume;

        if (file.RandomPitch)
        {
            float randomNumber = Random.Range(file.MinPitch, file.MaxPitch);
            src.pitch = randomNumber;
        }
        else
        {
            src.pitch = file.MinPitch;
        }

        src.spatialBlend = file.SpartalBlend;

        src.Play();

        Object.Destroy(src, src.clip.length);
    }

    public static void PlaySFX(Vector3 pos, AudioFile file)
    {
        GameObject go = new GameObject("OneShot Audio");
        go.transform.position = pos;
        AudioSource src = go.AddComponent<AudioSource>();

        src.clip = file.AudioClip;
        src.volume = file.Volume;

        if (file.RandomPitch)
        {
            float randomNumber = Random.Range(file.MinPitch, file.MaxPitch);
            src.pitch = randomNumber;
        }
        else
        {
            src.pitch = file.MinPitch;
        }

        src.spatialBlend = file.SpartalBlend;

        src.Play();

        Object.Destroy(go, src.clip.length);
    }

    public static void PlaySFX(AudioFile file)
    {
        GameObject go = new GameObject("OneShot Audio");
        go.transform.position = Vector3.zero;
        AudioSource src = go.AddComponent<AudioSource>();

        src.clip = file.AudioClip;
        src.volume = file.Volume;

        if (file.RandomPitch)
        {
            float randomNumber = Random.Range(file.MinPitch, file.MaxPitch);
            src.pitch = randomNumber;
        }
        else
        {
            src.pitch = file.MinPitch;
        }

        src.spatialBlend = file.SpartalBlend;

        src.Play();

        Object.Destroy(go, src.clip.length);
    }

    public static void PlayAudio(GameObject target, AudioFile file, bool loop = false)
    {
        AudioSource src = target.AddComponent<AudioSource>();

        src.clip = file.AudioClip;
        src.volume = file.Volume;

        if (file.RandomPitch)
        {
            float randomNumber = Random.Range(file.MinPitch, file.MaxPitch);
            src.pitch = randomNumber;
        }
        else
        {
            src.pitch = file.MinPitch;
        }

        src.spatialBlend = file.SpartalBlend;
        src.loop = loop;

        src.Play();
    }
}
