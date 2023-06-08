using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paraglax : MonoBehaviour
{
    public static Paraglax Instance;

    [SerializeField]  public GameObject friend;

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goHereFriend()
    {
        this.transform.position = friend.transform.position;
        Vector3 Coaster = this.transform.position;
        Coaster.z = 1;
        this.transform.position = Coaster;
    }
}
