using UnityEngine;

public class BallProperties
{
    public int Id { get; set; }
    public int Power { get; set; }
    public float Value { get; set; }
    public Vector3 Size { get; set; }
    public Color Color{ get; set; }

    public BallProperties(int id, int power)
    {
        Id = id;
        Power = power;
        Value = Mathf.Pow(2, power);
        Size = Vector3.one * Power / Constants.BALL_SIZE + Vector3.one;
        Color = Constants.COLORS[power-1];
    }
    public void UpdateProperties()
    {
        Power++;
        if (Power != Constants.MAX_POWER)
        {
            Value = Mathf.Pow(2, Power);
            Size = Vector3.one * Power / Constants.BALL_SIZE + Vector3.one;
            Color = Constants.COLORS[Power - 1];
        }
    }
}
