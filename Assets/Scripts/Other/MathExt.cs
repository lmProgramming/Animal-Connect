﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MathExt
{
    public static float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

    // faster computationally than normal distance
    public static float SquaredDistance(Vector2 a, Vector2 b)
    {
        float dx = a.x - b.x;
        float dy = a.y - b.y;
        return dx * dx + dy * dy;
    }

    public static float SimpleDistance(Vector2 a, Vector2 b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    public static float Angle360(float angle)
    {
        if (angle < 0)
        {
            return angle + 360;
        }

        return angle;
    }

    // angle between -90 and 90 symmetrical
    public static float AngleSym180(float angle)
    {
        if (angle > 90)
        {
            angle -= (angle - 90) * 2;
        }
        else if (angle < -90)
        {
            angle += (angle + 90) * 2;
        }

        return angle;
    }

    public static bool FacingRight(float angle)
    {
        return !(angle > 90 && angle < 270);
    }

    public static Vector2 GetXYDirection(float angle, float magnitude)
    {
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Vector3 XYZdirection = rotation * new Vector3(magnitude, 0f, 0f);
        return (Vector2)XYZdirection;
    }

    public static Vector2[] GetTriangleApexes(float sideLength)
    {
        // Calculate the height of the equilateral triangle
        float halfSideLength = sideLength / 2;
        float triangleHeight = halfSideLength * Mathf.Sqrt(3);

        // Calculate the coordinates of the triangle's center
        Vector2 triangleCenter = new Vector2(0, triangleHeight / 2);
        Vector2 triangleBias = new Vector2(0, triangleHeight / 3) - triangleCenter;

        // Calculate the coordinates of the triangle's vertices based on the center
        Vector2 vertexA = triangleBias + new Vector2(0, 2 * triangleHeight / 3);
        Vector2 vertexB = triangleBias + new Vector2(-sideLength / 2, -triangleHeight / 3);
        Vector2 vertexC = triangleBias + new Vector2(sideLength / 2, -triangleHeight / 3);

        // Create an array to store the vertices
        Vector2[] vertices = { vertexA, vertexB, vertexC };

        return vertices;
    }

    public static T RandomPullFrom<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("The list is empty or null. Returning default value.");
            return default;
        }

        int randomIndex = Random.Range(0, list.Count);

        T value = list[randomIndex];

        list.RemoveAt(randomIndex);
        return value;
    }

    public static int RandomInclusive(int x, int y)
    {
        return Random.Range(x, y + 1);
    }

    public static T RandomFrom<T>(List<T> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.LogWarning("The list is empty or null. Returning default value.");
            return default;
        }

        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }

    public static T RandomFrom<T>(T[] array)
    {
        if (array == null || array.Length == 0)
        {
            Debug.LogWarning("The list is empty or null. Returning default value.");
            return default;
        }

        int randomIndex = Random.Range(0, array.Length);
        return array[randomIndex];
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            (list[n], list[k]) = (list[k], list[n]);
        }
    }
}
