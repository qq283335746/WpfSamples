using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Yibi.WpfGenerate
{
    public class GenerateHelper
    {
        private const string _sourceDefault = "1234567890abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string _sourceStrong = "`~!@#$%^&*()-_=+[]{}\\|;:'\",<.>/?";
        private static List<char> _sourceDefaultDatas => _sourceDefault.ToCharArray().ToList();
        private static int _sourceDefaultLength = _sourceDefault.Length;

        public static string CreateGenerateCode(PasswordType passwordType)
        {
            List<char> datas = null;
            int n = 0;

            switch (passwordType)
            {
                case PasswordType.Default:
                    datas = _sourceDefaultDatas;
                    n = 20;
                    break;
                case PasswordType.Stronger:
                    var strongSource = _sourceDefault + _sourceStrong;


                    datas = strongSource.ToList<char>();
                    n = 30;
                    break;
                default:
                    throw new ArgumentException("不支持的密码类型", nameof(passwordType));
            }

            return string.Join("", CreateRandomCodes(datas,n));

        }

        private static IEnumerable<char> CreateRandomCodes(List<char> datas, int n)
        {
            byte[] bytes = new byte[n];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }

            var itemLength = datas.Count;

            foreach (var item in bytes)
            {
                var index = item % itemLength;

                yield return datas[index];
            }
        }
    }
}
