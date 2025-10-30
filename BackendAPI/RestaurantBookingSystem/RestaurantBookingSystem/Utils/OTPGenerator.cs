// Utils/OtpGenerator.cs
using System.Security.Cryptography;
using System.Text;


namespace RestaurantBookingSystem.Utils
{

        public static class OTPGenerator
        {
            // Generate 6-digit OTP based on mobile number and time window (2 min)
            public static string GenerateTOTP(string mobileNo)
            {
                if (string.IsNullOrEmpty(mobileNo))
                    throw new ArgumentNullException(nameof(mobileNo));

                long timeStep = DateTimeOffset.UtcNow.ToUnixTimeSeconds() / 120; // 2-minute window
                string key = mobileNo + "MySuperSecretKey"; // add a salt/secret

                using (var hmac = new HMACSHA1(Encoding.UTF8.GetBytes(key)))
                {
                    var timeBytes = BitConverter.GetBytes(timeStep);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(timeBytes);

                    byte[] hash = hmac.ComputeHash(timeBytes);
                    int offset = hash[hash.Length - 1] & 0xf;
                    int binary =
                        ((hash[offset] & 0x7f) << 24)
                        | ((hash[offset + 1] & 0xff) << 16)
                        | ((hash[offset + 2] & 0xff) << 8) 
                        | (hash[offset + 3] & 0xff);

                    int otp = binary % 1000000;
                    return otp.ToString("D6");
                }
            }

            // Verify OTP (must match the generated one)
            public static bool VerifyTOTP(string mobileNo, string otp)
            {
                var currentOtp = GenerateTOTP(mobileNo);
                return currentOtp == otp;
            }
        }
    }
