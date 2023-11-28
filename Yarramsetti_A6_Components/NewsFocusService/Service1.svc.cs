using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using NewsAPI;
using NewsAPI.Models;
using NewsAPI.Constants;

namespace NewsFocusService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string[] NewsFocus(string[] topics)
        {
            string API_KEY = "7ed20f063cd14b34972fb56f91cd2038";
            NewsApiClient newsApiClient = new NewsApiClient(API_KEY);
            List<string> URLs = new List<string>();

            // Make request for each topic in string[] topics
            foreach (string topic in topics)
            {
                ArticlesResult articleResponse = newsApiClient.GetEverything(new EverythingRequest
                {
                    Q = topic,
                    SortBy = SortBys.Relevancy,
                    Language = Languages.EN,
                    From = DateTime.Now.AddDays(-1)
                });

                if (articleResponse.Status == Statuses.Ok)
                {
                    foreach (Article article in articleResponse.Articles)
                    {
                        URLs.Add(article.Url);
                    }
                }
            }

            return URLs.ToArray();
        }
    }
}
