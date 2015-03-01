﻿using System;
using LtiLibrary.Core.Common;
using LtiLibrary.Core.Lti1;
using Newtonsoft.Json;

namespace LtiLibrary.Core.ContentItems
{
    public static class ContentItemsClient
    {
        /// <summary>
        /// Create an LtiRequestViewModel that contains a ContentItemPlacementResponse.
        /// </summary>
        /// <param name="url">The content_item_return_url from the content-item message.</param>
        /// <param name="consumerKey">The OAuth consumer key to use to sign the request.</param>
        /// <param name="consumerSecret">The OAuth consumer secret to use to sign the request.</param>
        /// <param name="contentItems">The ContentItemPlacementResponse to send.</param>
        /// <param name="data">The data received in the original content-item message.</param>
        /// <returns>The LtiRequestViewModel which contains a signed version of the response.</returns>
        public static LtiRequestViewModel CreateContentItemSelectionViewModel(
            string url, string consumerKey, string consumerSecret,
            ContentItemPlacementResponse contentItems, string data)
        {
            return CreateContentItemSelectionViewModel(url, consumerKey, consumerSecret, contentItems, data, null, null, null, null);
        }

        /// <summary>
        /// Create an LtiRequestViewModel that contains a ContentItemPlacementResponse.
        /// </summary>
        /// <param name="url">The content_item_return_url from the content-item message.</param>
        /// <param name="consumerKey">The OAuth consumer key to use to sign the request.</param>
        /// <param name="consumerSecret">The OAuth consumer secret to use to sign the request.</param>
        /// <param name="contentItems">The ContentItemPlacementResponse to send.</param>
        /// <param name="data">The data received in the original content-item message.</param>
        /// <param name="ltiErrorLog">Optional plain text error message to be logged by the Tool Consumer.</param>
        /// <param name="ltiErrorMsg">Optional plain text error message to be displayed by the Tool Consumer.</param>
        /// <param name="ltiLog">Optional plain text message to be logged by the Tool Consumer.</param>
        /// <param name="ltiMsg">Optional plain text message to be displayed by the Tool Consumer.</param>
        /// <returns>The LtiRequestViewModel which contains a signed version of the response.</returns>
        public static LtiRequestViewModel CreateContentItemSelectionViewModel(
            string url, string consumerKey, string consumerSecret,
            ContentItemPlacementResponse contentItems, string data,
            string ltiErrorLog, string ltiErrorMsg, string ltiLog, string ltiMsg)
        {
            var ltiRequest = (IContentItemSelection)new LtiRequest(LtiConstants.ContentItemSelectionLtiMessageType)
            {
                Url = new Uri(url),
                ConsumerKey = consumerKey,
                ContentItems = JsonConvert.SerializeObject(contentItems, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                Data = data,
                LtiErrorLog = ltiErrorLog,
                LtiErrorMsg = ltiErrorMsg,
                LtiLog = ltiLog,
                LtiMsg = ltiMsg
            };

            return ltiRequest.GetLtiRequestViewModel(consumerSecret);
        }
    }
}