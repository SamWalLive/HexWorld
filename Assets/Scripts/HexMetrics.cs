using UnityEngine;

public static class HexMetrics {

	public const float outerRadius = 60f;

	public const float innerRadius = outerRadius * 0.866025404f;

    public static Vector3[] corners = {
        //NE
        new Vector3(0.5f * outerRadius, innerRadius, 0f),
        //E
		new Vector3(outerRadius, 0f, 0f),
        //SE
		new Vector3(0.5f * outerRadius, -innerRadius, 0f),
        //SW
		new Vector3(-0.5f * outerRadius, -innerRadius, 0f),
        //W
		new Vector3(-outerRadius, 0f, 0f),
        //NW
		new Vector3(-0.5f * outerRadius, innerRadius, 0f)
	};

    public static Vector2[] neighbours = {
        //N
        new Vector2(0f, 2f),
        //NE
        new Vector2(1f, 1f),
        //SE
        new Vector2(1, -1f),
        //S
        new Vector2(0f, -2f),
        //SW
        new Vector2(-1f, -1f),
        //NW
        new Vector2(-1f, 1f)
    };

    public static float[] rotations =
    {
        -30, -90, -150, 30, 90, 150
    };

}