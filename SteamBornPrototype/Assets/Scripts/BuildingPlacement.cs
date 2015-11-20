using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingPlacement : MonoBehaviour {

	public static BuildingPlacement Instance;

    public StructureConfig[] StructureConfigs = new StructureConfig[8];

    private float m_nextPlacementTime = 0.0f;

    private GameObject[,] m_worldGrid = new GameObject[10, 10];

    private float m_buildingBaseWidth = 2;
    private float m_buildingBaseHeight = 2;

    public int PlacingBuildingIndex = -1;

    public int CurrentHousing = 10;
    public int CurrentPopulation = 10;

    public int CurrentWorkers = 0;

    private int m_standardPopArrivalAmount = 5;
    private int m_maxPopArrivalAmount = 10;
    private float m_nextPopArrivalTime = 0;

    private int m_baseAttraction = 100;
    private float m_altitudeAttractionModifier = 1.0f;

    public int CurrentRivets = 200;

	public int CurrentSteam = 200;

    private float m_rivetRefundModifier = 0.5f;

    private List<Structure> m_structures = new List<Structure>();

	// Use this for initialization
	void Start () {  

		Instance = this;

        StructureConfigs[0] = new StructureConfig();
        StructureConfigs[0].Name = "House";
        StructureConfigs[0].PrefabLocation = "Structures/BasicHousePrefab";
        StructureConfigs[0].RivetCost = 20;
        StructureConfigs[0].BaseWidth = 2;
        StructureConfigs[0].BaseHeight = 2;
        StructureConfigs[0].HousingModifier = 20;
        StructureConfigs[0].AttractionModifier = -10;
		StructureConfigs[0].VoltGeneration = -10;
		StructureConfigs[0].BuildTime = 20;
        
        StructureConfigs[1] = new StructureConfig();
        StructureConfigs[1].Name = "Windmill";
        StructureConfigs[1].PrefabLocation = "Structures/WindmillPrefab";
        StructureConfigs[1].RivetCost = 50;
        StructureConfigs[1].BaseWidth = 2;
        StructureConfigs[1].BaseHeight = 2;
        StructureConfigs[1].AttractionModifier = -20;
        StructureConfigs[1].WorkersRequired = 5;
		StructureConfigs[1].VoltGeneration = 20;
		StructureConfigs[1].BuildTime = 20;

        StructureConfigs[2] = new StructureConfig();
        StructureConfigs[2].Name = "Shop";
        StructureConfigs[2].PrefabLocation = "Structures/ShopPrefab";
        StructureConfigs[2].RivetCost = 50;
        StructureConfigs[2].BaseWidth = 2;
        StructureConfigs[2].BaseHeight = 2;
        StructureConfigs[2].AttractionModifier = 10;
        StructureConfigs[2].WorkersRequired = 2;
        StructureConfigs[2].RivetMinGeneration = 5;
        StructureConfigs[2].RivetMaxGeneration = 8;
		StructureConfigs[2].VoltGeneration = -1;
		StructureConfigs[2].BuildTime = 20;

		StructureConfigs[3] = new StructureConfig();
		StructureConfigs[3].Name = "TownHall";
		StructureConfigs[3].PrefabLocation = "Structures/TownHallPrefab";
		StructureConfigs[3].RivetCost = 0;
		StructureConfigs[3].BaseWidth = 2;
		StructureConfigs[3].BaseHeight = 2;
		StructureConfigs[3].AttractionModifier = 10;
		StructureConfigs[3].WorkersRequired = 0;
		StructureConfigs[3].RivetMinGeneration = 5;
		StructureConfigs[3].RivetMaxGeneration = 8;
		StructureConfigs[3].BuildLimit = 1;
		StructureConfigs[3].VoltGeneration = 5;
		StructureConfigs[3].BuildTime = 15;

        StructureConfigs[4] = new StructureConfig();
        StructureConfigs[4].Name = "BoilerPlant";
        StructureConfigs[4].PrefabLocation = "Structures/BoilerPlantPrefab";
        StructureConfigs[4].RivetCost = 100;
        StructureConfigs[4].BaseWidth = 2;
        StructureConfigs[4].BaseHeight = 2;
        StructureConfigs[4].AttractionModifier = -10;
        StructureConfigs[4].WorkersRequired = 10;
        StructureConfigs[4].RivetMinGeneration = 0;
        StructureConfigs[4].RivetMaxGeneration = 0;
        StructureConfigs[4].SteamGeneration = 10;
        StructureConfigs[4].BuildTime = 45;

        StructureConfigs[5] = new StructureConfig();
        StructureConfigs[5].Name = "ClockTower";
        StructureConfigs[5].PrefabLocation = "Structures/ClockTowerPrefab";
        StructureConfigs[5].RivetCost = 50;
        StructureConfigs[5].BaseWidth = 2;
        StructureConfigs[5].BaseHeight = 2;
        StructureConfigs[5].AttractionModifier = 25;
        StructureConfigs[5].WorkersRequired = 1;
        StructureConfigs[5].VoltGeneration = -10;
        StructureConfigs[5].BuildTime = 45;
		
	}
	
    void Update()
    {
        doPlacementCheck();
        doDestroyCheck();
        doArrivalCheck();
        workersCheck();
        doRivetGeneration();
		doSteamGeneration ();
    }

    public void doRivetGeneration()
    {
        for (int index = 0; index < m_structures.Count; index++)
        {
            if (Time.time > m_structures[index].NextRivetGeneration 
                && m_structures[index].MyConfig.RivetMaxGeneration > 0
			    && m_structures[index].NextRivetGeneration != 0.0f)
            {
                m_structures[index].NextRivetGeneration = Time.time
                    + m_structures[index].MyConfig.RivetGenerationDelay;

                int rivets = Random.Range(m_structures[index].MyConfig.RivetMinGeneration,
                    m_structures[index].MyConfig.RivetMaxGeneration);

                CurrentRivets = CurrentRivets + rivets;

                GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("RivetDisplay"));
                go.transform.position = m_structures[index].transform.position + new Vector3(m_structures[index].MyConfig.BaseWidth / 2, 0.0f, m_structures[index].MyConfig.BaseHeight / 2);

                RivetDisplay rivetsDisplay = go.GetComponent<RivetDisplay>();

                if (rivetsDisplay != null)
                {
                    rivetsDisplay.SetRivetAmount(rivets);
                }
            }
        }
    }

	public void doSteamGeneration()
	{
		for (int index = 0; index < m_structures.Count; index++)
		{
            if (Time.time > m_structures[index].NextSteamGeneration
                && m_structures[index].MyConfig.SteamGeneration > 0
                && m_structures[index].NextSteamGeneration != 10.0f)
               
			{
                m_structures[index].NextSteamGeneration = Time.time
                    + m_structures[index].MyConfig.SteamGenerationDelay;

                CurrentSteam = CurrentSteam + m_structures[index].MyConfig.SteamGeneration;

                GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("SteamDisplay"));
				go.transform.position = m_structures[index].transform.position + new Vector3(m_structures[index].MyConfig.BaseWidth / 2, 0.0f, m_structures[index].MyConfig.BaseHeight / 2);

                SteamDisplay steamDisplay = go.GetComponent<SteamDisplay>();

                if (steamDisplay != null)
				{
                    steamDisplay.SetSteamAmount(m_structures[index].MyConfig.SteamGeneration);
				}
			}
		}
	}

    private void workersCheck()
    {
        CurrentWorkers = 0;

        for (int index = 0; index < m_structures.Count; index++)
        {
            if (m_structures[index].MyConfig.WorkersRequired <= (CurrentPopulation - CurrentWorkers))
            {
                m_structures[index].SetHasWorkers(true);
                CurrentWorkers = CurrentWorkers + m_structures[index].MyConfig.WorkersRequired;
            }
            else
            {
                m_structures[index].SetHasWorkers(false);
            }
        }
    }

    private void doArrivalCheck()
    {
        if (Time.time >= m_nextPopArrivalTime)
        {
            m_nextPopArrivalTime = m_nextPopArrivalTime + 10.0f;

            float attraction = m_baseAttraction * m_altitudeAttractionModifier;

            int popArrivalAmount = Mathf.RoundToInt(m_standardPopArrivalAmount * (attraction / 100));

            if (popArrivalAmount > m_maxPopArrivalAmount)
            {
                popArrivalAmount = m_maxPopArrivalAmount;
            }

            if (popArrivalAmount > 0)
            {
                Debug.Log(popArrivalAmount + " people have arrived!");
            }
            else
            {
                Debug.Log(popArrivalAmount + " people have left!");
            }

            CurrentPopulation = CurrentPopulation + popArrivalAmount;
            
            if (CurrentPopulation > CurrentHousing)
            {
                CurrentPopulation = CurrentHousing;
            }

            if (CurrentPopulation < 0)
            {
                CurrentPopulation = 0;
            }
        }
    }
	
	private void doPlacementCheck () {

        if (PlacingBuildingIndex > -1 && Input.GetAxis("Fire1") != 0 && Time.time >= m_nextPlacementTime)
        {
            if (StructureConfigs[PlacingBuildingIndex].RivetCost > CurrentRivets)
            {
                Debug.Log("You don't have enough rivets!");

                return;
            }

            if (StructureConfigs[PlacingBuildingIndex].WorkersRequired 
                > (CurrentPopulation - CurrentWorkers))
            {
                Debug.Log("You need " 
                    + StructureConfigs[PlacingBuildingIndex].WorkersRequired 
                    + " workers to build that!");

                return;
            }

            m_nextPlacementTime = Time.time + 0.5f;

            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            int layer = 1 << 8;
            if (Physics.Raycast(cameraRay, out hitInfo, 1000, layer))
            {
                int x = Mathf.RoundToInt(hitInfo.point.x - (m_buildingBaseWidth / 2));
                int z = Mathf.RoundToInt(hitInfo.point.z - (m_buildingBaseHeight / 2));

                Vector3 placementPoint = new Vector3(x, 0.0f, z);

                if (x < 0 || x > 8
                    || z < 0 || z > 8)
                {
                    return;
                }

                if (m_worldGrid[x,z] == null 
                    && m_worldGrid[x, z + 1] == null
                    && m_worldGrid[x + 1, z] == null
                    && m_worldGrid[x + 1, z + 1] == null)
                {
                    GameObject basicHouse = 
                        Instantiate<GameObject>(Resources.Load<GameObject>(StructureConfigs[PlacingBuildingIndex].PrefabLocation));
                    basicHouse.transform.position = placementPoint;

                    m_worldGrid[x, z] = basicHouse;
                    m_worldGrid[x + 1, z] = basicHouse;
                    m_worldGrid[x, z + 1] = basicHouse;
                    m_worldGrid[x + 1, z + 1] = basicHouse;

                    Structure structure = basicHouse.GetComponent<Structure>();

                    if (structure != null)
                    {
                        structure.MyConfig = StructureConfigs[PlacingBuildingIndex];
                        structure.PlaceStructure();

						structure.MyConfig.StructuresPlaced +=1;

                        m_structures.Add(structure);

						CurrentRivets = CurrentRivets - StructureConfigs[PlacingBuildingIndex].RivetCost;
						CurrentHousing = CurrentHousing + StructureConfigs[PlacingBuildingIndex].HousingModifier;
						m_baseAttraction = m_baseAttraction + StructureConfigs[PlacingBuildingIndex].AttractionModifier;

						if (structure.MyConfig.StructuresPlaced >= structure.MyConfig.BuildLimit && structure.MyConfig.BuildLimit != -1)
						{
							PlacingBuildingIndex = -1;
						}
                    }

                    
                }
                else
                {
                    Debug.Log("Something is in the way...");
                }                
            }
        }
	}

    public void doDestroyCheck()
    {
        if (Input.GetAxis("Fire2") != 0 && Time.time > m_nextPlacementTime)
        {
            m_nextPlacementTime = Time.time + 0.5f;
            
            Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(cameraRay, out hitInfo))
            {
                Structure structure = hitInfo.transform.root.GetComponent<Structure>();

                if (structure != null)
                {
                    CurrentRivets = CurrentRivets + Mathf.RoundToInt(structure.MyConfig.RivetCost * m_rivetRefundModifier);
                    CurrentHousing = CurrentHousing - structure.MyConfig.HousingModifier;
                    m_baseAttraction = m_baseAttraction - structure.MyConfig.AttractionModifier;

					structure.MyConfig.StructuresPlaced -= 1;

                    m_structures.Remove(structure);

                    Destroy(structure.gameObject);
                }
            }
        }
    }

	    
}