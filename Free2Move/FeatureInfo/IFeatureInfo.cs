/*
 * https://github.com/Lordfirespeed/Lethal-Company-Augmented-Enhancer/tree/126fc25f9fbb707339a60ccf034ee1b2e40efcf4/Enhancer/FeatureInfo/IFeatureInfo.cs
 * Augmented Enhancer Copyright (c) 2023 Mama Llama, Flowerful, Lordfirespeed
 * The authors of Augmented Enhancer license this file to Lordfirespeed under the CC-BY-NC-4.0 license.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using System;
using Free2Move.Features;

namespace Free2Move.FeatureInfo;

public interface IFeatureInfo<out TFeature> : IDisposable where TFeature : IFeature
{
    public string Name { get; }
    public bool IsEnabled { get; }
    public void Initialise();
}
