﻿using HtmlAgilityPack;
using Parser.Interfaces;
using SeleniumProvider;

namespace Parser
{
    public class SeleniumLoader : ILoader
    {
        private readonly IWebDriverProvider _provider;

        public SeleniumLoader()
        {
            _provider = new WebDriverProvider();
        }

        protected SeleniumLoader(IWebDriverProvider provider)
        {
            _provider = provider;
        }

        public HtmlDocument GetPage(IUrl url) => GetPage(url, null);

        public HtmlDocument GetPage(IUrl url, string pendingXPath)
        {
            _provider.GoTo(url.Get(), pendingXPath);
            var html = new HtmlDocument();
            html.LoadHtml(_provider.Source);
            return html;
        }
    }
}
