////////////////////////////////////////////////////////////////////
// Copyright (C) 2012 SafeNet, Inc. All rights reserved.
//
// SuperDog(R) is a trademark of SafeNet, Inc.
//
//
////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Specialized;
using System.Text;
using System.Runtime.InteropServices;
using SuperDog;
using Sys;
using System.Xml;

namespace dog_test
{
    /// <summary>
    /// </summary>
    public class DogDemo
    {
        #region parameters
        protected StringCollection stringCollection;

        public const int FileId = 0xfff4;    // file id of default read/write file

        public const string defaultScope = "<dogscope />";

        private string scope;
        #endregion

        #region ini parameters
        /// <summary>
        /// Constructor
        /// Intializes the object.
        /// </summary>
        public DogDemo()
        {

            // next could be considered ugly.
            // build up a string collection holding
            // the status codes in a human readable manner.
            string[] stringRange = new string[]
            {
                "Request successfully completed.",
                "Request exceeds data file range.",
                "",
                "System is out of memory.",
                "Too many open login sessions.",
                "Access denied.",
                "",
                "Required SuperDog not found.",
                "Encryption/decryption data length is too short.",
                "Invalid input handle.",
                "Specified File ID not recognized by API.",
                "",
                "",
                "",
                "",
                "Invalid XML format.",
                "",
                "",
                "SuperDog to be updated not found.",
                "Required XML tags not found; Contents in binary data are missing or invalid.",
                "Update not supported by SuperDog.",
                "Update counter is set incorrectly.",
                "Invalid Vendor Code passed.",
                "",
                "Passed time value is outside supported value range.",
                "",
                "Acknowledge data requested by the update, however the ack_data input parameter is NULL.",
                "Program running on a terminal server.",
                "",
                "Unknown algorithm used in V2C file.",
                "Signature verification failed.",
                "Requested Feature not available.",
                "",
                "Communication error between API and local SuperDog License Manager.",
                "Vendor Code not recognized by API.",
                "Invalid XML specification.",
                "Invalid XML scope.",
                "Too many SuperDog currently connected.",
                "",
                "Session was interrupted.",
                "",
                "Feature has expired.",
                "SuperDog License Manager version too old.",
                "USB error occurred when communicating with a SuperDog.",
                "",
                "System time has been tampered.",
                "Communication error occurred in secure channel.",
                "",
                "",
                "",
                "Unable to locate a Feature matching the scope.",
                "",
                "",
                "",
                "Trying to install a V2C file with an update counter that is out" +
                "of sequence with the update counter in the SuperDog." +
                "The values of the update counter in the file are lower than" +
                "those in the SuperDog.",
                "Trying to install a V2C file with an update counter that is out" +
                "of sequence with the update counter in the SuperDog." +
                "The first value of the update counter in the file is greater than" +
                "the value in the SuperDog."
            };

            stringCollection = new StringCollection();
            stringCollection.AddRange(stringRange);

            for (int n = stringCollection.Count; n < 400; n++)
            {
                stringCollection.Insert(n, "");
            }

            stringRange = new string[]
            {
                "A required API dynamic library was not found.",
                "The found and assigned API dynamic library could not be verified.",
            };

            stringCollection.AddRange(stringRange);

            for (int n = stringCollection.Count; n < 500; n++)
            {
                stringCollection.Insert(n, "");
            }

            stringRange = new string[]
            {
                "Object incorrectly initialized.",
                "A parameter is invalid.",
                "Already logged in.",
                "Already logged out."
            };

            stringCollection.AddRange(stringRange);

            for (int n = stringCollection.Count; n < 525; n++)
            {
                stringCollection.Insert(n, "");
            }

            stringCollection.Insert(525, "Incorrect use of system or platform.");

            for (int n = stringCollection.Count; n < 698; n++)
            {
                stringCollection.Insert(n, "");
            }

            stringCollection.Insert(698, "Capability is not available.");
            stringCollection.Insert(699, "Internal API error.");
        }
        #endregion

        #region functions
        /// <summary>
        /// Demonstrates the usage of the AES encryption and
        /// decryption methods.
        /// </summary>
        protected void EncryptDecryptDemo(Dog dog)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;

            // the string to be encryted/decrypted.
            string text = "SuperDog is great";

            // convert the string into a byte array.
            byte[] data = UTF8Encoding.Default.GetBytes(text);

            // encrypt the data.
            DogStatus status = dog.Encrypt(data);

            if (DogStatus.StatusOk == status)
            {
                text = UTF8Encoding.Default.GetString(data);

                // decrypt the data.
                // on success we convert the data back into a 
                // human readable string.
                status = dog.Decrypt(data);

                if (DogStatus.StatusOk == status)
                {
                    text = UTF8Encoding.Default.GetString(data);
                }
            }


            // Second choice - encrypting a string using the 
            // native .net API
            text = "Encrypt/Decrypt String";

