﻿using NaOtvet.Api.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NaOtvet.Api.Client
{
    public static class NaOtvetClient
    {
        private const string BaseUrl = "http://naotvet.pp.ua";

        public static WebLink[] GetWebLinks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(BaseUrl + "/api/info/webLinks").Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (WebLink[])JsonConvert.DeserializeObject(json, typeof(WebLink[]));
            }
        }

        public static WebLink[] GetWebLinks(string[] names)
        {
            if (names is null)
                throw new ArgumentNullException();

            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(names), Encoding.UTF8, "application/json");
                var response = client.PostAsync(BaseUrl + "/api/info/webLinks", data).Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (WebLink[])JsonConvert.DeserializeObject(json, typeof(WebLink[]));
            }
        }

        public static WebLink GetWebLink(string name)
        {
            return GetWebLinks(new string[] { name }).First();
        }

        public static WebSiteAccount GetWebSiteAccount(string webSite)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(webSite), Encoding.UTF8, "application/json");
                var response = client.PostAsync(BaseUrl + "/api/info/webSiteAccount", data).Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (WebSiteAccount)JsonConvert.DeserializeObject(json, typeof(WebSiteAccount));
            }
        }

        public static ApplicationVersion GetApplicationVersion(string version)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(version), Encoding.UTF8, "application/json");
                var response = client.PostAsync(BaseUrl + "/api/application/version", data).Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (ApplicationVersion)JsonConvert.DeserializeObject(json, typeof(ApplicationVersion));
            }
        }

        public static ApplicationVersion GetLastApplicationVersion()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(BaseUrl + "/api/application/lastVersion").Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (ApplicationVersion)JsonConvert.DeserializeObject(json, typeof(ApplicationVersion));
            }
        }

        public static SolvedTestSession GetSolvedTestSession(int settingsId)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(BaseUrl + $"/api/tests/solvedSession/fromSettings/{settingsId}").Result;
                var json = response.Content.ReadAsStringAsync().Result;

                return (SolvedTestSession)JsonConvert.DeserializeObject(json, typeof(SolvedTestSession));
            }
        }

        public static void SaveSolvedTestSession(SolvedTestSession session)
        {
            using (var client = new HttpClient())
            {
                var data = new StringContent(JsonConvert.SerializeObject(session), Encoding.UTF8, "application/json");                
                client.PostAsync(BaseUrl + $"/api/tests/solvedSessions/new", data).Wait();
            }
        }
    }
}
