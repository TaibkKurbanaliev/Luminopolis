using System.Collections;
using UnityEngine;

public abstract class TrainingEquipment : Interactable
{
    protected Modifier Modifier;

    private void Start()
    {
        Modifier = GetComponent<Modifier>();
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
