namespace ExpressionStringEvaluator.Tests;

using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.BooleanToBoolean;
using ExpressionStringEvaluator.Methods.Flow;
using ExpressionStringEvaluator.Methods.StringToBoolean;
using ExpressionStringEvaluator.Methods.StringToInt;
using ExpressionStringEvaluator.Methods.StringToString;
using ExpressionStringEvaluator.Parser;
using ExpressionStringEvaluator.VariableProviders;
using ExpressionStringEvaluator.VariableProviders.DateTime;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

public sealed class IntegrationTests : IDisposable
{
    private readonly ITestOutputHelper _output;
    private readonly List<IVariableProvider> _providers;
    private readonly List<IMethod> _methods;

    public IntegrationTests(ITestOutputHelper output)
    {
        _output = output ?? throw new ArgumentNullException(nameof(output));

        var dateTimeTimeVariableProviderOptions = new DateTimeVariableProviderOptions()
            {
                DateTimeProvider = () => new DateTime(2020, 12, 1, 15, 22, 23),
            };

        var dateTimeNowVariableProviderOptions = new DateTimeNowVariableProviderOptions()
            {
                DateTimeProvider = () => new DateTime(2020, 12, 1, 15, 22, 23),
            };

        var dateTimeDateVariableProviderOptions = new DateTimeDateVariableProviderOptions()
            {
                DateTimeProvider = () => new DateTime(2020, 12, 1, 15, 22, 23),
            };

        _providers = new List<IVariableProvider>
            {
                new DateTimeNowVariableProvider(dateTimeNowVariableProviderOptions),
                new DateTimeTimeVariableProvider(dateTimeTimeVariableProviderOptions),
                new DateTimeDateVariableProvider(dateTimeDateVariableProviderOptions),
                new PathSeparatorVariableProvider(),
                new EmptyVariableProvider(),
                new EnvironmentVariableVariableProvider(),
                new SlashVariableProvider(),
                new BackslashVariableProvider(),
            };

        _methods = new List<IMethod>
            {
                new StringTrimEndStringMethod(),
                new StringTrimStartStringMethod(),
                new StringTrimStringMethod(),
                new StringLowerStringMethod(),
                new StringUpperStringMethod(),
                new StringContainsStringMethod(),
                new UrlEncodeStringMethod(),
                new UrlDecodeStringMethod(),
                new StringEqualsStringMethod(),
                new InMethod(),
                new AndBooleanMethod(),
                new OrBooleanMethod(),
                new StringIsNullOrEmptyBooleanMethod(),
                new FileExistsBooleanMethod(),
                new NotBooleanMethod(),
                new StringLengthMethod(),
                new IfThenElseMethod(),
                new IfThenMethod(),
            };

        Environment.SetEnvironmentVariable("ExpressionStringEvaluatorDummy", "Dummy value");
        Environment.SetEnvironmentVariable("ExpressionStringEvaluatorTrue", "true");
    }

    public void Dispose()
    {
        Environment.SetEnvironmentVariable("ExpressionStringEvaluatorDummy", null);
    }

    [Theory]
    [InlineData("Fixed ",                                                                 "Fixed ")]
    [InlineData(" Fixed",                                                                 " Fixed")]
    [InlineData("Fixed",                                                                  "Fixed")]
    [InlineData("F:i_x.e-d",                                                              "F:i_x.e-d")]
    [InlineData("{now:yyyy:MM _.-  dd}",                                                  "2020:12 _.-  01")]
    [InlineData("{StringEquals({env.ExpressionStringEvaluatorDummy}, xxx)}",              "false")]
    [InlineData("{StringEquals({env.ExpressionStringEvaluatorDummy}, \"Dummy value\")}",  "true")]

