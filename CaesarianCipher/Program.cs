public class Cipher
{

    /**
    Encrypt plaintext using the specified key.

    * @param - plaintext: the message to be encrypted
    * @param - key: the amount to shift the chars array
    * @return - encrypted message as a string
    */
    public static string Encrypt(string plaintext, int key)
    {
        string ciphertext = "";
        String[] chars = {"a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", ".", "?", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "="};
        string currChar;
        int currCharIndex; 
        //iterate through plaintext, changing each character
        for (int i=0; i < plaintext.Length; i++)
        {
            currChar = plaintext.Substring(i,1);
            currCharIndex = Array.IndexOf(chars, currChar);

            if(currCharIndex == -1) //not in chars array
            {
                ciphertext += currChar;
            }
            else
            {
                ciphertext += chars[(currCharIndex+key)%chars.Length];
            }
        }

        return ciphertext;
    }

    /*Decrypt ciphertext using the specified key.

    * @param - ciphertext: the message to be decrypted
    * @param - key: the amount to shift the chars array backwards
    * @return - decrypted message as a string
    */
    public static string Decrypt(string ciphertext, int key)
    {
        string plaintext = "";
        String[] chars = {"a","b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", ".", "?", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "+", "="};
        string currChar;
        int currCharIndex;
        int index;

        //iterate through ciphertext, changing each character
        for (int i=0; i < ciphertext.Length; i++)
        {
            currChar = ciphertext.Substring(i,1);
            currCharIndex = Array.IndexOf(chars, currChar);
            if(currCharIndex == -1) //not in chars array
            {
                plaintext += currChar;
            }
            else
            {
                index=currCharIndex-key;
                if(index<0)
                {
                    index += chars.Length;
                }
                plaintext += chars[index];
            }
        }

        return plaintext;
    }

    /*Asks the user if they want to encrypt or decrypt and runs the appropriate method.
    */
    public static void Play()
    {
        string userInput;
        string userMessage;
        string userKeyAsString;
        int userKey = 1;
        bool notANumber = true;

        Console.WriteLine("Do you want to encrypt or decrypt a message?");
        userInput = Console.ReadLine();
        //validate user input
        while(!userInput.Equals("encrypt")  && !userInput.Equals("decrypt"))
        {
            Console.WriteLine("You must type \"encrypt\" or \"decrypt\".");
            userInput = Console.ReadLine();
        }

        Console.WriteLine("What is your key?");
        userKeyAsString = Console.ReadLine();
        //validate user input
        while(notANumber)
        {
            try
            {
                userKey= Int32.Parse(userKeyAsString);
                notANumber = false;

            }
            catch (System.Exception)
            {
                
                Console.WriteLine("You must type a valid key.");
                userKeyAsString = Console.ReadLine();
            }
        }

        if(userInput.Equals("encrypt"))
        {
            Console.WriteLine("What is the message you wish to encrypt?");
            userMessage = Console.ReadLine();
            Console.WriteLine("The encypted message is: \"" + Encrypt(userMessage, userKey) + "\"");
        }
        else
        {
            Console.WriteLine("What is the message you wish to decrypt?");
            userMessage = Console.ReadLine();
            Console.WriteLine("The decrypted message is: \"" + Decrypt(userMessage, userKey) + "\"");
        }
    }


    public static void Main(string[] args)
    {
        string replay = "Y";
        while(replay.Equals("Y"))
        {
            Play();
            Console.WriteLine("Do you wish to encrypt or decrypt another message? Y/N");
            replay = Console.ReadLine();
            //validate user input
            while(!replay.Equals("Y") && !replay.Equals("N"))
            {
                Console.WriteLine("You must type \"Y\" or \"N\".");
                replay = Console.ReadLine();
            }
        }

}
}