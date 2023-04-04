using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGuy : BaseMEAT
{
    [SerializeField] private GameObject Baller;
    [SerializeField] private GameObject Tetra;
    [SerializeField] private GameObject Exit;

    void Update()
    {
        if (this.ballerNeed > 3)
        {
            Baller.SetActive(true);

        }
        else
        {
            Baller.SetActive(false);
        }



        if (this.tetraNeed > 3)
        {
            Tetra.SetActive(true);

        }
        else
        {
            Tetra.SetActive(false);
        }



        if (this.exitNeed > 9)
        {
            Exit.SetActive(true);

        }
        else
        {
            Exit.SetActive(false);
        }
    }


}