            status = dog.Encrypt(ref text);

            if (DogStatus.StatusOk == status)
            {
                status = dog.Decrypt(ref text);

                if (DogStatus.StatusOk == status)
                    Console.WriteLine("Decrypted string: \"" + text + "\"");
            }
        }

        /// <summary>
        /// Demonstrates how to perform a login and an automatic
        /// logout using C#'s scope clause.
        /// </summary>
        protected void LoginDefaultAutoDemo()
        {
            DogFeature feature = DogFeature.Default;

            // this will perform a logout and object disposal
            // when the using scope is left.
            using (Dog dog = new Dog(feature))
            {
                DogStatus status = dog.Login(VendorCode.Code, scope);
                Console.WriteLine("test");
            }
        }

        /// <summary>
        /// Demonstrates how to login into a dog using the
        /// default feature. The default feature is ALWAYS 
        /// available in every SuperDog.
        /// </summary>
        protected Dog LoginDefaultDemo()
        {
            DogFeature feature = DogFeature.Default;

            Dog dog = new Dog(feature);

            DogStatus status = dog.Login(VendorCode.Code, scope);

            // Please note that there is no need to call
            // a logout function explicitly - although it is
            // recommended. The garbage collector will perform
            // the logout when disposing the object.
            // If you need more control over the logout procedure
            // perform one of the more advanced tasks.
            return dog.IsLoggedIn() ? dog : null;
        }

        /// <summary>
        /// Demonstrates how to login using a feature id.
        /// </summary>
        protected Dog LoginDemo(DogFeature feature)
        {
            // create a dog object using a feature
            // and perform a login using the vendor code.
            Dog dog = new Dog(feature);
            DogStatus status = dog.Login(VendorCode.Code, scope);
            return dog.IsLoggedIn() ? dog : null;
        }

        /// <summary>
        /// Demonstrates how to perform a login using the default
        /// feature and how to perform an automatic logout
        /// using the SuperDog's Dispose method.
        /// </summary>
        protected void LoginDisposeDemo()
        {
            DogFeature feature = DogFeature.Default;
            Dog dog = new Dog(feature);
            DogStatus status = dog.Login(VendorCode.Code, scope);
            dog.Dispose();
        }

        /// <summary>
        /// Demonstrates how to perform a login and a logout
        /// using the default feature.
        /// </summary>
        protected void LoginLogoutDefaultDemo()
        {
            DogFeature feature = DogFeature.Default;
            Dog dog = new Dog(feature);
            DogStatus status = dog.Login(VendorCode.Code, scope);

            if (DogStatus.StatusOk == status)
            {
                status = dog.Logout();
            }

            // recommended, but not mandatory
            // this call ensures that all resources to SuperDog
            // are freed immediately.
            dog.Dispose();
        }