    [InlineData("{StringEquals({now:yyyy},2020)}",                       "true")]
    [InlineData("{StringEquals({now:yyyy}, 2020)}",                      "true")]
    [InlineData("{StringEquals({now:yyyy},\"2020\")}",                   "true")]
    [InlineData("{Lower({env.ExpressionStringEvaluatorDummy})}",                                     "dummy value")]
    [InlineData("{Upper({env.ExpressionStringEvaluatorDummy})}", "DUMMY VALUE")]
    [InlineData("{Upper(%ExpressionStringEvaluatorDummy%)}", "DUMMY VALUE")]
    [InlineData("{env.ExpressionStringEvaluatorDummy}", "Dummy value")]
    [InlineData("http://www.google.com:8000",                            "http://www.google.com:8000")]
    [InlineData("fake@github.com",                                       "fake@github.com")]
    [InlineData("{Upper(text)} x",                                       "TEXT x")]
    [InlineData("{UrlEncode(http://www.google.com:8080/abc)} x",         "http%3a%2f%2fwww.google.com%3a8080%2fabc x")]

    [InlineData("TrUe", "true")]
    [InlineData("False", "false")]
    [InlineData("1", "1")]
    [InlineData("0", "0")]
    [InlineData("abctRuede", "abctRuede")]
    [InlineData("abc tRuede", "abc tRuede")]
    [InlineData("abc tRue de", "abc tRue de")]

    [InlineData("%ExpressionStringEvaluatorDummy%", "Dummy value")]
    [InlineData("Dit is %ExpressionStringEvaluatorDummy% Aap", "Dit is Dummy value Aap")]

    [InlineData("{And(true, True)}", "true")]
    [InlineData("{And(TRUE)}", "true")]
    [InlineData("{And(TrUe, true)}", "true")]
    [InlineData("{And(true , {StringEquals({now:yyyy},2020)})}", "true")]

    [InlineData("{And(true, False, True)}", "false")]
    [InlineData("{And(true, False, True, false)}", "false")]
    [InlineData("{And(TRUE, 0)}", "false")]
    [InlineData("{And(true, true, FALSE)}", "false")]
    [InlineData("{And(true,   {StringEquals({now:yyyy},2022)})}", "false")]

    [InlineData("{Or(true)}", "true")]
    [InlineData("{Or(true,true)}", "true")]
    [InlineData("{and(tRue,true)}", "true")]
    [InlineData("{Or(true, true)}", "true")]
    [InlineData("{Or(true,true, true)}", "true")]
    [InlineData("{Or(true, true,  true)}", "true")]

    [InlineData("{Or(true, false)}", "true")]
    [InlineData("{Or(true,true,0)}", "true")]
    [InlineData("{Or(FalsE,0)}", "false")]

    [InlineData("result is {And(1, {StringEquals({now:yyyy},2020)}, {Or(0, false)})}", "result is false")]
    [InlineData("{IsNullOrEmpty(a)}", "false")]
    [InlineData("{IsNullOrEmpty(%dummyEnvVar%)}", "true")]
    [InlineData("{IsNullOrEmpty(%ExpressionStringEvaluatorDummy%)}", "false")]

    [InlineData("{FileExists(%ExpressionStringEvaluatorDummy%)}", "false")]
    [InlineData("{not(true)}", "false")]
    [InlineData("{not(false)}", "true")]

    [InlineData("{FileExists(dummyfile.json)}", "true")]
    [InlineData("{FileExists(dummyfile2.json)}", "false")]
    [InlineData("{not({FileExists(dummyfile2.json)})}", "true")]

    [InlineData("{trimEnd(\"  aaaa   \")}", "  aaaa")]
    [InlineData("{trimEnd(\"  \\\"aaaa   \")}", "  \"aaaa")]
    [InlineData("{trimstart({trimEnd(\"  aaaa2  \" )})}", "aaaa2")]
    [InlineData("{trimstart({trimEnd( \"  tRue  \")})}", "tRue")]
    [InlineData("{trimstart({trimEnd( \"  tRxxue  \" )})}", "tRxxue")]

    [InlineData("{length(github)}", "6")]
    [InlineData("{length(%ExpressionStringEvaluatorDummy%)}", "11")] // "Dummy value"

