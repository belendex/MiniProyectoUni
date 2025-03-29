using UnityEngine;

public class RobotFace : MonoBehaviour
{
    public Texture faceHappy; // Asigna la textura de la cara contenta
    public Texture faceAngry; // Asigna la textura de la cara enojada
    private Renderer faceRenderer;

    void Start()
    {
        faceRenderer = GetComponent<Renderer>();
        SetHappyFace();
    }

    public void SetHappyFace()
    {
        faceRenderer.material.mainTexture = faceHappy;
    }

    public void SetAngryFace()
    {
        faceRenderer.material.mainTexture = faceAngry;
    }
}
