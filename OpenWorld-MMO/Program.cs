using System.Net;
using System.Net.Sockets;
using System.Text;

namespace OpenWorld_MMO
{
    static class Program
    {
        static string _phrase = "";
        
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

        /// <summary>
        /// Discard everything from a whiteSpace or a break line
        /// </summary>
        /// <param name="data">byte[]</param>
        /// <returns>String</returns>
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
            
            return result + " ";
        }
        
        /// <summary>
        /// Check if a word has less than 20 characters 
        /// </summary>
        /// <param name="word">String</param>
        /// <returns>Byte[]</returns>
        private static byte[] ValidateWord(string word)
        {
            byte[] result;
            
            if (word.Length <= 21)
            {
                _phrase += word;
                result = PreparePackageToSend(_phrase);
            }
            else result = PreparePackageToSend("Invalid word\n");

            return result;
        }

        /// <summary>
        /// Convert a string to Byte[]
        /// </summary>
        /// <param name="quote">String</param>
        /// <returns>Byte[]</returns>
        private static byte[] PreparePackageToSend(string quote) => Encoding.ASCII.GetBytes(quote + '\n');
    }    
};

