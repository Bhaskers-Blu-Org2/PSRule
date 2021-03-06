﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace PSRule.Host
{
    public enum LanguageBlockKind : byte
    {
        Unknown = 0,

        Rule = 1,

        Baseline = 2
    }

    public interface ILanguageBlock
    {
        string SourcePath { get; }

        string Module { get; }
    }
}
