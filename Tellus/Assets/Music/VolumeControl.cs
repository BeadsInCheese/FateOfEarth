
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer; // The audio mixer to control
    public Slider slider; // The UI slider to adjust the volume
    public string parameterName; // The name of the exposed parameter in the mixer

    void Start()
    {
        // Set the slider value to match the mixer volume
        float value;
        mixer.GetFloat(parameterName, out value);
        slider.value = (value + 80 )/ ( 100);

        // Add a listener to the slider's onValueChanged event
        slider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float value)
    {
        // Set the mixer volume to match the slider value
        mixer.SetFloat(parameterName, -80+100*value);
    }
}

