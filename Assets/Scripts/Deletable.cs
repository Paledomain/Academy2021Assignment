using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Deletable
{
    public bool isDeletionOK();

    public GameObject GetGameObject();
}
