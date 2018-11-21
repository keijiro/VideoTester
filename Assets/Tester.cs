using UnityEngine;
using UnityEngine.UI;

public class Tester : MonoBehaviour
{
    [SerializeField] Text _text = null;
    [SerializeField, HideInInspector] Shader _shader = null;

    Material _material;

    void Start()
    {
    #if UNITY_IOS
        Application.targetFrameRate = 60;
    #endif
    }

    void Update()
    {
        _text.text = Time.frameCount.ToString("000000");
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (_material == null) _material = new Material(_shader);
        _material.SetInt("_FrameCount", Time.frameCount);
        Graphics.Blit(source, destination, _material);
    }
}
