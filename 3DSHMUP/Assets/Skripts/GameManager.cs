using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager Instance{
        get{return m_instance;}
    }

    [SerializeField]
    private Vector3 upperScreenBounds;

    [SerializeField]
    private Vector3 lowerScreenBounds;

    [SerializeField]
    private float screenBoundsMargin;
    public Vector3 UpperScreenBounds
    {
        get
        {
            return upperScreenBounds;
        }
    }

    public Vector3 LowerScreenBounds
    {
        get
        {
            return lowerScreenBounds;
        }
    }

    public float ScreenBoundsMargin
    {
        get
        {
            return screenBoundsMargin;
        }
    }
    void Awake()
    {
        if(m_instance == null)
            m_instance = this;
        else
            Debug.LogError("There may only be one GameManager!");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsInBounds(Vector3 position)
    {
        return position.x>lowerScreenBounds.x&&position.x<upperScreenBounds.x&&position.z>lowerScreenBounds.z&&position.z<upperScreenBounds.z;
    }

}
