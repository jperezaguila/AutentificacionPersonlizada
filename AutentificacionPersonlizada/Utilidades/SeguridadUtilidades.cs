using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AutentificacionPersonlizada.Utilidades
{
    class SeguridadUtilidades
    {

        public static byte[] GetKey(String txt)
        {
            return new PasswordDeriveBytes(txt, null).GetBytes(32);
        }

        //Cuando llame a GetSha1 se ejecute la desencriptacion del dato.
        public static String GetSha1(String texto)
        {
            //sha1.create segun se este utilizando
            var sha = SHA1.Create();
            // ASCIIEncoding encoding=new ASCIIEncoding();
            UTF8Encoding encoding =new UTF8Encoding();
            //crearemos una array de bytes que decodificaremos luego
            byte[] datos;
            //StringBuilder permite concatenar cosas a las cadenas.
            StringBuilder builder=new StringBuilder();
            // sha.ComputeHash genera un hash sha1 y lo devuelve en datos (array de bytes)
            datos = sha.ComputeHash(encoding.GetBytes(texto));
            //ese array de datos ahora debemos transformarlo en texto puro con el for 
            for (int i = 0; i < datos.Length; i++)
            {    //por cada array que tenga en datos lo convierto en hexadecimal dos digitos (de 2 en 2)
                builder.AppendFormat("{0:x2}", datos[i]);
            }
            return builder.ToString();
        }



        public static String Cifrar(String contenido, String clave)
        {
            //para codificar el texto que quiero cifrar
            var encoding = new UTF8Encoding();
            var cripto=new RijndaelManaged();

            byte[] cifrado;
            byte[] retorno;
            //clave generada en bytes
            byte[] key = encoding.GetBytes(clave);
            
            //asigno la clave y ek IV
            cripto.Key = key;
            cripto.GenerateIV();

            byte[] aEncriptar = encoding.GetBytes(contenido);
            //Creo un encriptador CreateEncryptor() el array aEncriptar desde posicion 0
            cifrado = cripto.CreateEncryptor().TransformFinalBlock(aEncriptar, 0, aEncriptar.Length);
            //el array retorno sera = la suma del vector mas longitud del cifrado
            retorno = new byte[cripto.IV.Length + cifrado.Length];
            
            //copias IV desde la posicion 0
            cripto.IV.CopyTo(retorno,0);

            cifrado.CopyTo(retorno,cripto.IV.Length);
            //convierto la cadena en base 64, por ejemplo una imagen, word, etc
            //contiene todo el flujo de datos

            return Convert.ToBase64String(retorno);
        }

        public static String Descifrar(String contenido, String clave)
        {
            //
            UTF8Encoding encoding=new UTF8Encoding();

            var cripto= new RijndaelManaged();
            //Este vecto es temporal
            var ivTemp = new byte[cripto.IV.Length];
            //es el crifrado y viene de un texto UTF8
            var datos = encoding.GetBytes(contenido);
            
            var key = encoding.GetBytes(clave);

            var cifrado =new byte[datos.Length - ivTemp.Length];

            cripto.Key = key;
            //coge un trozo de un array y lo copia en otro array
            Array.Copy(datos,ivTemp,ivTemp.Length);
            //aqui le digo el origen posicion origin , posicion destino, destino
            Array.Copy(datos,ivTemp.Length,cifrado,0,cifrado.Length);

            cripto.IV = ivTemp;
            //aqui dispongo del array descifrado.
            var descifrado = cripto.CreateDecryptor().TransformFinalBlock(cifrado, 0, cifrado.Length);
            return encoding.GetString(descifrado);


        }


    }
}
