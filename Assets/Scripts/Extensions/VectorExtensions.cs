using UnityEngine;

public static class VectorExtensions
{
    public static Vector3 GetPointInRandomRadius(this Vector3 center, float angle, float minRadius, float maxRadius)
    {
        float radius = Random.Range(minRadius, maxRadius);

        Vector3 point = center;

        point.x += radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        point.z += radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        return point;
    }


    public static Vector3 GetPointInRadius(this Vector3 center, float angle, float radius)
    {
        Vector3 point = center;

        point.x += radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        point.z += radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        return point;
    }
}