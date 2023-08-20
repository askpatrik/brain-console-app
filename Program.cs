using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace BrainFudge
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "----[++--++]+--,";


            //Valid Ascii 32-126
            BrainLuck lucky = new BrainLuck();
            lucky.ReadCode(s);


        }
        public class BrainLuck
        {
            const int memorySize = 30000;
            byte[] memory = new byte[memorySize];
            int memoryPointer = 0;
            int inputPointer = 0;
            List<byte> output = new List<Byte>();


            public void SquareBracketHandler(string code)
            {
                int temp = memoryPointer;
                while (memory[temp] != 0)
                {
                    ReadCode(code);
                    //[++--++] skicka till readcode
                }

            }
            public string ReadCode(string code)
            {

                for (int i = 0; i < code.Length; i++)
                {
                    switch (code[i])
                    {
                        case '>':
                            memoryPointer++;
                            break;
                        case '<':
                            memoryPointer--;
                            break;
                        case '+':
                            memory[memoryPointer]++;
                            break;
                        case '-':
                            memory[memoryPointer]--;
                            break;
                        case '.':
                            output.Add(memory[memoryPointer]);
                            break;
                        // case ',':
                        //     {
                        //         memory[memoryPointer] = Convert.ToByte(input[inputPointer]);
                        //         inputPointer++;
                        //         break;
                        //     }
                        case '[':
                            {
                                string subS = code.Substring(code.IndexOf(code[i]) + 1, code.IndexOf(']') - code.IndexOf(code[i])-1);
                                SquareBracketHandler(subS);
                            }

                            break;

                    }
                }


                byte[] byteArr = output.ToArray();
                string toAscii = Encoding.ASCII.GetString(byteArr);

                return toAscii;
            }
        }
    }
}