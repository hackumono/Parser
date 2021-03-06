﻿using AutoFixture.NUnit3;
using HtmlAgilityPack;
using Moq;
using NUnit.Framework;
using Parser.Interfaces;

namespace Parser.Test
{
    public class ExecutorTest
    {
        [Theory, AutoMoqData]
        public void RunResultIsEqual(
            string fResult,
            HtmlDocument fHtmlDocument,
            Mock<IUrl> mUrl,
            [Frozen]Mock<ILoader> mILoader,
            [Frozen]Mock<IParser<string>> mIParser,
            Executor executor)
        {
            // arrange
            mIParser.Setup(p => p.Parse()).Returns(fResult);
            Executor.Loader = mILoader.Object;

            // act
            var result = executor.Process(mUrl.Object, mIParser.Object);
            
            // assert
            mILoader.Verify(l => l.GetPage(mUrl.Object, null));
            mIParser.Verify(p => p.Parse());
            Assert.AreEqual(fResult, result);
        }
    }
}
