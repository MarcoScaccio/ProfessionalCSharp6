﻿using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace HttpClientSample
{
    public class SampleMessageHandler : HttpClientHandler
    {
        private string _displayMessage;
        public SampleMessageHandler(string message)
        {
            _displayMessage = message;
        }

#if DNX46
        // method is internal with .NET Core
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            WriteLine($"In SampleMessageHandler {_displayMessage}");
            if (_displayMessage == "error")
            {
                var response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                return Task.FromResult<HttpResponseMessage>(response);
            }

            return base.SendAsync(request, cancellationToken);
        }
#endif
    }
}
