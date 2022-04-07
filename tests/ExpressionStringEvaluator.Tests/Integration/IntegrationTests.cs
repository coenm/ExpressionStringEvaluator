using ExpressionStringEvaluator;
using ExpressionStringEvaluator.Formatters;
using ExpressionStringEvaluator.Methods;
using ExpressionStringEvaluator.Methods.BooleanToBoolean;
using ExpressionStringEvaluator.Methods.StringToBoolean;
using ExpressionStringEvaluator.Methods.StringToInt;
using ExpressionStringEvaluator.Methods.StringToString;
using ExpressionStringEvaluator.Parser;
using ExpressionStringEvaluator.VariableProviders;
using ExpressionStringEvaluator.VariableProviders.DateTime;
using ExpressionStringEvaluator.VariableProviders.FileInfo;
using FluentAssertions;
using FluentAssertions.Execution;

namespace Core.Tests.Integration
{
    using System;
    using System.Collections.Generic;

    using Antlr4.Runtime;
    using Core;
    using Xunit;
    using Xunit.Abstractions;

    public class IntegrationTests
    {
        private readonly ITestOutputHelper _output;
        private readonly List<IVariableProvider> _providers;
        private readonly List<IMethod> _methods;

        public IntegrationTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));

            _providers = new List<IVariableProvider>
                             {
                                 new DateTimeNowVariableProvider(DateTimeFormatter.Instance),
                                 new DateTimeTimeVariableProvider(DateTimeFormatter.Instance),
                                 new DateTimeDateVariableProvider(DateTimeFormatter.Instance),
                                 new FilenameBaseVariableProvider(),
                                 new FilenameVariableProvider(),
                                 new FilePathVariableProvider(),
                                 new FileExtensionVariableProvider(),
                                 new PathSeparatorVariableProvider(),
                                 new EmptyVariableProvider(),
                                 new EnvironmentVariableVariableProvider(),
                             };

            _methods = new List<IMethod>
                           {
                               new StringTrimEndStringMethod(),
                               new StringTrimStartStringMethod(),
                               new StringTrimStringMethod(),
                               new StringLowerStringMethod(),
                               new StringUpperStringMethod(),
                               new UrlEncodeStringMethod(),
                               new UrlDecodeStringMethod(),
                               new StringEqualsStringMethod(),
                               new AndBooleanMethod(),
                               new OrBooleanMethod(),
                               new StringIsNullOrEmptyBooleanMethod(),
                               new FileExistsBooleanMethod(),
                               new NotBooleanMethod(),
                               new StringLengthMethod(),
                               new IfThenElseMethod(),
                               new IfThenMethod(),
                           };
        }

        [Theory]
        [InlineData(
            "{filepath}{PathSeparator}{now}t a{time} aap {date} {env.OS} xx {empty}{fileextension} me  {filenamebase}.pdf ",
            "D:\\aap\\beer\\cobra\\2020-12-1 15.22.23t a15.22.23 aap 2020-12-1 Windows_NT xx .docx me  File 234 Final.pdf ")]
        [InlineData(
            "{filepath}{PathSeparator}{now}t a{time} aap {date} %OS% xx {empty}{fileextension} me  {filenamebase}.pdf ",
            "D:\\aap\\beer\\cobra\\2020-12-1 15.22.23t a15.22.23 aap 2020-12-1 Windows_NT xx .docx me  File 234 Final.pdf ")]

        [InlineData(
            "{filepath}{Pathseparator}{now:yyyy}t a{time} aap {date} {env.OS} xx {empty}{fileextension} me  {filenamebase}.pdf ",
            "D:\\aap\\beer\\cobra\\2020t a15.22.23 aap 2020-12-1 Windows_NT xx .docx me  File 234 Final.pdf ")]

        [InlineData(
            "{filepath}{pathSeparator}{now:yyyy}t a{time} aap {date} {Lower({env.OS})} xx {empty}{Upper({fileextension})} me  {filenamebase}.pdf ",
            "D:\\aap\\beer\\cobra\\2020t a15.22.23 aap 2020-12-1 windows_nt xx .DOCX me  File 234 Final.pdf ")]

        [InlineData("Fixed ",                                                "Fixed ")]
        [InlineData(" Fixed",                                                " Fixed")]
        [InlineData("Fixed",                                                 "Fixed")]
        [InlineData("F:i_x.e-d",                                             "F:i_x.e-d")]
        [InlineData("{now:yyyy:MM _.-  dd}",                                 "2020:12 _.-  01")]
        [InlineData("{StringEquals({env.OS}, aap)}",                         "false")]
        [InlineData("{StringEquals({env.OS}, Windows_NT)}",                  "true")]

        [InlineData("{StringEquals({now:yyyy},2020)}",                       "true")]
        [InlineData("{StringEquals({now:yyyy}, 2020)}",                      "true")]
        [InlineData("{StringEquals({now:yyyy},\"2020\")}",                   "true")]
        [InlineData("{Lower({env.OS})}",                                     "windows_nt")]
        [InlineData("{Upper({env.OS})}",                                     "WINDOWS_NT")]
        [InlineData("{env.OS}",                                              "Windows_NT")]
        [InlineData("http://www.google.com:8000",                            "http://www.google.com:8000")]
        [InlineData("fake@github.com",                                       "fake@github.com")]
        [InlineData("{Upper(text)} x",                                       "TEXT x")]
        [InlineData("{UrlEncode(http://www.google.com:8080/abc)} x",         "http%3a%2f%2fwww.google.com%3a8080%2fabc x")]
        [InlineData("{Upper({filenamebase}.abc {Lower(TeSt)})} x",           "FILE 234 FINAL.ABC TEST x")]

        [InlineData("TrUe", "true")]
        [InlineData("1", "true")]
        [InlineData("False", "false")]
        [InlineData("0", "false")]
        [InlineData("abctRuede", "abctRuede")]
        [InlineData("abc tRuede", "abc tRuede")]
        [InlineData("abc tRue de", "abc tRue de")]

        [InlineData("%OS%", "Windows_NT")]
        [InlineData("Dit is %OS% Aap", "Dit is Windows_NT Aap")]

        [InlineData("{And(true, True)}", "true")]
        [InlineData("{And(TRUE)}", "true")]
        [InlineData("{And(1, true)}", "true")]
        [InlineData("{And(1, {StringEquals({now:yyyy},2020)})}", "true")]

        [InlineData("{And(true, False, True)}", "false")]
        [InlineData("{And(true, False, True, false)}", "false")]
        [InlineData("{And(TRUE, 0)}", "false")]
        [InlineData("{And(1, true, FALSE)}", "false")]
        [InlineData("{And(1,   {StringEquals({now:yyyy},2022)})}", "false")]

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
        [InlineData("{IsNullOrEmpty(%OS%)}", "false")]

        [InlineData("{FileExists(%OS%)}", "false")]
        [InlineData("{not(true)}", "false")]
        [InlineData("{not(false)}", "true")]

        [InlineData("{FileExists(dummyfile.json)}", "true")]
        [InlineData("{FileExists(dummyfile2.json)}", "false")]
        [InlineData("{not({FileExists(dummyfile2.json)})}", "true")]

        [InlineData("{trimEnd(  aaaa   )}", "  aaaa")]
        [InlineData("{trimstart({trimEnd(  aaaa   )})}", "aaaa")]
        [InlineData("{trimstart({trimEnd(  tRue   )})}", "tRue")]

        [InlineData("{length(github)}", "6")]
        [InlineData("{length(%OS%)}", "10")] // Windowns_NT

        [InlineData("{ifthenelse(true, a, b)}", "a")]
        [InlineData("{ifthenelse(false, a, b)}", "b")]
        [InlineData("{conditional({FileExists(dummyfile.json)}, exist, toCreate)}", "exist")]
        [InlineData("{conditional({FileExists(dummyfile.json)}, exist, {empty})}", "exist")]
        [InlineData("{conditional(false, a, b)}", "b")]
        [InlineData("{ifthen({FileExists(dummyfile.json)}, exist)}", "exist")]
        [InlineData("file does {ifthen({not({FileExists(dummyfile.json)})}, not)}exist", "file does exist")]
        [InlineData("file does {ifthen({not({FileExists(dummyfile2.json)})}, \"not \")}exist", "file does not exist")]
        [InlineData("file does{ifthenelse({FileExists(dummyfile2.json)}, \" \", \" not\")} exist", "file does not exist")]
        public void Parse(string input, string expectedOutput)
        {
            // arrange
            var defaultDateFormats = new DefaultFormats(
                                                        "yyyy-M-d HH.mm.ss",
                                                        "yyyy-M-d",
                                                        "HH.mm.ss");
            var ctx = new Context(
                                  new DateTime(2020, 12, 1, 15, 22, 23),
                                  @"D:\aap\beer\cobra\File 234 Final.docx",
                                  defaultDateFormats);
            var visitor = new LanguageVisitor(_providers, _methods, ctx);

            // act
            var context = GetExpressionContext(input);

            var result = visitor.Visit(context);

            // assert
            Assert.Equal(expectedOutput, result.ToString());
        }

        [Theory]
        [InlineData("{not(x)}")] // x is not a boolean, expected
        [InlineData("Dit is %OS OS% Aap")] // %OS OS% is not a valid env var.
        [InlineData("{trimEnd(tRue)}")] // this occurs becuase tRue is evaluated as string, not as text.
        [InlineData("{conditional({FileExists(dummyfile.json)}, file does exist, file does not exist)}")] // todo fix (spaces)
        [InlineData("x {conditional({FileExists(dummyfile2.json)}, exist, )} y")] // todo fix, third argument is null
        [InlineData("{conditional({FileExists(dummyfile2.json)}, exist, )}" )]
        public void Parse_ShouldThrow_WhenInvalidInput(string input)
        {
            // arrange
            var defaultDateFormats = new DefaultFormats(
                "yyyy-M-d HH.mm.ss",
                "yyyy-M-d",
                "HH.mm.ss");
            var ctx = new Context(
                new DateTime(2020, 12, 1, 15, 22, 23),
                @"D:\aap\beer\cobra\File 234 Final.docx",
                defaultDateFormats);
            var visitor = new LanguageVisitor(_providers, _methods, ctx);

            // act
            var context = GetExpressionContext(input);

            Action act = () => _ = visitor.Visit(context);

            // assert
            act.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData("{ifthen({FileExists(dummyfile2.json)}, exist)}")]
        public void Parse_ShouldReturnNull_WhenInput(string input)
        {
            // arrange
            var defaultDateFormats = new DefaultFormats(
                "yyyy-M-d HH.mm.ss",
                "yyyy-M-d",
                "HH.mm.ss");
            var ctx = new Context(
                new DateTime(2020, 12, 1, 15, 22, 23),
                @"D:\aap\beer\cobra\File 234 Final.docx",
                defaultDateFormats);
            var visitor = new LanguageVisitor(_providers, _methods, ctx);

            // act
            var context = GetExpressionContext(input);

            CombinedTypeContainer result = visitor.Visit(context);

            // assert
            result.Should().Be(CombinedTypeContainer.NullInstance);
        }

        private LanguageParser.ExpressionContext GetExpressionContext(string input)
        {
            var inputStream = new AntlrInputStream(input);
            var lexer = new LanguageLexer(inputStream);
            var commonTokenStream = new CommonTokenStream(lexer);

            var parser = new LanguageParser(commonTokenStream);
            var result = parser.expression();

            _output.WriteLine($"input: '{input}'");
            _output.WriteLine(string.Empty);

            _output.WriteLine("-- TokenStream --");
            _output.WriteLine(string.Empty);

            foreach (var token in commonTokenStream.GetTokens())
            {
                var displayName = "EOF";

                if (token.Type != -1)
                    displayName = lexer.Vocabulary.GetDisplayName(token.Type);

                _output.WriteLine(token.ToString()?.Replace($"<{token.Type}>", $"<{displayName}>"));
            }

            return result;
        }
    }
}
