[System.Serializable]
public class LevelDetails
{
    public int maxMoles; //How many moles can be out at a time?
    public int lives;
    public float startTime;
    public Extremum moleOutInterval;
    public Extremum shakeInterval;
    public Extremum jumpUpTime;
    public Extremum stayTime;
    public Extremum goDownTime;
    public float pirateMoleProbability;
    public float simplePowerMoleProbability;
    public float complexPowerMoleProbability;
}
