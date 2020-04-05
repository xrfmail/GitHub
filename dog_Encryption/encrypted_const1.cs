//    Source data: 123456789

public class EncryptedConst1
{
    public const int EncryptConstFeatureID = 0;    //feature id which is selected
    public const System.UInt32 EncryptConstBufSize = 16;    //length of encrypt constants
    public System.Int32 ConstValue;    //decrypted constants

    public System.Int32 ConvertByteArr(byte []constArr){ return (System.Int32)(((constArr[3] & 0xff) << 24) | ((constArr[2] & 0xff) << 16) | ((constArr[1] & 0xff) << 8) | (constArr[0] & 0xff)); }

    public byte[] encryptConstArr = new byte[16]{ 
   0x40, 0xB3, 0xA2, 0x92, 0xF6, 0x51, 0x5B, 0x99, 0x2D, 0x06, 0xCF, 0x21, 0x06, 0x81, 0xBF, 0xCB
 };
}