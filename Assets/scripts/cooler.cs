using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CameraController : MonoBehaviour
{
    PostProcessVolume postProcessVolume;
    ColorGrading colorGradingLayer;

    void Start()
    {
        postProcessVolume = GetComponent<PostProcessVolume>();
        postProcessVolume.profile.TryGetSettings(out colorGradingLayer);
    }

    void Update()
    {
        // Adjust the color grading settings
        colorGradingLayer.colorFilter.value = Color.white;
    }
}