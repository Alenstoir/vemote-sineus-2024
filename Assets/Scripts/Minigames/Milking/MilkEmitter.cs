using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkEmitter : MonoBehaviour
{
    public GameObject milkDrop;

    public void EmitMilk() {
        Instantiate(milkDrop, transform.position, transform.rotation);
    }
}
