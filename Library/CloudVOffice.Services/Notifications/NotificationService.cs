using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Core.Domain.DeliveryPartners;
using CloudVOffice.Data.Persistence;
using CloudVOffice.Data.Repository;
using Newtonsoft.Json;
using System.Net.Http;

namespace CloudVOffice.Services.Notifications
{
    public class NotificationService : INotificationService
    {

        public async Task<MessageEnum> SendNotification(string fcmToken, string message, string title)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://fcm.googleapis.com");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "key=AAAANQNlVQ8:APA91bE54e-TdFf8Xs1ydJRmMs0n-HoEhH5FKe9s_lHZ241MdwLT8AvUuM5pyGb8A6z7ACkyfm9A43eGk8PeJ73mAqMIty-EmR_Z_a-Iv0L0mFc5YN1WG8B9vx9sj_apkX3gEmso4uW6");
                    client.DefaultRequestHeaders.TryAddWithoutValidation("Sender", "id=227690239247");

                    var data = new
                    {
                        to = fcmToken,
                        notification = new
                        {
                            body = message,
                            head = title
                        }
                    };

                    var json = JsonConvert.SerializeObject(data);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                    var result = await client.PostAsync("/fcm/send", httpContent);

                    if (result.IsSuccessStatusCode)
                    {
                        return MessageEnum.Success;
                    }
                    else
                    {
                        return MessageEnum.Invalid;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
