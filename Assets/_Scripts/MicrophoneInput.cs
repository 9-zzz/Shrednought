using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public float loudness = 0.0f;
    public float frequency = 0.0f;
    public int samplerate = 48000;

    private AudioSource audio_source;

    void Start()
    {
        audio_source = GetComponent<AudioSource>();
        audio_source.clip = Microphone.Start(Microphone.devices[0], true, 10, samplerate);
        audio_source.loop = true; // Set the AudioClip to loop
        //audio_source.mute = true; // Mute the sound, we don't want the player to hear it
        while (!(Microphone.GetPosition(Microphone.devices[0]) > 0)) { } // Wait until the recording has started
        audio_source.Play(); // Play the audio source!
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
        Debug.Log(loudness);
        if (loudness > 1)
        {
            frequency = GetFundamentalFrequency();
        }
        else 
        {
            frequency = 0;
        }
        //Debug.Log(frequency);
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audio_source.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    float GetFundamentalFrequency()
    {
        float fundamentalFrequency = 0.0f;
        float[] data = new float[8192];
        audio_source.GetSpectrumData(data, 0, FFTWindow.BlackmanHarris);
        float s = 0.0f;
        int i = 0;
        for (int j = 1; j < 4096; j++)
        {
            if (s < data[j])
            {
                s = data[j];
                i = j;
            }
        }
        fundamentalFrequency = i * samplerate / 8192;
        return fundamentalFrequency;
    }
}