    [InlineData("{ifthenelse(true, a, b)}", "a")]
    [InlineData("{ifthenelse(false, a, b)}", "b")]
    [InlineData("{ifthenelse({FileExists(dummyfile.json)}, exist, toCreate)}", "exist")]
    [InlineData("{ifthenelse({FileExists(dummyfile.json)}, exist, {empty})}", "exist")]
    [InlineData("{ifthen({FileExists(dummyfile.json)}, exist)}", "exist")]
    [InlineData("file does {ifthen({not({FileExists(dummyfile.json)})}, not)}exist", "file does exist")]
    [InlineData("file does {ifthen({not({FileExists(dummyfile2.json)})}, \"not \")}exist", "file does not exist")]
    [InlineData("file does{ifthenelse({FileExists(dummyfile2.json)}, \" \", \" not\")} exist", "file does not exist")]
    [InlineData("{ifthenelse({FileExists(dummyfile.json)}, \"file does exist\", \"file does not exist\")}", "file does exist")]
    [InlineData("{not(%ExpressionStringEvaluatorTrue%)", "false")]
    [InlineData("{not(true)", "false")]

    [InlineData("{StringContains(abc, b)}", "true")]
    [InlineData("{StringContains(abc, abc)}", "true")]
    [InlineData("{StringContains(abc, abd)}", "false")]
    [InlineData("{StringContains(abc, A)}", "false")] // case sensitive.
    [InlineData("{StringContains(abc , bc)}", "true")]
    [InlineData("{StringContains(\"abc def\" , \"c d\")}", "true")]
    [InlineData("https://dev.azure.com/xx/_git {Env.ExpressionStringEvaluatorDummy}", "https://dev.azure.com/xx/_git Dummy value")]
    [InlineData("https://dev.azure.com/xx/_git{Env.ExpressionStringEvaluatorDummy}", "https://dev.azure.com/xx/_gitDummy value")]
    [InlineData("https://dev.azure.com/xx/_git2/{Env.ExpressionStringEvaluatorDummy}", "https://dev.azure.com/xx/_git2/Dummy value")]
    [InlineData("https://dev.azure.com/xx/_git2/%ExpressionStringEvaluatorDummy%", "https://dev.azure.com/xx/_git2/Dummy value")]
    [InlineData("https://dev.azure.com/xx/_git2/\\%%ExpressionStringEvaluatorDummy%", "https://dev.azure.com/xx/_git2/%Dummy value")]
    [InlineData("https://dev.azure.com/xx/build?definitionScope=\\%5CIntegrations\\%5CData\\%5CAPI", "https://dev.azure.com/xx/build?definitionScope=%5CIntegrations%5CData%5CAPI")]
    [InlineData("ABC\\{DEF", "ABC{DEF")]
    [InlineData("ABC\\}DEF", "ABC}DEF")]
    [InlineData("ABC\\\\DEF", "ABC\\DEF")]
    [InlineData("{in(a, c, d, a, e)}", "true")]
    [InlineData("{in(a, c, d, A, e)}", "false")]
    [InlineData("abc {in(\"abc def\", c, \"abc def\", A, e)}", "abc true")]
    [InlineData("abc {in(\"abc,def\", c, \"abc,def\", A, e)}", "abc true")]
    [InlineData("-d \"C:/Projects/abc/def\"", "-d \"C:/Projects/abc/def\"")]
    [InlineData("-d \"C:{slash}Projects/abc{backslash}def\"", "-d \"C:/Projects/abc\\def\"")]
    public void Parse(string input, string expectedOutput)
    {
        // arrange
        var sut = new ExpressionExecutor(_providers, _methods);

        // act
        CombinedTypeContainer result = sut.Execute(new Context(), input);

        // assert
        Assert.Equal(expectedOutput, result.ToString());
    }

    [Theory]
    [InlineData("-f \"{Repository.Location} {Repository.Name}\"", "-f \"D:\\repositories ExpressionStringEvaluator\"")]
    [InlineData("-f \"{Repository.Location}\\\\{Repository.Name}\"", "-f \"D:\\repositories\\ExpressionStringEvaluator\"")]
    [InlineData("-f \"{Repository.Location}{backslash}{Repository.Name}\"", "-f \"D:\\repositories\\ExpressionStringEvaluator\"")]
    // [InlineData("-f \"{Repository.Location}{PathSeparator}{Repository.Name}\"", "-f \"D:\\repositories\\ExpressionStringEvaluator\"")] // depends on system
    public void ParseRepoContext(string input, string expectedOutput)
    {
        // arrange
        var repo = new Repository()
            {
                Location = "D:\\repositories",
                Name = "ExpressionStringEvaluator",
            };

        var providers = _providers.ToList();
        providers.Add(new RepositoryVariableProvider());
        var sut = new ExpressionExecutor(providers, _methods);

        // act
        CombinedTypeContainer result = sut.Execute(repo, input);

        // assert
        Assert.Equal(expectedOutput, result.ToString());
    }

