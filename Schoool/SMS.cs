using System;

namespace Schoool
{
    internal class SMS
    {
        Random random = new Random();
        public bool SendSMS(SmsModel sms)
        {
            try
            {
                //System.Threading.Thread.Sleep(1);
                //Console.WriteLine($"sms sent to {sms.Mobile} in {DateTime.Now}");
                //int c = 5 / random.Next(1, 5);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
