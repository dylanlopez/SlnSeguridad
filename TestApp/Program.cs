using Business_Layer.Utils;
using System;

namespace TestApp
{
    class Program
    {
        

        static void Main(string[] args)
        {
            BEncrypt enc = new BEncrypt();
            Console.WriteLine("Ingrese el texto que desea encriptar: ");
            var texto = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Texto original: " + texto);
            Console.WriteLine("Longitud de texto original: " + texto.Length);
            Console.WriteLine("");
            enc.TextToEncrypt = texto;
            enc.Encrypt256();
            var encriptado = enc.TextEncrypted;
            Console.WriteLine("Texto encriptado: " + encriptado);
            Console.WriteLine("Longitud de texto encriptado: " + encriptado.Length);
            Console.WriteLine("");

            BDecrypt dec = new BDecrypt();
            dec.TextToDecrypt = encriptado;
            dec.Decrypt256();
            var desencriptado = dec.TextDecrypted;
            Console.WriteLine("Texto desencriptado: " + desencriptado);
            Console.WriteLine("Longitud de texto desencriptado: " + desencriptado.Length);
            Console.ReadLine();
        }
    }
}