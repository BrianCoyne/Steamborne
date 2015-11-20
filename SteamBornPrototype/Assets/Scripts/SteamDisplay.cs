using UnityEngine;
using System.Collections;

public class SteamDisplay : MonoBehaviour {

    public TextMesh SteamTextMesh;

    private float m_lifeTime = 2.0f;
    private float m_destroyTime;

    private Color m_originalColor;
    private Color m_invisibleColor;

    // Use this for initialization
    void Start()
    {
        m_destroyTime = Time.time + m_lifeTime;
        m_originalColor = SteamTextMesh.color;
        m_invisibleColor = new Color(m_originalColor.r, m_originalColor.g, m_originalColor.b, 0);
    }

    public void SetSteamAmount(int amount)
    {
        SteamTextMesh.text = amount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);

        SteamTextMesh.transform.Translate(Vector3.up * Time.deltaTime * 1);

        float lerpAmount = 1 - ((m_destroyTime - Time.time) / m_lifeTime);

        SteamTextMesh.color = Color.Lerp(m_originalColor, m_invisibleColor, lerpAmount);

        if (Time.time >= m_destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
