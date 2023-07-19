[System.Serializable]
public class Extremum
{
    public float minLimit;
    public float maxLimit;

    public float GetRandomValue()
    {
        return UnityEngine.Random.Range(minLimit, maxLimit);
    }
}
