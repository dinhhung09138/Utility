using Microsoft.AspNet.SignalR.Client;
using System;
using System.Net;
using System.Threading.Tasks;
using Utils.ErrorLogger;

namespace Utils.SignalRNotification
{
    /// <summary>
    /// Notifier class
    /// </summary>
    public class Notifier
    {

        /// <summary>
        /// Init error message
        /// </summary>
        private class Error
        {
            /// <summary>
            /// Error message for Send function 01
            /// </summary>
            public static string E01 = "Send function with 1 parameter";

            /// <summary>
            /// Error message for Send function 02
            /// </summary>
            public static string E02 = "Send function with 2 parameters";

            /// <summary>
            /// Error message for Send function 03
            /// </summary>
            public static string E03 = "Send function with 3 parameters";

            /// <summary>
            /// Error message for Send function 04
            /// </summary>
            public static string E04 = "Send function with 4 parameters";

            /// <summary>
            /// Error message for Send function 05
            /// </summary>
            public static string E05 = "Send function with 5 parameters";

            /// <summary>
            /// Error message for Send function 06
            /// </summary>
            public static string E06 = "Send function with 6 parameters";

            /// <summary>
            /// Error message for Send function 07
            /// </summary>
            public static string E07 = "Send function with 7 parameters";

            /// <summary>
            /// Error message for Send function 08
            /// </summary>
            public static string E08 = "Send function with 8 parameters";

        }

        /// <summary>
        /// Site url to connect to hub
        /// </summary>
        private static string SITE_BASE_URL = string.Empty;

        /// <summary>
        /// Set default api url
        /// </summary>
        /// <param name="url">api url</param>
        public void SetBaseUrl(string url)
        {
            SITE_BASE_URL = url;
        }

        /// <summary>
        /// Hub name.. 
        /// This is config in website
        /// Default is SignalrHub
        /// </summary>
        private static string HUB_NAME = "SignalrHub";

        /// <summary>
        /// Set default hub name
        /// </summary>
        /// <param name="hubName">Hub name</param>
        public void SetHubName(string hubName)
        {
            HUB_NAME = hubName;
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <returns></returns>
        public static async Task Send(string functionName)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E02, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E03, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2, object value_3)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E04, ex);

            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2, object value_3, object value_4)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E05, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E06, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <param name="value_6">Value 06</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5, object value_6)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E07, ex);
            }
        }

        /// <summary>
        /// Call function to send notification
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <param name="value_6">Value 06</param>
        /// <param name="value_7">Value 06</param>
        /// <returns></returns>
        public static async Task Send(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5, object value_6, object value_7)
        {
            try
            {
                var _hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6, value_7);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E08, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2, object value_3)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2, object value_3, object value_4)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <param name="value_6">Value 06</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5, object value_6)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

        /// <summary>
        /// Call function to send notification to mobile
        /// </summary>
        /// <param name="functionName">Function name, This function is writed on Hub class in site base website </param>
        /// <param name="value_1">Value 01</param>
        /// <param name="value_2">Value 02</param>
        /// <param name="value_3">Value 03</param>
        /// <param name="value_4">Value 04</param>
        /// <param name="value_5">Value 05</param>
        /// <param name="value_6">Value 06</param>
        /// <param name="value_7">Value 06</param>
        /// <returns></returns>
        public static async Task SendToMobile(string functionName, object value_1, object value_2, object value_3, object value_4, object value_5, object value_6, object value_7)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                var _hubConnection = new HubConnection(SITE_BASE_URL)
                {
                    Credentials = CredentialCache.DefaultCredentials,
                    TraceLevel = TraceLevels.All,
                    TraceWriter = Console.Out
                };
                IHubProxy _myHub = _hubConnection.CreateHubProxy(HUB_NAME);
                _hubConnection.Start().Wait();
                await _myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6, value_7);
                _hubConnection.Stop();
            }
            catch (Exception ex)
            {
                TextLoggerHelper.OutputLog(Error.E01, ex);
            }
        }

    }
}
