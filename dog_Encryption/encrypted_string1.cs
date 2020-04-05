//    Source string:
//teststring1234

public class EncryptedString1
{
    public const int EncryptBufFeatureID = 0;    //feature id which is selected
    public int SourceBufLen = 14;    //length of source string
    public int EncryptBufLen = 16;    //length of encrypt string

    public int isString = 1;    //This is a string buffer
/*The encrypted array is in UTF-8 format. Please convert it to proper format before using it.*/ 

    public byte[] encryptStrArr = new byte[16]{ 
   0x93, 0x3F, 0x23, 0x04, 0x68, 0x96, 0xBC, 0x81, 0xA8, 0x07, 0x03, 0x15, 0xDE, 0x97, 0x0A, 0xA5
 };
}