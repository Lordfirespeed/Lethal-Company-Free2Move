/*
 * https://github.com/Lordfirespeed/Lethal-Company-Augmented-Enhancer/tree/126fc25f9fbb707339a60ccf034ee1b2e40efcf4/Enhancer/Features/IFeature.cs
 * Augmented Enhancer Copyright (c) 2023 Mama Llama, Flowerful, Lordfirespeed
 * The authors of Augmented Enhancer license this file to Lordfirespeed under the CC-BY-NC-4.0 license.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

namespace Free2Move.Features;

using BepInEx.Logging;
using HarmonyLib;

public interface IFeature
{
    public ManualLogSource Logger {
        set { }
    }
    public Harmony Harmony {
        set { }
    }
    public void OnEnable() { }
    public void OnDisable() { }
    public void OnConfigChange() { }
}
