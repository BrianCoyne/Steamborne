using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlaceBuildingText : MonoBehaviour {

	private Text m_text;
    public Image image;

	// Use this for initialization
	void Start () {
		m_text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		m_text.text = "";

		if (BuildingPlacement.Instance.PlacingBuildingIndex > -1) 
        {
			m_text.text = "" + BuildingPlacement.Instance.StructureConfigs[BuildingPlacement.Instance.PlacingBuildingIndex].Name;
            image.gameObject.SetActive(true);

        }
            else 
            {
                image.gameObject.SetActive(false);
            }
		}
	}

