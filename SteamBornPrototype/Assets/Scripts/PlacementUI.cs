using UnityEngine;
using System.Collections;

public class PlacementUI : MonoBehaviour {


    public bool Pause = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Pause == false)
        {
            Time.timeScale = 1;
        }

        else
        {
            Time.timeScale = 0;
        }
	}


    void OnGUI()
    {
        if (BuildingPlacement.Instance != null)
        {

            for (int index = 0; index < BuildingPlacement.Instance.StructureConfigs.Length; index++)
            {
               // if (BuildingPlacement.Instance.StructureConfigs[index].StructuresPlaced < BuildingPlacement.Instance.StructureConfigs[index].BuildLimit
               //    || BuildingPlacement.Instance.StructureConfigs[index].BuildLimit == -1)
               // {
                    /*
                                        if (GUI.Button(new Rect(10, 10 + (35 * index), 160, 25), BuildingPlacement.Instance.StructureConfigs[index].Name + " " + BuildingPlacement.Instance.StructureConfigs[index].RivetCost))
                                        {
                                        BuildingPlacement.Instance.PlacingBuildingIndex = index;
                                        }
                                        }
                                        }            
	

	
                                        GUI.Box (new Rect ((Screen.width - 240) / 2, 10, 240, 25), "Housing: " + BuildingPlacement.Instance.CurrentHousing);
	
                                        GUI.Box (new Rect ((Screen.width - 240) / 2, 45, 240, 25), "Population: " + BuildingPlacement.Instance.CurrentPopulation + " / Workers: " + BuildingPlacement.Instance.CurrentWorkers);
	
                                        GUI.Box (new Rect ((Screen.width - 250), 10, 240, 25), "Rivets: " + BuildingPlacement.Instance.CurrentRivets); 


                                        GUI.Box (new Rect ((Screen.width - 250), 45, 240, 25), "Volts: " + BuildingPlacement.Instance.CurrentVolts); 
					
                                        */
                }
            }
        

    }


    public void onNewBuildStart()
    {
        BuildingPlacement.Instance.PlacingBuildingIndex = -1;
    }

	public void onBuildHouseClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 0;
	}

	public void onBuildShopClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 2;
	}

	public void OnStopBuildClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = -1;
	}

	public void OnBuildPylonClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 4;
	}

	public void OnBuildTopHatClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 7;
	}

	public void OnBuildWindmillClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 1;
	}

	public void OnBuildTownHallClicked()
	{
		BuildingPlacement.Instance.PlacingBuildingIndex = 3;
	}
    
    public void OnBuildBoilerPlantClicked()
    {
        BuildingPlacement.Instance.PlacingBuildingIndex = 4;
    }

    public void OnBuildClockTowerClicked()
    {
        BuildingPlacement.Instance.PlacingBuildingIndex = 5;
    }

	public void OnPauseButtonClicked()
    {
        Pause = true;
    }

    public void OnResumeButtonClicked()
     {
         Pause = false;
     }

    public void OnQuitButtonClicked()
    {
        Application.LoadLevel("Menu");
    }

    public void OnMenuQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnNewGameButtonClicked()
    {
        Application.LoadLevel("Main");
    }

	public void OnTutorialButtonClicked()
	{
		Application.LoadLevel("Tutorial");
	}


    /*public void OnAudioPlayButtonClicked()
    {
        GetComponent<AudioSource>().Play();
    }

    public void OnAudioStopButtonClicked()
    {
        GetComponent<AudioSource>().Stop();
    }
	*/
}

