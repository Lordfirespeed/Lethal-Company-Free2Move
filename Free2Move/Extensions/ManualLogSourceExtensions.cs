/*
 * https://github.com/Lordfirespeed/Lethal-Company-Augmented-Enhancer/tree/126fc25f9fbb707339a60ccf034ee1b2e40efcf4/Enhancer/Extensions/ManualLogSourceExtensions.cs
 * Augmented Enhancer Copyright (c) 2023 Mama Llama, Flowerful, Lordfirespeed
 * The authors of Augmented Enhancer license this file to Lordfirespeed under the CC-BY-NC-4.0 license.
 * Lordfirespeed licenses this file to you under the LGPL-3.0-OR-LATER license.
 */

using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BepInEx.Logging;
using HarmonyLib;

namespace Free2Move.Extensions;

public static class ManualLogSourceExtensions
{
    class CodeInstructionFormatter(int instructionCount)
    {
        private int _instructionIndexPadLength = instructionCount.ToString().Length;

        public string Format(CodeInstruction instruction, int index)
            => $"    IL_{index.ToString().PadLeft(_instructionIndexPadLength, '0')}: {instruction}";
    }

    public static void LogDebugInstructionsFrom(this ManualLogSource source, CodeMatcher matcher)
    {
        var methodName = new StackTrace().GetFrame(1).GetMethod().Name;

        var instructionFormatter = new CodeInstructionFormatter(matcher.Length);
        var builder = new StringBuilder($"'{methodName}' Matcher Instructions:\n")
            .AppendLine(
                String.Join(
                    "\n",
                    matcher
                        .InstructionEnumeration()
                        .Select(instructionFormatter.Format)
                )
            )
            .AppendLine("End of matcher instructions.");

        source.LogDebug(builder.ToString());
    }
}