    [Theory]
    [InlineData("{not(x)}")] // x is not a boolean, expected
    [InlineData("Dit is %ExpressionStringEvaluatorDummy ExpressionStringEvaluatorDummy% abc")] // %ExpressionStringEvaluatorDummy ExpressionStringEvaluatorDummy% is not a valid env var.
    [InlineData("{trimEnd(tRue)}")] // this occurs becuase tRue is evaluated as string, not as text.
    [InlineData("x {ifthenelse({FileExists(dummyfile2.json)}, exist, )} y")] // todo fix, third argument is null
    [InlineData("{ifthenelse({FileExists(dummyfile2.json)}, exist, )}")]
    public void Parse_ShouldThrow_WhenInvalidInput(string input)
    {
        // arrange
        var sut = new ExpressionExecutor(_providers, _methods);

        // act
        Action act = () => _ = sut.Execute(new Context(), input);

        // assert
        act.Should().Throw<Exception>();
    }

    [Theory]
    [InlineData("{ifthen({FileExists(dummyfile2.json)}, exist)}")]
    public void Parse_ShouldReturnNull_WhenInput(string input)
    {
        // arrange
        var sut = new ExpressionExecutor(_providers, _methods);

        // act
        CombinedTypeContainer result = sut.Execute(new Context(), input);

        // assert
        result.Should().Be(CombinedTypeContainer.NullInstance);
    }

    private LanguageParser.TextExpressionContext GetExpressionContext(string input)
    {
        var inputStream = new AntlrInputStream(input);
        var lexer = new LanguageLexer(inputStream);
        var commonTokenStream = new CommonTokenStream(lexer);

        var parser = new LanguageParser(commonTokenStream);
        LanguageParser.TextExpressionContext result = parser.textExpression();

        _output.WriteLine($"input: '{input}'");
        _output.WriteLine(string.Empty);

        _output.WriteLine("-- TokenStream --");
        _output.WriteLine(string.Empty);

        foreach (IToken token in commonTokenStream.GetTokens())
        {
            var displayName = "EOF";

            if (token.Type != -1)
            {
                displayName = lexer.Vocabulary.GetDisplayName(token.Type);
            }

            _output.WriteLine(token.ToString()?.Replace($"<{token.Type}>", $"<{displayName}>"));
        }

        return result;
    }

    public class Context
    {
    }
}


public class Repository
{
    public string Name { get; set; }

    public string Path { get; set; }

    public string Location { get; set; }

    public string CurrentBranch { get; set; }

    public string[] Branches { get; set; }

    public string[] LocalBranches { get; set; }

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

    public string[] RemoteUrls { get; set; }

    public string SafePath
    {
        // use '/' for linux systems and bash command line (will work on cmd and powershell as well)
        get
        {
            var safePath = Path?.Replace(@"\", "/") ?? string.Empty;
            if (safePath.EndsWith("/"))
            {
                safePath = safePath.Substring(0, safePath.Length - 1);
            }

            return safePath;
        }
    }
}

public class RepositoryVariableProvider : IVariableProvider<Repository>
{
    public bool CanProvide(string key)
    {
        return !string.IsNullOrWhiteSpace(key) && key.StartsWith("Repository.", StringComparison.CurrentCultureIgnoreCase);
    }

    public string Provide(Repository context, string key, string arg)
    {
        var startIndex = "Repository.".Length;
        var k = key.Substring(startIndex, key.Length - startIndex);

        if ("Name".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Name;
        }

        if ("Path".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Path;
        }

        if ("SafePath".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.SafePath;
        }

        if ("Location".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.Location;
        }

        if ("CurrentBranch".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return context.CurrentBranch;
        }

        if ("Branches".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.Branches);
        }

        if ("LocalBranches".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.LocalBranches);
        }

        if ("RemoteUrls".Equals(k, StringComparison.CurrentCultureIgnoreCase))
        {
            return string.Join("|", context.RemoteUrls);
        }

        throw new NotImplementedException();
    }

    public string Provide(string key, string arg)
    {
        throw new NotImplementedException();
    }
}
