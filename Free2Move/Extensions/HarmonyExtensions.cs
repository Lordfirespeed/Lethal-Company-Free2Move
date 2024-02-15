/*
 * https://github.com/Lordfirespeed/Lethal-Company-Augmented-Enhancer/tree/126fc25f9fbb707339a60ccf034ee1b2e40efcf4/Enhancer/Extensions/HarmonyExtensions.cs
 * Augmented Enhancer Copyright (c) 2023 Mama Llama, Flowerful, Lordfirespeed
 * The authors of Augmented Enhancer license this file to Lordfirespeed under the CC-BY-NC-4.0 license.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using System;
using System.Reflection;
using HarmonyLib;

namespace Free2Move.Extensions;

public static class HarmonyExtensions
{
    private const BindingFlags SearchNestedTypeBindingFlags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic;

    public static void PatchAllNestedTypesOnly(this Harmony harmony, Type type)
    {
        foreach (var nestedType in type.GetNestedTypes(SearchNestedTypeBindingFlags)) {
            PatchAllWithNestedTypes(harmony, nestedType);
        }
    }

    public static void PatchAllWithNestedTypes(this Harmony harmony, Type type)
    {
        harmony.PatchAll(type);
        PatchAllNestedTypesOnly(harmony, type);
    }
}
