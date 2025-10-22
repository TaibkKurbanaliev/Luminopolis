using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "StatsConfig", menuName = "Stats/StatsConfig")]
public class StatsConfig : ScriptableObject
{
    [SerializeField] private List<BaseStatConfig> _baseStatConfigs;

    public IReadOnlyList<BaseStatConfig> BaseStatConfigs => _baseStatConfigs;

    private void OnValidate()
    {
        
        var statDuplicates = _baseStatConfigs.GroupBy(item => item.StatType).Where(array => array.Count() > 1);

        if (statDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_baseStatConfigs));
    }
}
