namespace ExpressionStringEvaluator.Tests;

using System;

public class Repository
{
    public string? Name { get; set; }

    public string? Path { get; set; }

    public string? Location { get; set; }

    public string? CurrentBranch { get; set; }

    public string[]? Branches { get; set; }

    public string[]? LocalBranches { get; set; }

    public bool CurrentBranchHasUpstream { get; set; }

    public bool CurrentBranchIsDetached { get; set; }

    public bool CurrentBranchIsOnTag { get; set; }

    public int? AheadBy { get; set; }

    public int? BehindBy { get; set; }

    public int? LocalUntracked { get; set; }

    public int? LocalModified { get; set; }

    public int? LocalMissing { get; set; }

    public int? LocalAdded { get; set; }

    public int? LocalStaged { get; set; }

    public int? LocalRemoved { get; set; }

    public int? LocalIgnored { get; set; }

    public int? StashCount { get; set; }

    public string[]? RemoteUrls { get; set; }

    public string? SafePath
    {
        // use '/' for linux systems and bash command line (will work on cmd and powershell as well)
        get
        {
            var safePath = Path?.Replace(@"\", "/") ?? string.Empty;
            if (safePath.EndsWith("/"))
            {
                safePath = safePath[..^1];
            }

            return safePath;
        }
    }
}