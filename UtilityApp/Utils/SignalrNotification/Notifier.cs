using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace Utils.SignalRNotification
{
    /// <summary>
    /// Notifier class
    /// </summary>
    public class Notifier
    {
        /// <summary>
        /// Site url to connect to hub
        /// </summary>
        private static string SITE_BASE_URL = "";

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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2, value_3);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2, value_3, value_4);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
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
                var hubConnection = new HubConnection(SITE_BASE_URL);
                IHubProxy myHub = hubConnection.CreateHubProxy(HUB_NAME);
                hubConnection.Start().Wait();
                await myHub.Invoke(functionName, value_1, value_2, value_3, value_4, value_5, value_6, value_7);
                hubConnection.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
            }
        }
    }
}
