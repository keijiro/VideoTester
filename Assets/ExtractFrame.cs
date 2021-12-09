using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Rendering;
using UnityEngine.Video;
using System.IO;

sealed class ExtractFrame : MonoBehaviour
{
    [SerializeField] VideoPlayer _video = null;

    void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        var src = _video.texture;

        AsyncGPUReadback.Request(src, 0, (AsyncGPUReadbackRequest req) => {
          var bytes = ImageConversion.EncodeNativeArrayToPNG
            (req.GetData<byte>(), src.graphicsFormat,
             (uint)src.width, (uint)src.height, (uint)src.width * 4);
          File.WriteAllBytes("Frame.png", bytes.ToArray());
        });
    }
}
