using UnityEngine;
using System.Collections;

public class Structure : MonoBehaviour
{

    public GameObject BaseStructure;
    public GameObject NoWorkersDisplay;

    private float m_animationTime = 0.0f;

    public Vector3 StartPoint = new Vector3(0.0f, 10.0f, 0.0f);

    private bool m_placed = false;

    private bool m_hasWorkers = false;

    public float NextRivetGeneration = 0.0f;

	public float NextSteamGeneration = 0.0f;

    public StructureConfig MyConfig;

    public void PlaceStructure()
    {
        m_placed = true;
        BaseStructure.transform.localPosition = StartPoint;
    }

    public void SetHasWorkers(bool hasWorkers)
    {
        m_hasWorkers = hasWorkers;

        if (m_hasWorkers)
        {
            NoWorkersDisplay.SetActive(false);
        }
        else
        {
            NoWorkersDisplay.SetActive(true);
        }
    }

    // Use this for initialization
    void Start()
    {
        NextRivetGeneration = Time.time + Random.Range(5.0f, 10.0f);
		NextSteamGeneration = Time.time + Random.Range(5.0f, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (m_placed && BaseStructure.transform.localPosition != Vector3.zero)
        {
            BaseStructure.transform.localPosition =
                Vector3.Slerp(StartPoint, Vector3.zero, m_animationTime * 0.25f);

            m_animationTime = m_animationTime + Time.deltaTime;
        }
    }
}
