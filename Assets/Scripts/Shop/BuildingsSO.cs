using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop", menuName = "SO", order = 1)]
public class BuildingsSO : ScriptableObject
{
    [SerializeField] private List<Building> _buildings;

    public IEnumerable<Building> Buildings => _buildings;

    private void OnValidate()
    {
        var buildingsDuplicates = _buildings.GroupBy(item => item.BuildingData.Name).Where(array => array.Count() > 1);

        if (buildingsDuplicates.Count() > 0 )
            throw new InvalidOperationException(nameof(_buildings));
    }
}

