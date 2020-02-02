using UnityEngine;

public class CustomImageEffect : MonoBehaviour
{
    public Material EffectMaterial;

    public float minDisplacement;
    public float maxDisplacement;
    private float t = 0;

    private void Update()
    {
        t += (Time.deltaTime);
        if (t > 256)
        {
            t -= 256;
        }

        float magValue = Mathf.PerlinNoise(t, 0);
        magValue = magValue * (maxDisplacement - minDisplacement);
        magValue = minDisplacement + magValue;


        EffectMaterial.SetFloat("_Magnitude", (magValue));
    }

    void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        if (EffectMaterial != null)
            Graphics.Blit(src, dst, EffectMaterial);
    }
}