        /// <summary>
        /// Performs a logout operation
        /// </summary>
        protected void LogoutDemo(ref Dog dog)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;
            DogStatus status = dog.Logout();
            // get rid of the dog immediately.
            dog.Dispose();
            dog = null;
        }

        /// <summary>
        /// Demonstrates how to perform read and write
        /// operations on a file in SuperDog
        /// </summary>
        protected void ReadWriteDemo(Dog dog, Int32 fileId)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;
            // Get a file object to a file in SuperDog.
            // please note: the file object is tightly connected
            // to its dog object. logging out from a dog also
            // invalidates the file object.
            // doing the following will result in an invalid
            // file object:
            // dog.login(...)
            // DogFile file = dog.GetFile();
            // dog.logout();
            // Debug.Assert(file.IsValid()); will assert
            DogFile file = dog.GetFile(fileId);
            if (!file.IsLoggedIn())
            {
                // Not logged into a dog - nothing left to do.
                return;
            }

            // get the file size
            int size = 0;
            DogStatus status = file.FileSize(ref size);

            if (DogStatus.StatusOk != status)
            {
                return;
            }

            // read the contents of the file into a buffer
            byte[] bytes = new byte[size];
            status = file.Read(bytes, 0, bytes.Length);

            if (DogStatus.StatusOk != status)
            {
                return;
            }
            // now let's write some data into the file
            byte[] newBytes = new byte[] { 1, 2, 3, 4, 5, 6, 7 };

            status = file.Write(newBytes, 0, newBytes.Length);
            if (DogStatus.StatusOk != status)
            {
                return;
            }
            // and read them again
            status = file.Read(newBytes, 0, newBytes.Length);
            // restore the original contents
            file.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Demonstrates how to read and write to/from a
        /// file at a certain file position
        /// </summary>
        protected void ReadWritePosDemo(Dog dog, Int32 fileId)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;

            // firstly get a file object to a file.
            DogFile file = dog.GetFile(fileId);
            if (!file.IsLoggedIn())
            {
                // Not logged into dog - nothing left to do.
                return;
            }

            // we want to write an int at the end of the file.
            // therefore we are going to 
            // - get the file's size
            // - set the object's read and write position to
            //   the appropriate offset.
            int size = 0;
            DogStatus status = file.FileSize(ref size);

            if (DogStatus.StatusOk != status)
            {
                return;
            }

            // set the file pos to the end minus the size of int
            file.FilePos = size - DogFile.TypeSize(typeof(int));

            // now read what's there
            int aValue = 0;
            status = file.Read(ref aValue);

            if (DogStatus.StatusOk != status)
            {
                return;
            }

            // write some data.
            status = file.Write(int.MaxValue);

            if (DogStatus.StatusOk != status)
            {
                return;
            }

            // read back the written value.
            int newValue = 0;
            status = file.Read(ref newValue);

            if (DogStatus.StatusOk == status)
                // restore the original data.
                file.Write(aValue);
        }

        /// <summary>
        /// Demonstrates how to get current time and date of 
        /// a SuperDog when available.
        /// </summary>
        protected void TestTimeDemo(Dog dog)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;

            DateTime time = DateTime.Now;
            DogStatus status = dog.GetTime(ref time);

            if (DogStatus.StatusOk == status)
                Console.WriteLine("Time and date is " + time.ToString());
        }

        /// <summary>
        /// Demonstrates how to use to retrieve a XML containing all available features.
        /// </summary>
        protected void GetInfoDemo()
        {
            string queryFormat = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                                      "<dogformat root=\"dog_info\">" +
                                                        " <feature>" +
                                                        "  <attribute name=\"id\" />" +
                                                        "  <element name=\"license\" />" +
                                                        " </feature>" +
                                                        "</dogformat>";
            string info = null;
            DogStatus status = Dog.GetInfo(scope, queryFormat, VendorCode.Code, ref info);
            Console.WriteLine(info);

        }
        /// <summary>
        /// if the id is there then is continue to run the app.
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public bool CheckFeatureID(string strID)
        {
            bool boFalgDog = false;
            if (scope == null)
            {
                scope = defaultScope;
            }
            string queryFormat = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" +
                                                      "<dogformat root=\"dog_info\">" +
                                                        " <feature>" +
                                                        "  <attribute name=\"id\" />" +
                                                        "  <element name=\"license\" />" +
                                                        " </feature>" +
                                                        "</dogformat>";
            string info = null;
            DogStatus status = Dog.GetInfo(scope, queryFormat, VendorCode.Code, ref info);
            if (DogStatus.StatusOk == status)
            {
                Console.WriteLine(info);               
                XmlDocument myXmlDoc = new XmlDocument();
                myXmlDoc.LoadXml(info);
                XmlNodeList xn = myXmlDoc.SelectNodes("/dog_info/feature");
                if (xn != null)
                {
                    foreach (XmlNode node in xn)
                    {
                        if (node.Attributes != null)
                        {
                            if (node.Attributes[0].Value.Equals("0"))
                            {
                                boFalgDog = true;
                                break;
                            }
                        }
                    }
                }
            }
            return boFalgDog;

        }
        /// <summary>
        /// Demonstrates how to retrieve information from a dog.
        /// </summary>
        protected void SessionInfoDemo(Dog dog)
        {
            if ((null == dog) || !dog.IsLoggedIn())
                return;

            // firstly we will retrieve the dog info.
            string info = null;
            DogStatus status = dog.GetSessionInfo(Dog.SessionInfo, ref info);

            // next the session info.
            status = dog.GetSessionInfo(Dog.SessionInfo, ref info);

            // last the update information.
            status = dog.GetSessionInfo(Dog.UpdateInfo, ref info);
        }
        #endregion

        #region Runs the API demo.

        /// <summary>
        /// Runs the API demo.
        /// </summary>
        public void RunDemo(string scope)
        {
            try
            {
                this.scope = scope;

                // Demonstrate the different login methods
                LoginDefaultAutoDemo();
                LoginLogoutDefaultDemo();
                LoginDisposeDemo();

                // Demonstrates how to get a list of available features
                GetInfoDemo();

                // run the API demo using the default feature
                Dog dog = LoginDefaultDemo();
                SessionInfoDemo(dog);
                ReadWriteDemo(dog, FileId);
                ReadWritePosDemo(dog, FileId);
                EncryptDecryptDemo(dog);
                TestTimeDemo(dog);
                LogoutDemo(ref dog);

                // run the API demo using feature id 42
                dog = LoginDemo(new DogFeature(DogFeature.FromFeature(42).Feature));
                SessionInfoDemo(dog);
                ReadWriteDemo(dog, FileId);
                ReadWritePosDemo(dog, FileId);
                EncryptDecryptDemo(dog);
                TestTimeDemo(dog);
                LogoutDemo(ref dog);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
