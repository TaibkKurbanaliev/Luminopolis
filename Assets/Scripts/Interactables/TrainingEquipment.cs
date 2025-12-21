using System.Collections;
using UnityEngine;

public abstract class TrainingEquipment : Interactable
{

    private void Start()
    {
    }

    public override void Interact()
    {
        StartCoroutine(Train());
    }

    protected virtual IEnumerator Train()
    {
        yield return new WaitForSeconds(1);
    }
}
