using UnityEngine;

public class Constants
{
    public static readonly Color[] COLORS = { new Color32(249, 65, 68, 255),
                                              new Color32(243, 114, 44, 255),
                                              new Color32(248, 150, 30, 255),
                                              new Color32(249, 132, 74, 255),
                                              new Color32(249, 199, 79, 255),
                                              new Color32(144, 190, 109, 255),
                                              new Color32(67, 170, 139, 255),
                                              new Color32(77, 144, 142, 255),
                                              new Color32(87, 117, 144, 255),
                                              new Color32(39, 125, 161, 255)};

    public const string SCORE_TEXT = "SCORE\n";
    public const int MAX_MIN_MOVEMENT_DISTANCE = 2;
    public const int MAX_POWER = 11;
    public const int VIOLATION_LIMIT = 4;
    public const int BALL_SIZE = 15;
}
