﻿using RestSharp;

namespace Boa.Constrictor.RestSharp
{
    /// <summary>
    /// Provides more fluent calls for RestSharp Questions.
    /// For example, `Actor.Calls(Rest.Request("...", request))` reads much better than `Actor.AsksFor(RestApiResponse.From("...", request))`.
    /// </summary>
    public static class Rest
    {
        /// <summary>
        /// More concise builder for RestCookie.
        /// Recommended usage: `Actor.AsksFor(Rest.Cookie("...", "..."))`
        /// </summary>
        /// <param name="baseUrl">The base URL for the request.</param>
        /// <param name="name">The cookie name.</param>
        /// <param name="expirationMinutes">The minutes to add to the current time for resetting cookie expiration.</param>
        /// <returns></returns>
        public static RestCookie Cookie(string baseUrl, string name, int? expirationMinutes = null) =>
            RestCookie.Named(baseUrl, name).AndResetExpirationTo(expirationMinutes);

        /// <summary>
        /// More fluent builder for RestFileDownload.
        /// Recommended usage: `Actor.Calls(Rest.Download("...", request, "..."))`
        /// </summary>
        /// <param name="baseUrl">The base URL for the request.</param>
        /// <param name="request">The REST request to call.</param>
        /// <param name="fileExtension">The extension for the file to download.</param>
        /// <returns></returns>
        public static RestFileDownload Download(string baseUrl, IRestRequest request, string fileExtension = null) =>
            RestFileDownload.From(baseUrl, request, fileExtension);

        /// <summary>
        /// More fluent builder for RestApiResponse.
        /// Recommended usage: `Actor.Calls(Rest.Request("...", request))`.
        /// </summary>
        /// <param name="baseUrl">The base URL for the request.</param>
        /// <param name="request">The REST request to call.</param>
        /// <returns></returns>
        public static RestApiResponse Request(string baseUrl, IRestRequest request) =>
            RestApiResponse.From(baseUrl, request);

        /// <summary>
        /// More fluent builder for RestApiResponse<typeparamref name="TData"/>.
        /// Recommended usage: `Actor.Calls(Rest.Request<typeparamref name="TData"/>("...", request))`.
        /// </summary>
        /// <typeparam name="TData">The deserialization object type.</typeparam>
        /// <param name="baseUrl">The base URL for the request.</param>
        /// <param name="request">The REST request to call.</param>
        /// <returns></returns>
        public static RestApiResponse<TData> Request<TData>(string baseUrl, IRestRequest request) =>
            RestApiResponse<TData>.From(baseUrl, request);
    }
}