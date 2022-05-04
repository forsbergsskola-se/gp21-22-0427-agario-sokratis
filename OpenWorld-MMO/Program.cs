using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OpenWorld_MMO
{
    static class Program
    {
        static string phrase = "";
        
        public static void Main()
        {
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 44444);
            var udpClient = new UdpClient(ipEndPoint);
            Console.WriteLine("Server has started");

            while (true)
            {
                var sender = new IPEndPoint(IPAddress.Any, 0);
                var data = udpClient.Receive(ref sender);
                var word = FilterWord(data);

                data = ValidateWord(word);
                udpClient.Send(data, data.Length, sender); 
            }
        }

        private static string FilterWord(byte[] data)
        {
            var temp = Encoding.ASCII.GetString(data, 0, data.Length);
            char whiteSpace = ' ';
            char backSlash = '\n';
            string result = "";
            
            for (int i = 0; i < temp.Length; i++)
            {
                if(temp[i].CompareTo(whiteSpace) == 0 || temp[i].CompareTo(backSlash) == 0) break;
                result += temp[i];
            }
            
            return " " + result;
        }

        private static byte[] ValidateWord(string word)
        {
            byte[] result;
            
            if (word.Length <= 21)
            {
                phrase += word;
                result = PreparePackageToSend(phrase);
            }
            else result = PreparePackageToSend("Invalid word\n");

            return result;
        }

        private static byte[] PreparePackageToSend(string quote) => Encoding.ASCII.GetBytes(quote + '\n');
    }    
};

