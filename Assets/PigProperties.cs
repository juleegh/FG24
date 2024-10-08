using UnityEngine;

[CreateAssetMenu(fileName = "PigProperties", menuName = "Scriptable Objects/PigProperties")]
public class PigProperties : ScriptableObject
{
    [SerializeField] private Color maskColor;
    [SerializeField] private float walkingSpeed;
    [SerializeField] private string codeName;
    [SerializeField] private bool badPig;

    public float WalkingSpeed()
    {
        return walkingSpeed;
    }

    public Color MaskColor()
    {
        return maskColor;
    }

    public string CodeName()
    {
        return codeName;
    }

    public bool BadPig()
    {
        return badPig;
    }
}
