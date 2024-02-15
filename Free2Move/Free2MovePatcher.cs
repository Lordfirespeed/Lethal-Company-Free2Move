/*
 * https://github.com/Lordfirespeed/Lethal-Company-Augmented-Enhancer/tree/126fc25f9fbb707339a60ccf034ee1b2e40efcf4/Enhancer/EnhancerPatcher.cs
 * Augmented Enhancer Copyright (c) 2023 Mama Llama, Flowerful, Lordfirespeed
 * The authors of Augmented Enhancer license this file to Lordfirespeed under the CC-BY-NC-4.0 license.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using System.Collections.Generic;
using BepInEx;
using BepInEx.Logging;
using Free2Move.FeatureInfo;
using Free2Move.Features;
using HarmonyLib;
using UnityEngine;

namespace Free2Move;

public class Free2MovePatcher : MonoBehaviour
{
    internal static PluginInfo Info { get; set; } = null!;

    internal static ManualLogSource Logger => Free2MovePlugin.Logger;

    internal static Free2MoveConfig BoundConfig => Free2MovePlugin.BoundConfig;

    private readonly IList<IFeatureInfo<IFeature>> _features = [
        new FeatureInfo<MoveInAnyDirection> {
            Name = "Free Movement",
            EnabledCondition = () => BoundConfig.Enabled.Value,
            ListenToConfigEntries = [ BoundConfig.Enabled, ],
        },
        new FeatureInfo<MoveInCardinalDirections> {
            Name = "Restrict Movement",
            EnabledCondition = () => !BoundConfig.Enabled.Value,
            ListenToConfigEntries = [ BoundConfig.Enabled, ],
        },
    ];

    private void Start()
    {
        FeatureInfoInitializers.HarmonyFactory =
            harmonyName => new Harmony($"{MyPluginInfo.PLUGIN_GUID}-{harmonyName}");
        FeatureInfoInitializers.LogSourceFactory =
            patchName => BepInEx.Logging.Logger.CreateLogSource($"{MyPluginInfo.PLUGIN_NAME}/{patchName}");

        Logger.LogInfo("Initialising features...");
        _features.Do(patch => patch.Initialise());
        Logger.LogInfo("Done!");
    }

    private void OnDestroy()
    {
        _features.Do(patch => patch.Dispose());
    }
}
