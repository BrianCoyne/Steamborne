using UnityEngine;
using System.Collections;

public class StructureConfig {

    public string Name = "";

    public string PrefabLocation = "";

    public int RivetCost = 20;

    public int WorkersRequired = 0;

    public float BaseWidth = 2;

    public float BaseHeight = 2;

    public int HousingModifier = 0;

    public int AttractionModifier = 0;

    public int RivetMinGeneration = 0;
    public int RivetMaxGeneration = 0;
    public float RivetGenerationDelay = 10.0f;
    public float RivetDayChance = 0.25f;

	public int VoltGeneration = 0;
	public int VoltsRequired = 0;
	public float VoltGenerationDelay = 8.0f;
	
	public int SteamGeneration = 0;
    public float SteamGenerationDelay = 8.0f;

	public int BuildLimit = -1;

	public int StructuresPlaced = 0;

	public int BuildTime = 0;
}
