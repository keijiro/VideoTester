using UnityEngine;

sealed class Generator : MonoBehaviour
{
    [SerializeField] Shader _shader = null;

    Material _material;

    void Start()
      => _material = new Material(_shader);

    void OnDestroy()
      => Destroy(_material);

    void OnRenderImage(RenderTexture source, RenderTexture destination)
      => Graphics.Blit(source, destination, _material, 0);
}
