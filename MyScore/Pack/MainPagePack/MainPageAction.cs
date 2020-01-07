﻿using SeleniumProvider;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MyScore.Pack.MainPagePack
{
    public class MainPageAction
    {
        private readonly IWebDriverProvider _provider;

        public MainPageAction(IWebDriverProvider provider)
        {
            _provider = provider;
        }

        public void AddLeagues(List<string> source)
        {
            MoreCountry();
            _provider.Wait();
            foreach (var s in source)
            {
                var num = Regex.Match(s, @"_(\w+)_").Groups[1].Value;
                var id = "lmenu_" + num;
                AddLeague(id, s);
            }
        }

        public void MoreCountry()
        {
            _provider.Click("//li[contains(@class,\"show-more\")]");
        }

        public void AddLeague(string id, string cl)
        {
            _provider.Click($"//*[@id=\"{id}\"]");
            _provider.Wait();
            _provider.Click($"//*[@id=\"{id}\"]/descendant::span[contains(@class,\"{cl}\")]");
        }

        public void RemoveLeagues(List<string> source)
        {
            foreach (var s in source)
                RemoveLeague(s);
        }

        public void RemoveLeague(string cl)
        {
            _provider.HoverElement(XPathConst.IdMyLeaguesList + $"/descendant::span[contains(@class,\"{cl}\")]/parent::li");
            _provider.HoverElement(XPathConst.IdMyLeaguesList + $"/descendant::span[contains(@class,\"{cl}\")]");
            _provider.Click(XPathConst.IdMyLeaguesList + $"/descendant::span[contains(@class,\"{cl}\")]");
        }

        public void Yesterday()
        {
            _provider.Click("//div[contains(@class,\"calendar__direction--yesterday\")]");
            _provider.WaitDisplayedElement(XPathConst.ContainsEventHeader);
        }

        public void Tomorrow()
        {
            _provider.Click("//div[contains(@class,\"calendar__direction--tomorrow\")]");
            _provider.WaitDisplayedElement(XPathConst.ContainsEventHeader);
        }
    }
}
